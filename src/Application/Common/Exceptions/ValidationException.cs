namespace Application.Common.Exceptions;

public class ValidationException : Exception
{
    public IReadOnlyCollection<string> Errors { get; }

    public ValidationException(params string[] errors)
        : base("Validation failed.")
    {
        Errors = errors;
    }
}