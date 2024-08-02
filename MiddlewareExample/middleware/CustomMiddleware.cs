using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class CustomMiddleware
{
    private readonly RequestDelegate _next;

    public CustomMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Do something before the next middleware is invoked
        await context.Response.WriteAsync("Hello from Custom Middleware - Before\n");

        // Call the next middleware in the pipeline
        await _next(context);

        // Do something after the next middleware is invoked
        await context.Response.WriteAsync("Hello from Custom Middleware - After\n");
    }
}
