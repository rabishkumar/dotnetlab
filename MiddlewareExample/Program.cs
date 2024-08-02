// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();
// app.UseMiddleware<CustomMiddleware>();

// app.MapGet("/", () => "Hello World!");
// app.Run(async (context) =>
// {
//    // await context.Response.WriteAsync("Hello from the final middleware.\n");
// });
// app.Run();
// var builder = WebApplication.CreateBuilder(args);
// var app = builder.Build();

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Middleware 1 - Before\n");
//     await next();
//     await context.Response.WriteAsync("Middleware 1 - After\n");
// });

// app.Use(async (context, next) =>
// {
//     await context.Response.WriteAsync("Middleware 2 - Before\n");
//     await next();
//     await context.Response.WriteAsync("Middleware 2 - After\n");
// });

// app.Run(async (context) =>
// {
//     await context.Response.WriteAsync("Final middleware\n");
// });

// app.Run();
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Register custom logging middleware
app.UseMiddleware<RequestLoggingMiddleware>();

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Hello, World!");
});

app.Run();

