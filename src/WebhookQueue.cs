using System.Collections.Concurrent;

public class WebhookQueue
{
    private readonly ConcurrentQueue<string> _queue = new();

    public void EnqueueWebhook(string payload)
    {
        _queue.Enqueue(payload);
    }

    public bool TryDequeue(out string payload)
    {
        return _queue.TryDequeue(out payload);
    }
}
