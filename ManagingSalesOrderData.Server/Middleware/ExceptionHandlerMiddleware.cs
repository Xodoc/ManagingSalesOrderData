using ManagingSalesOrderData.BLL.Validators.CustomExceptions;
using Newtonsoft.Json;
using System.Net;

namespace ManagingSalesOrderData.Server.Middleware
{
    public class ExceptionHandlerMiddleware
    {
        private const string JsonContentType = "application/json";
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            int status;
            string message;

            switch (exception)
            {
                case ValidatorException:
                    status = (int)HttpStatusCode.BadRequest;
                    message = exception.Message;
                    break;
                case UnauthorizedAccessException:
                    status = (int)HttpStatusCode.Unauthorized;
                    message = "Unauthorized access";
                    break;
                case ArgumentNullException:
                    status = (int)HttpStatusCode.NoContent;
                    message = "No content";
                    break;
                default:
                    status = (int)HttpStatusCode.InternalServerError;
                    message = "Internal server error";
                    Console.WriteLine(exception.Message);
                    break;
            }

            context.Response.ContentType = JsonContentType;
            context.Response.StatusCode = status;

            await context.Response.WriteAsync(JsonConvert.SerializeObject(message));
        }
    }
}