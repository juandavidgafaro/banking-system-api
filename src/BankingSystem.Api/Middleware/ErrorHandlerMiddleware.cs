namespace BankingSystem.Api.Middleware;

public class ErrorHandlerMiddleware(
    RequestDelegate next,
    ILogger<ErrorHandlerMiddleware> logger,
    IDictionary<Type, IExceptionHandler> exceptionHandlers
)
{
    public const string SERVER_ERROR = "Ocurrió un error inesperado. Validar con el personal de soporte del banco.";

    private readonly RequestDelegate _next = next;
    private readonly ILogger<ErrorHandlerMiddleware> _logger = logger;
    private readonly IDictionary<Type, IExceptionHandler> _exceptionHandlers = exceptionHandlers;

    public async Task Invoke(HttpContext context)
    {
        HeaderRequestModel headerRequestModel = new()
        {
            User = context.Request.Headers["user"].FirstOrDefault() ?? string.Empty,
            Source = context.Request.Headers["source"].FirstOrDefault() ?? string.Empty,
        };

        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandlerExceptionAsync(context, ex, headerRequestModel);
        }
    }

    private Task HandlerExceptionAsync(HttpContext context, Exception ex, HeaderRequestModel headerRequestModel)
    {
        string message = $"{ex.Message} - Source: {headerRequestModel.Source}, Date: {DateTime.Now}";

        if (ex.InnerException != default)
        {
            _logger.LogError("{message}", $"{message}, Detalle: {ex.InnerException}");
        }
        else
        {
            _logger.LogError("{message}", $"{message}");
        }

        Task taskResult;
        Type exptionType = ex.GetType();
        if (_exceptionHandlers.TryGetValue(exptionType, out IExceptionHandler? exceptionHandler))
        {
            taskResult = exceptionHandler.Handler(context, ex, headerRequestModel);
        }
        else
        {
            taskResult = new ExceptionHandlerBase()
                .SetResult(
                context,
                [SERVER_ERROR],
                HttpStatusCode.InternalServerError
            );
        }

        return taskResult;
    }
}