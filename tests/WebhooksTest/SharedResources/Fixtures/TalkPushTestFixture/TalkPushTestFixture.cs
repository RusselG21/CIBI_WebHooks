using Microsoft.Extensions.Logging;
using Moq;

/// <summary>
/// Test fixture that provides mock objects and dependencies for TalkPush unit tests.
/// </summary>
public class TalkPushTestFixture
{
    /// <summary>
    /// Gets the mocked PostPayloadHandler instance for testing.
    /// </summary>
    public PostPayloadHandler MockPostPayloadHandler { get; set; }

    /// <summary>
    /// Gets the mock logger for the PostPayloadHandler.
    /// </summary>
    public Mock<ILogger<PostPayloadHandler>> MockIlogger { get; set; }

    /// <summary>
    /// Gets the mock webhook queue service.
    /// </summary>
    public Mock<IWebhookQueue> MockWebhookQueue { get; set; }

    /// <summary>
    /// Initializes a new instance of the TalkPushTestFixture class and sets up mock dependencies.
    /// </summary>
    public TalkPushTestFixture()
    {
        MockIlogger = new Mock<ILogger<PostPayloadHandler>>();
        MockWebhookQueue = new Mock<IWebhookQueue>();
        MockPostPayloadHandler = new PostPayloadHandler(MockIlogger.Object, MockWebhookQueue.Object);
    }
}