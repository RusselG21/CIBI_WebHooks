using Microsoft.Extensions.Logging;
using Moq;

public class TalkPushTestFixture
{
    public PostPayloadHandler MockPostPayloadHandler { get; set; }
    public Mock<ILogger<PostPayloadHandler>> MockIlogger { get; set; }
    public Mock<IWebhookQueue> MockWebhookQueue { get; set; }

    public TalkPushTestFixture()
    {
        MockIlogger = new Mock<ILogger<PostPayloadHandler>>();
        MockWebhookQueue = new Mock<IWebhookQueue>();
        MockPostPayloadHandler = new PostPayloadHandler(MockIlogger.Object, MockWebhookQueue.Object);
    }
}