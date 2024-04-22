using LsoAPI.Exceptions;

namespace LsoAPI.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch(SongNotFoundException exception)
            {
                context.Response.StatusCode = 404;
                await context.Response.WriteAsync(exception.Message);
            }
            catch(InsufficientDataException exception)
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync(exception.Message);
            }
            catch(Exception exception) 
            {
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}
