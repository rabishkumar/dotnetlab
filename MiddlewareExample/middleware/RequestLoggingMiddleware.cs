using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var stopwatch = Stopwatch.StartNew();

        // Log request details
        _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

        await _next(context);

        // Log response details
        stopwatch.Stop();
        _logger.LogInformation("Finished handling request. Status code: {StatusCode}. Time taken: {ElapsedMilliseconds} ms",
            context.Response.StatusCode, stopwatch.ElapsedMilliseconds);
    }
}
