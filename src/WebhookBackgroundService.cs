using Microsoft.Extensions.Hosting;

/// <summary>
/// Base background service for processing webhook payloads.
/// </summary>
public abstract class WebhookBackgroundService : BackgroundService
{
	/// <summary>
	/// Executes the background processing task.
	/// </summary>
	/// <param name="stoppingToken">Triggered when the service is requested to stop.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	protected override async Task ExecuteAsync(CancellationToken stoppingToken)
	{
		while (!stoppingToken.IsCancellationRequested)
		{
			await ProcessQueueAsync(stoppingToken);
			await Task.Delay(500, stoppingToken);
		}
	}

	/// <summary>
	/// Processes items from the queue. Must be implemented by derived classes.
	/// </summary>
	/// <param name="stoppingToken">Triggered when the service is requested to stop.</param>
	/// <returns>A task representing the asynchronous operation.</returns>
	protected abstract Task ProcessQueueAsync(CancellationToken stoppingToken);
}
