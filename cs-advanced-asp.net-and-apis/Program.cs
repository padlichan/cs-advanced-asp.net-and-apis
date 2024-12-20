using cs_advanced_asp.net_and_apis.HealthChecks;
using cs_advanced_asp.net_and_apis.Models;
using cs_advanced_asp.net_and_apis.Services;
using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<SpellsService>();
builder.Services.AddScoped<SpellsModel>();
builder.Services.AddHealthChecks()
                .AddCheck<TeachersHealthCheck>("teacher_health_check",
                failureStatus: HealthStatus.Unhealthy,
                tags: ["file", "teachers"]);
var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseHealthChecks("/health");

app.MapGet("/", () => "Hello World!");

app.Run();
