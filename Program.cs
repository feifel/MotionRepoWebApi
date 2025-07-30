using MotionRepoServer.Services;
using MotionRepoServer.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddJwtBearer(options =>
{
    // Read configuration values from appsettings.json
    options.Authority = builder.Configuration["Authentication:Schemes:Bearer:Authority"];
    options.Audience = builder.Configuration["Authentication:Schemes:Bearer:ValidAudiences:0"];

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

// Add CORS support 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        policy.WithOrigins("https://feifel.github.io/MotionRepoWebApp/", "http://localhost:5173", "https://localhost:5173")
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register HttpClient for GitHub repository service
builder.Services.AddHttpClient<GitHubRepositoryService>();

// Register application services
builder.Services.AddSingleton<GitHubRepositoryService>();
builder.Services.AddSingleton<MotionService>();
builder.Services.AddSingleton<AvatarService>();
builder.Services.AddSingleton<WorkoutService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowFrontend");

app.UseAuthentication();
app.UseAuthorization();

// Initialize services with GitHub data
using (var scope = app.Services.CreateScope())
{
    var motionService = scope.ServiceProvider.GetRequiredService<MotionService>();
    var avatarService = scope.ServiceProvider.GetRequiredService<AvatarService>();
    var workoutService = scope.ServiceProvider.GetRequiredService<WorkoutService>();
    
    await motionService.InitializeAsync();
    await avatarService.InitializeAsync();
    await workoutService.InitializeAsync();
}

// Register endpoints
app.MapMotionEndpoints();
app.MapAvatarEndpoints();
app.MapWorkoutEndpoints();

app.Run();