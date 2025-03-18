/// <summary>
/// Implements a thread-safe queue for storing and processing webhook payloads.
/// </summary>
public class WebhookQueue : IWebhookQueue
{
    private readonly ConcurrentQueue<GetTalkPushPayloadCommand> _queue = new();

    /// <summary>
    /// Adds a webhook payload to the processing queue.
    /// </summary>
    /// <param name="payload">The webhook payload command to be queued for processing.</param>
    public void EnqueueWebhook(GetTalkPushPayloadCommand payload)
    {
        _queue.Enqueue(payload);
    }

    /// <summary>
    /// Attempts to remove and return a webhook payload from the queue.
    /// </summary>
    /// <param name="payload">When this method returns, contains the retrieved payload if successful, or the default value if unsuccessful.</param>
    /// <returns>True if a payload was retrieved from the queue; otherwise, false.</returns>
    public bool TryDequeue(out GetTalkPushPayloadCommand payload)
    {
        return _queue.TryDequeue(out payload!);
    }
}