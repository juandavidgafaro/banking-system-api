namespace BankingSystem.Api.Application.Exceptions;

public class BadRequestException(IEnumerable<ValidationResult> errors) : Exception
{
    public IEnumerable<ValidationResult> Errors { get; private set; } = errors;
}
