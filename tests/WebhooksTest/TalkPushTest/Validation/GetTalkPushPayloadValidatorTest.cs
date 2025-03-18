using FluentValidation.TestHelper;

namespace WebhooksTest.TalkPushTest.Validation;

/// <summary>
/// Contains tests for validating the GetTalkPushPayloadValidator functionality.
/// </summary>
public class GetTalkPushPayloadValidatorTest
{
    private readonly GetTalkPushPayloadValidator _validator;

    /// <summary>
    /// Initializes a new instance of the GetTalkPushPayloadValidatorTest class.
    /// </summary>
    public GetTalkPushPayloadValidatorTest()
    {
        _validator = new GetTalkPushPayloadValidator();
    }

    /// <summary>
    /// Tests that validation errors are generated when all fields in the GetTalkPushPayloadCommand are empty.
    /// </summary>
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

    /// <summary>
    /// Tests that no validation errors are generated when all fields in the GetTalkPushPayloadCommand have valid values.
    /// </summary>
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
