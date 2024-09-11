using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Security.Claims;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

// Configure authentication services
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = "youtube";
})
.AddCookie("cookie", o =>
{
    o.LoginPath = "/login";
    o.Events.OnRedirectToAccessDenied = ctx =>
    {
        if (ctx.Request.Path.StartsWithSegments("/yt"))
        {
            return ctx.HttpContext.ChallengeAsync("youtube");
        }
        return Task.CompletedTask;
    };
})
.AddOAuth("youtube", options =>
{
    var configuration = builder.Configuration;
    options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme; 
    options.ClientId = configuration["OAuth:ClientId"];
    options.ClientSecret = configuration["OAuth:ClientSecret"];
    options.SaveTokens = false;
    options.Scope.Clear();
    options.Scope.Add("https://www.googleapis.com/auth/youtube.readonly");
    options.AuthorizationEndpoint = "https://accounts.google.com/o/oauth2/v2/auth";
    options.TokenEndpoint = "https://oauth.googleapis.com/token";
    options.CallbackPath = "/oauth/yt-cb";

    options.Events.OnCreatingTicket = async ctx =>
    {
        var db = ctx.HttpContext.RequestServices.GetRequiredService<Database>();
        var authenticationHandlerProvider = ctx.HttpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
        var handler = await authenticationHandlerProvider.GetHandlerAsync(ctx.HttpContext, "cookie");
        var authResult = await handler.AuthenticateAsync();
        if (authResult.Succeeded)
        {
            ctx.Fail("Failed Authentication");
            return;
        }
        var cp = authResult.Principal;
        var userId = ctx.HttpContext.User.FindFirstValue("user_id");
        db[userId] = ctx.AccessToken;

        ctx.Principal = cp.Clone();
        var identity = ctx.Principal.Identities.First(x => x.AuthenticationType == "cookie");
        identity.AddClaim(new Claim("yt-token", "y"));
    };
});


// Configure authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("youtube-enabled", policy =>
    {
        policy.AddAuthenticationSchemes("cookie")
              .RequireClaim("yt-token", "y").RequireAuthenticatedUser();
    });
});

// Add services to the container
builder.Services.AddSingleton<Database>();
builder.Services.AddHttpClient();
//builder.Services.AddControllers();
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure HTTP request pipeline
app.MapGet("/login", () => Results.SignIn(new ClaimsPrincipal(new ClaimsIdentity(new[] { new Claim("user_id", Guid.NewGuid().ToString()) },
    "cookie")), authenticationScheme: "cookie"));

app.MapGet("/yt/info", async (IHttpClientFactory clientFactory, Database db, HttpContext ctx) =>
{
    var user = ctx.User;
    var userId = user.FindFirstValue("user_id");
    var accessToken = db[userId];
    var client = clientFactory.CreateClient();
    // Implement your logic here
}).RequireAuthorization("youtube-enabled");

app.Run(); // Added missing semicolon

public class Database : Dictionary<string, object>
{
}
