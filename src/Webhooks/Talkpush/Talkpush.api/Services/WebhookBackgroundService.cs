
using Talkpush.api.Features.PostPayload;

public class WebhookBackgroundService(IWebhookQueue _queue, IServiceProvider _serviceProvider)
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

                await mediator.Publish(new PostPayloadEvent(payload), stoppingToken);
            }
            else
            {
                await Task.Delay(500, stoppingToken);
            }
        }
    }
}
