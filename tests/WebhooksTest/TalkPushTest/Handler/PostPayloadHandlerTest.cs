namespace WebhooksTest.TalkPushTest.Handler
{
    /// <summary>
    /// Contains tests for the PostPayloadHandler functionality.
    /// </summary>
    public class PostPayloadHandlerTest : IClassFixture<TalkPushTestFixture>
    {
        private readonly TalkPushTestFixture _fixture;

        /// <summary>
        /// Initializes a new instance of the PostPayloadHandlerTest class with the required test fixture.
        /// </summary>
        /// <param name="fixture">The test fixture providing test dependencies.</param>
        public PostPayloadHandlerTest(TalkPushTestFixture fixture)
        {
            _fixture = fixture;
        }

        /// <summary>
        /// Tests that the Handle method correctly enqueues a webhook and returns Unit.Value.
        /// </summary>
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