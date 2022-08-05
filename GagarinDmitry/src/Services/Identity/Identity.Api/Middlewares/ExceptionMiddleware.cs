using SharedModels.Exceptions;

namespace Identity.WebApi.Middlewares
{
    /// <summary>
    /// Provides ExceptionMiddleware.
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        /// <see cref="ILogger{ExceptionMiddleware}"/> ащк registration of application operation states .
        /// </summary>
        private readonly ILogger<ExceptionMiddleware> logger;

        /// <summary>
        /// <see cref="RequestDelegate"/> for  process an HTTP request.
        /// </summary>
        private readonly RequestDelegate next;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionMiddleware"/> class
        /// </summary>
        /// <param name="next"><see cref="RequestDelegate"/> implementation instance.</param>
        /// <param name="logger"><see cref="ILogger{ExceptionMiddleware}"/> implementation instance.</param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            this.next = next;
            this.logger = logger;
        }

        /// <summary>
        /// Processing the request
        /// </summary>
        /// <param name="httpContext"><see cref="HttpContext"/> to encapsulate information about the request.</param>
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="context"><see cref="HttpContext"/> to encapsulate information about the request.</param>
        /// <param name="exception"><see cref="Exception"/> to handling</param>
        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = GetStatusCode(exception);

            await context.Response.WriteAsync(new ExceptionDetails()
            {
                StatusCode = context.Response.StatusCode,
                Message = exception.Message,
            }.ToString());
        }

        /// <summary>
        /// Gets error code status.
        /// </summary>
        /// <param name="exception"></param>
        /// <returns>Еhe status code of the error being processed.</returns>
        private static int GetStatusCode(Exception exception)
        {
            return exception switch
            {
                ArgumentNullException => StatusCodes.Status400BadRequest,
                OperationCanceledException => 499,
                FailCreateException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError,
            };
        }
    }
}
