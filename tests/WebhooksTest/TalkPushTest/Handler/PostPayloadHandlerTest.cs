namespace WebhooksTest.TalkPushTest.Handler
{
    public class PostPayloadHandlerTest : IClassFixture<TalkPushTestFixture>
    {
        private readonly TalkPushTestFixture _fixture;

        public PostPayloadHandlerTest(TalkPushTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task Handle_ShouldEnqueueWebhookAndLogInformation()
        {
            // Arrange
            var handler = _fixture.MockPostPayloadHandler;
            var command = new GetTalkPushPayloadCommand(Guid.NewGuid(), "Sender", "Message", DateTime.UtcNow);

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            _fixture.MockWebhookQueue.Verify(q => q.EnqueueWebhook(command), Times.Once);

            Assert.Equal(Unit.Value, result);
        }
    }
}