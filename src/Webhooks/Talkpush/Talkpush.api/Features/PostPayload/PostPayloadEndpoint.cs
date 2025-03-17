using Mapster;

namespace Talkpush.api.Features.GetPayload;

public record GetTalkPushPayloadRequest(Guid Id, string Sender, string Message, DateTime Date);


public class PostTalkPushPayloadEndpoint : ICarterModule
{
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
