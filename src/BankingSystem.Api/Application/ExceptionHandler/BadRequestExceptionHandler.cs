namespace BankingSystem.Api.Application.ExceptionHandler;

public class BadRequestExceptionHandler : ExceptionHandlerBase, IExceptionHandler
{
    public Task Handler(HttpContext context, Exception exception, HeaderRequestModel headerRequestModel)
    {
        BadRequestException? ex = exception as BadRequestException;
        IEnumerable<string?> errorList = ex is not null ? ex.Errors.Select(x => x.ErrorMessage) : Enumerable.Empty<string?>();
        return SetResult(context, errorList.ToArray(), HttpStatusCode.BadRequest);
    }
}
