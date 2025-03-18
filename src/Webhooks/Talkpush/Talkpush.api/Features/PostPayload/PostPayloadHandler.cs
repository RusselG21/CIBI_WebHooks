using BuildingBlocks.CQRS;

namespace Talkpush.api.Features.GetPayload;

/// <summary>
/// Represents a command to process a TalkPush webhook payload.
/// </summary>
/// <param name="Id">Unique identifier for the payload.</param>
/// <param name="Sender">The sender of the payload.</param>
/// <param name="Message">The message content of the payload.</param>
/// <param name="Date">The date and time when the payload was sent.</param>
public record GetTalkPushPayloadCommand(Guid Id, string Sender, string Message, DateTime Date) : ICommand;


/// <summary>
/// Provides validation rules for the TalkPush payload command.
/// </summary>
public class GetTalkPushPayloadValidator : AbstractValidator<GetTalkPushPayloadCommand>
{
    /// <summary>
    /// Initializes a new instance of the validator with defined validation rules.
    /// </summary>
    public GetTalkPushPayloadValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id should not be empty");
        RuleFor(x => x.Sender).NotEmpty().WithMessage("Sender should not be empty");
        RuleFor(x => x.Message).NotEmpty().WithMessage("Message should not be empty");
        RuleFor(x => x.Date).NotEmpty().WithMessage("Date should not be empty");
    }
}

/// <summary>
/// Handler for processing TalkPush payload commands.
/// </summary>
public class PostPayloadHandler : ICommandHandler<GetTalkPushPayloadCommand>
{
    private readonly ILogger<PostPayloadHandler> _logger;
    private readonly IWebhookQueue _queue;

    /// <summary>
    /// Initializes a new instance of the PostPayloadHandler with required dependencies.
    /// </summary>
    /// <param name="logger">Logger for recording operational information.</param>
    /// <param name="queue">Queue service for webhook payload processing.</param>
    public PostPayloadHandler(ILogger<PostPayloadHandler> logger, IWebhookQueue queue)
    {
        _logger = logger;
        _queue = queue;
    }

    /// <summary>
    /// Handles the processing of a TalkPush payload command by queuing it for background processing.
    /// </summary>
    /// <param name="request">The payload command to process.</param>
    /// <param name="cancellationToken">Token to monitor for cancellation requests.</param>
    /// <returns>A task representing the asynchronous operation with a Unit result.</returns>
    public virtual async Task<Unit> Handle(GetTalkPushPayloadCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("GetPayloadHandler: {Payload}", request);

        _queue.EnqueueWebhook(request);

        _logger.LogInformation("GetPayloadHandler: {Payload} - Done", request);

        return Unit.Value;
    }
}

