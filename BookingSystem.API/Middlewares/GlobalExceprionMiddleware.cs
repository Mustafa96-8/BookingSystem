using Microsoft.OpenApi.Writers;

namespace BookingSystem.API.Middlewares;

public class GlobalExceprionMiddleware(ILoggerFactory logger) : IMiddleware
{
    private readonly ILogger _logger = logger.CreateLogger<GlobalExceprionMiddleware>();
    public async Task InvokeAsync (HttpContext context,RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception ex) 
        { 
            _logger.LogError("GlobalExceptionMiddleware: {exceprion}",ex); 
            await context.Response.WriteAsJsonAsync(ex.ToString());
        }
    }

}
