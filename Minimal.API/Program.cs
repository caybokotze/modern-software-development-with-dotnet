using System.Text.Json;
using Minimal.API;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/info", () => JsonSerializer.Serialize(new
{
    Environment.UserName,
    Environment.MachineName,
    Environment.ProcessId,
    Environment.Is64BitProcess,
    Environment.OSVersion
}));

app.MapPost("/person", (Person person) => $"Welcome dear, {person.Name}");
app.Run();