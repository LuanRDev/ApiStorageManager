using ApiStorageManager.WebApi.Models;
using Serilog;
using System.Net;

namespace ApiStorageManager.WebApi.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Algo deu errado: {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsync(new ErrorDetails()
            {
                Message = "Internal Server Error.",
                Details = exception.Message,
                TraceId = context.TraceIdentifier
                
            }.ToString());
            Log.Error(new ErrorDetails()
            {
                Message = "Internal Server Error.",
                Details = exception.Message,
                TraceId = context.TraceIdentifier

            }.ToString());
        }
    }
}
