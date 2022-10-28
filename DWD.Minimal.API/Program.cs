using System.Text.Json;
using DWD.Shared;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.MapGet("/info", () => JsonSerializer.Serialize(
    new
{
    Environment.UserName,
    Environment.MachineName,
    Environment.ProcessId,
    Environment.Is64BitProcess,
    Environment.OSVersion,
    drives = Environment.GetLogicalDrives()
}
));

app.MapPost("/person", (Person person) => $"Welcome dear, {person.FirstName}");
app.Run();