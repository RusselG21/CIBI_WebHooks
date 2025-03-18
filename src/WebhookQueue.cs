using System.Collections.Concurrent;

/// <summary>
/// Base implementation of a thread-safe webhook queue for storing and processing string payloads.
/// </summary>
public class WebhookQueue
{
    private readonly ConcurrentQueue<string> _queue = new();

    /// <summary>
    /// Adds a webhook payload string to the processing queue.
    /// </summary>
    /// <param name="payload">The webhook payload string to be queued for processing.</param>
    public void EnqueueWebhook(string payload)
    {
        _queue.Enqueue(payload);
    }

    /// <summary>
    /// Attempts to remove and return a webhook payload string from the queue.
    /// </summary>
    /// <param name="payload">When this method returns, contains the retrieved payload if successful, or the default value if unsuccessful.</param>
    /// <returns>True if a payload was retrieved from the queue; otherwise, false.</returns>
    public bool TryDequeue(out string payload)
    {
        return _queue.TryDequeue(out payload);
    }
}
