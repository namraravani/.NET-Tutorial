using Microsoft.AspNetCore.Diagnostics;

namespace GlobalExceptionHandlingDemo
{
    public class AppExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            

            var response = new ErrorResponse()
            { StatusCode =  StatusCodes.Status500InternalServerError,ExceptionMessage = exception.Message,Title = "Something went wrong"};

            await httpContext.Response.WriteAsJsonAsync("something Went Wrong");
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            return true;
        }
        
    }
}
