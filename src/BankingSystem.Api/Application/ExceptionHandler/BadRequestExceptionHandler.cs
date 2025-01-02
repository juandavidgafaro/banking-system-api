namespace BankingSystem.Api.Application.ExceptionHandler;

public class BadRequestExceptionHandler : ExceptionHandlerBase, IExceptionHandler
{
    public Task Handler(HttpContext context, Exception exception, HeaderRequestModel headerRequestModel)
    {
        var ex = exception as BadRequestException;
        return SetResult(context, errorMessage: [ex is not null ? ex.Message : string.Empty], HttpStatusCode.BadRequest);
    }
}
