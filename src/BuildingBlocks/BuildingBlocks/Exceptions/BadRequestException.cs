namespace BuildingBlocks.Exceptions;

/// <summary>
/// Exception thrown when a request is invalid due to client error.
/// </summary>
public class BadRequestException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    public BadRequestException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="BadRequestException"/> class with a specified error message
    /// and additional details about the error.
    /// </summary>
    /// <param name="message">The error message that explains the reason for the exception.</param>
    /// <param name="details">Additional details that provide more information about the error.</param>
    public BadRequestException(string message, string details) : base(message)
    {
        Details = details;
    }

    /// <summary>
    /// Gets additional details about the error that caused the exception.
    /// </summary>
    public string? Details { get; }
}
