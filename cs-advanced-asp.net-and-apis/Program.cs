using cs_advanced_asp.net_and_apis.HealthChecks;
using cs_advanced_asp.net_and_apis.Models;
using cs_advanced_asp.net_and_apis.Services;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<SpellsService>();
builder.Services.AddScoped<SpellsModel>();
builder.Services.AddScoped<TeachersService>();
builder.Services.AddScoped<TeachersModel>();

//Rate limiting
builder.Services.AddRateLimiter(options =>
{
    options.AddFixedWindowLimiter(policyName: "fixed", options =>
    {
        options.PermitLimit = 3;
        options.Window = TimeSpan.FromMinutes(1);
        options.QueueLimit = 2;
        options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
}
);

//Health checks
builder.Services.AddHealthChecks()
                .AddCheck<TeachersHealthCheck>("teacher_health_check",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["file", "teachers"]);

var app = builder.Build();

app.UseRateLimiter();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks("/health");

app.MapGet("/", () => "Hello World!");

app.Run();
