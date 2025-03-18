namespace Talkpush.api.Features.PostPayload;

/// <summary>
/// Notification event triggered when a TalkPush payload is ready for processing.
/// </summary>
/// <param name="Payload">The webhook payload to process.</param>
public record PostPayloadEvent(GetTalkPushPayloadCommand Payload) : INotification;

/// <summary>
/// Handler for processing PostPayloadEvent notifications.
/// </summary>
public class PostPayloadEventHandler : INotificationHandler<PostPayloadEvent>
{
    /// <summary>
    /// Handles the processing of a PostPayloadEvent notification.
    /// </summary>
    /// <param name="notification">The notification containing the payload to process.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(PostPayloadEvent notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Processing PushTalk Webhook: Id = {notification.Payload.Id}");

        await Task.Delay(2000); // Simulate async work (e.g., calling external API)

        Console.WriteLine($"PushTalk Webhook Processed: Id = {notification.Payload.Id}");
    }
}
