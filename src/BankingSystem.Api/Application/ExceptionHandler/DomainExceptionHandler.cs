namespace BankingSystem.Api.Application.ExceptionHandler;
public class DomainExceptionHandler : ExceptionHandlerBase, IExceptionHandler
{
    public Task Handler(HttpContext context, Exception exception, HeaderRequestModel headerRequestModel)
    {
        var ex = exception as DomainException;
        return SetResult(context, errorMessage: [ex is not null ? ex.Message : string.Empty], HttpStatusCode.Conflict);
    }
}
