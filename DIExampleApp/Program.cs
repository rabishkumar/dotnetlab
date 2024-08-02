var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IGreetingService, GreetingService>();
builder.Services.AddControllers();
var app = builder.Build();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapGet("/", () => "Hello World!");
app.MapGet("/greet", (IGreetingService greetingService) => greetingService.Greet("World!!"));
app.Run();
