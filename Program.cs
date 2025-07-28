using MotionRepoServer.Services;
using MotionRepoServer.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    // Read configuration values from appsettings.json
    options.Authority = builder.Configuration["Authentication:Schemes:Bearer:Authority"];
    options.Audience = builder.Configuration["Authentication:Schemes:Bearer:ValidAudiences:0"];

    // Configure token validation parameters explicitly
    // options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    // {
    //     ValidateIssuer = true,
    //     ValidIssuer = builder.Configuration["Authentication:Schemes:Bearer:ValidIssuer"],
    //     ValidateAudience = true,
    //     ValidAudience = audience,
    //     ValidateLifetime = true,
    //     ValidateIssuerSigningKey = true,
    //     ClockSkew = TimeSpan.FromMinutes(5) // Allow 5 minutes clock skew
    // };

    // Add event handlers for debugging
    options.Events = new Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerEvents
    {
        OnAuthenticationFailed = context =>
        {
            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
            return Task.CompletedTask;
        },
        OnTokenValidated = context =>
        {
            Console.WriteLine("Token validated successfully");
            return Task.CompletedTask;
        },
        OnChallenge = context =>
        {
            Console.WriteLine($"OnChallenge: {context.Error}, {context.ErrorDescription}");
            return Task.CompletedTask;
        }
    };
});
builder.Services.AddAuthorization();

// Add CORS support for browser testing
// builder.Services.AddCors(options =>
// {
//     options.AddDefaultPolicy(policy =>
//     {
//         policy.AllowAnyOrigin();
//         policy.AllowAnyMethod();
//         policy.AllowAnyHeader();
//     });
// });

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddSwaggerService();

// Register application services
builder.Services.AddSingleton<AvatarService>();
builder.Services.AddSingleton<MotionService>(); // Renamed from AnimationService
builder.Services.AddSingleton<WorkoutService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseStaticFiles();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
//app.UseCors();

// Add authentication and authorization middleware
app.UseAuthentication();
app.UseAuthorization();

// Map endpoints for different resources
app.MapAvatarEndpoints();
app.MapMotionEndpoints(); // Renamed from MapAnimationEndpoints
app.MapWorkoutEndpoints();

// Add a test endpoint without authorization
app.MapGet("/test", () => "API is working!")
.WithName("TestEndpoint");

// Add an endpoint to debug JWT token information
app.MapGet("/debug-token", (HttpContext context) =>
{
    var authHeader = context.Request.Headers.Authorization.FirstOrDefault();
    if (authHeader == null)
    {
        return Results.Json(new { message = "No Authorization header found" });
    }

    if (!authHeader.StartsWith("Bearer "))
    {
        return Results.Json(new { message = "Authorization header doesn't start with 'Bearer '" });
    }

    var token = authHeader.Substring("Bearer ".Length);
    var parts = token.Split('.');

    return Results.Json(new {
        message = "Token received",
        tokenParts = parts.Length,
        headerLength = parts.Length > 0 ? parts[0].Length : 0,
        payloadLength = parts.Length > 1 ? parts[1].Length : 0,
        signatureLength = parts.Length > 2 ? parts[2].Length : 0,
        user = context.User.Identity?.Name ?? "Not authenticated"
    });
})
.WithName("DebugToken");

app.MapFallbackToFile("index.html");

app.Run();