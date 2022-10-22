using System.Text.Json;
using DWD.Shared;
using FluentValidation;
using Minimal.API.WithValidation;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddValidatorsFromAssemblyContaining<Program>();
var app = builder.Build();
app.MapGet("/info", () => JsonSerializer.Serialize(new
{
    Environment.UserName,
    Environment.MachineName,
    Environment.ProcessId,
    Environment.Is64BitProcess,
    Environment.OSVersion
}));

app.MapPost("/person", (Validated<Person> person) =>
{
    var (isValid, value) = person;
    return isValid 
        ? JsonSerializer.Serialize(value) 
        : JsonSerializer.Serialize(person.Errors);
});

app.Run();