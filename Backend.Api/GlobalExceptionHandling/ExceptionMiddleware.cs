using Newtonsoft.Json;
using System.Net;

namespace Backend.Api.GlobalExceptionHandling
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
       
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var response = context.Response;

            var errorResponse = new ErrorResponsee
            {
                Success = false
            };
            switch (exception)
            {
                case ApplicationException ex:
                    if (ex.Message.Contains("Invalid Token"))
                    {
                        response.StatusCode = (int)HttpStatusCode.Forbidden;
                        errorResponse.Message = ex.Message;
                        break;
                    }
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse.Message = ex.Message;
                    await context.Response.WriteAsync(errorResponse.Message);
                    break;

                case GlobalExceptions ex:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                     errorResponse.Message = ex.Message;
                    var result = JsonConvert.SerializeObject(errorResponse);
                    await context.Response.WriteAsync(result);
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse.Message = "Internal server error!";
                    await context.Response.WriteAsync(errorResponse.Message);
                    break;
            }

            //await context.Response.WriteAsync("error occured");
        }
    }
}
