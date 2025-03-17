
public class WebhookQueue : IWebhookQueue
{
    private readonly ConcurrentQueue<GetTalkPushPayloadCommand> _queue = new();

    public void EnqueueWebhook(GetTalkPushPayloadCommand payload)
    {
        _queue.Enqueue(payload);
    }

    public bool TryDequeue(out GetTalkPushPayloadCommand payload)
    {
        return _queue.TryDequeue(out payload);
    }
}