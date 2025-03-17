
using FluentValidation.TestHelper;

namespace WebhooksTest.TalkPushTest.Validation;

public class GetTalkPushPayloadValidatorTest
{
    private readonly GetTalkPushPayloadValidator _validator;

    public GetTalkPushPayloadValidatorTest()
    {
        _validator = new GetTalkPushPayloadValidator();
    }

    [Fact]
    public void Should_Have_Validation_Error_When_GetTalkPushPayloadCommand_Are_All_Empty()
    {
        // Arrange
        var command = new GetTalkPushPayloadCommand
            (Guid.Empty,
            string.Empty,
            string.Empty,
            DateTime.MinValue);

        // Act
        var result = this._validator.TestValidate(command);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.Id).WithErrorMessage("Id should not be empty");
        result.ShouldHaveValidationErrorFor(x => x.Sender).WithErrorMessage("Sender should not be empty");
        result.ShouldHaveValidationErrorFor(x => x.Message).WithErrorMessage("Message should not be empty");
        result.ShouldHaveValidationErrorFor(x => x.Date).WithErrorMessage("Date should not be empty");
    }


    [Fact]
    public void Should_Have_Not_Return_Any_Error()
    {
        // Arrange
        var command = new GetTalkPushPayloadCommand
          (new Guid("b666fbe9-eff4-4335-9713-b99f7034ed43"),
          "john Doe",
          "Sample",
          DateTime.Now);

        // Act
        var result = this._validator.TestValidate(command);

        // Assert
        result.ShouldNotHaveValidationErrorFor(x => x.Id);
        result.ShouldNotHaveValidationErrorFor(x => x.Sender);
        result.ShouldNotHaveValidationErrorFor(x => x.Message);
        result.ShouldNotHaveValidationErrorFor(x => x.Date);

    }
}
