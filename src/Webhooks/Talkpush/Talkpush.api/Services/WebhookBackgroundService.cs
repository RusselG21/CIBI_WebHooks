

public class WebhookBackgroundService
    (IWebhookQueue _queue,
    IServiceProvider _serviceProvider,
    ILogger<WebhookBackgroundService> _ilogger)
    : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            if (_queue.TryDequeue(out var payload))
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                // Retry Mechanism if exception occur
                try
                {
                    await mediator.Publish(new PostPayloadEvent(payload), stoppingToken);
                }
                catch (Exception ex)
                {
                    _ilogger.LogError($"Error processing webhook: {ex.Message}");
                    _queue.EnqueueWebhook(payload);
                }
            }
            else
            {
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
