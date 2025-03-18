/// <summary>
/// Background service that continuously processes webhook payloads from the queue.
/// </summary>
public class WebhookBackgroundService
    (IWebhookQueue _queue,
    IServiceProvider _serviceProvider,
    ILogger<WebhookBackgroundService> _ilogger)
    : BackgroundService
{
    /// <summary>
    /// Executes the background processing task that monitors the webhook queue.
    /// </summary>
    /// <param name="stoppingToken">Triggered when the service is requested to stop.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
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
