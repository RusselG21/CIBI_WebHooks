
namespace Talkpush.api.Features.PostPayload;

public record PostPayloadEvent(GetTalkPushPayloadCommand Payload) : INotification;


public class PostPayloadEventHandler : INotificationHandler<PostPayloadEvent>
{
    public async Task Handle(PostPayloadEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Processing PushTalk Webhook: Id = {notification.Payload.Id}");

        await Task.Delay(2000); // Simulate async work (e.g., calling external API)

        Console.WriteLine($"PushTalk Webhook Processed: Id = {notification.Payload.Id}");
    }
}
