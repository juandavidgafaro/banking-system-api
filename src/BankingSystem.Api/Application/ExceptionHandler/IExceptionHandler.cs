namespace BankingSystem.Api.Application.ExceptionHandler;
public interface IExceptionHandler
{
    Task Handler(HttpContext context, Exception exception, HeaderRequestModel headerRequestModel);
}
