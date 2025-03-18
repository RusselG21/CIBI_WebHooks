namespace BuildingBlocks.Exceptions;

public class InternalServerException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    public InternalServerException(string message) : base(message)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InternalServerException"/> class with a specified error message and additional details.
    /// </summary>
    /// <param name="message">The message that describes the error.</param>
    /// <param name="details">Additional details about the internal server error.</param>
    public InternalServerException(string message, string details) : base(message)
    {
        Details = details;
    }

    public string? Details { get; }
}
