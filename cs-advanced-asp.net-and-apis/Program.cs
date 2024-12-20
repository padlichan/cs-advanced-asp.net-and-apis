using cs_advanced_asp.net_and_apis.Models;
using cs_advanced_asp.net_and_apis.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddScoped<SpellsService>();
builder.Services.AddScoped<SpellsModel>();
var app = builder.Build();


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
