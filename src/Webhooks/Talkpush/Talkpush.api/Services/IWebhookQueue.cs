public interface IWebhookQueue
{
    void EnqueueWebhook(GetTalkPushPayloadCommand payload);
    bool TryDequeue(out GetTalkPushPayloadCommand payload);
}
