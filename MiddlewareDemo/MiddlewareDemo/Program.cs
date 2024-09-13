var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.Use(async (context, next) => {

    await context.Response.WriteAsync("Demo Middleware \n");
    next(context);
});

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("Hello You have pass the secret \n");
    next(context);
    
});

//app.Use(async (context,next) => {

//    context.Response.OnStarting(() =>
//    {
//        context.Response.Headers["My_Header"] = "My Name is Namra Ravani";
//        return Task.CompletedTask;
//    });

//    await next(context);  
//});

app.Run(async (context) => {
    await context.Response.WriteAsync("Welcome to Asp.Net Core 6 \n");
});


app.MapGet("/", () => "Hello World!");
app.Run();
