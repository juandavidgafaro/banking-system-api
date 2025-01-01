namespace BankingSystem.Api.Application.ExceptionHandler;
public class InvalidOperationExceptionHandler : ExceptionHandlerBase, IExceptionHandler
{
    public Task Handler(HttpContext context, Exception exception, HeaderRequestModel headerRequestModel)
    {
        var ex = exception as InvalidOperationException;
        return SetResult(context, errorMessage: [ex is not null ? ex.Message : string.Empty], HttpStatusCode.Conflict);
    }
}