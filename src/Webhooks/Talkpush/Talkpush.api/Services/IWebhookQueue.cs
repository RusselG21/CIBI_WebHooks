/// <summary>
/// Defines the interface for a webhook queue service that stores and processes webhook payloads.
/// </summary>
public interface IWebhookQueue
{
    /// <summary>
    /// Adds a webhook payload to the processing queue.
    /// </summary>
    /// <param name="payload">The webhook payload command to be queued for processing.</param>
    void EnqueueWebhook(GetTalkPushPayloadCommand payload);

    /// <summary>
    /// Attempts to remove and return a webhook payload from the queue.
    /// </summary>
    /// <param name="payload">When this method returns, contains the retrieved payload if successful, or the default value if unsuccessful.</param>
    /// <returns>True if a payload was retrieved from the queue; otherwise, false.</returns>
    bool TryDequeue(out GetTalkPushPayloadCommand payload);
}
