using Mapster;

namespace Talkpush.api.Features.GetPayload;

/// <summary>
/// Request model for receiving TalkPush webhook payloads.
/// </summary>
/// <param name="Id">Unique identifier for the payload.</param>
/// <param name="Sender">The sender of the payload.</param>
/// <param name="Message">The message content of the payload.</param>
/// <param name="Date">The date and time when the payload was sent.</param>
public record GetTalkPushPayloadRequest(Guid Id, string Sender, string Message, DateTime Date);

/// <summary>
/// Configures API endpoints for processing TalkPush webhook payloads.
/// </summary>
public class PostTalkPushPayloadEndpoint : ICarterModule
{
    /// <summary>
    /// Adds route definitions for TalkPush webhook endpoints.
    /// </summary>
    /// <param name="app">The endpoint route builder.</param>
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/webhooks/talkpush", async (GetTalkPushPayloadRequest payload, IMediator mediator) =>
        {
            var command = payload.Adapt<GetTalkPushPayloadCommand>();

            await mediator.Send(command);

            return Results.Accepted();
        })
         .WithName("PostPayloadBasket")
         .Produces(StatusCodes.Status202Accepted)
         .ProducesProblem(StatusCodes.Status202Accepted)
         .WithSummary("Post Payload")
         .WithDescription("Post Payload");
    }
}
