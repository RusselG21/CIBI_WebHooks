using BuildingBlocks.CQRS;

namespace Talkpush.api.Features.GetPayload;

public record GetTalkPushPayloadCommand(Guid Id, string Sender, string Message, DateTime Date) : ICommand;


public class GetTalkPushPayloadValidator : AbstractValidator<GetTalkPushPayloadCommand>
{
    public GetTalkPushPayloadValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be empty");
        RuleFor(x => x.Sender).NotEmpty().WithMessage("Sender should not be empty");
        RuleFor(x => x.Message).NotEmpty().WithMessage("Message should not be empty");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date should not be empty");
    }
}

public class PostPayloadHandler : ICommandHandler<GetTalkPushPayloadCommand>
{
    private readonly ILogger<PostPayloadHandler> _logger;
    private readonly IWebhookQueue _queue;

    public PostPayloadHandler(ILogger<PostPayloadHandler> logger, IWebhookQueue queue)
    {
        _logger = logger;
        _queue = queue;
    }

    public virtual async Task<Unit> Handle(GetTalkPushPayloadCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetPayloadHandler: {Payload}", request);

        _queue.EnqueueWebhook(request);

        _logger.LogInformation("GetPayloadHandler: {Payload} - Done", request);

        return Unit.Value;
    }
}

