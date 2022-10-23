using System.Text.Json;
using DWD.Shared;
using FluentValidation;
using Minimal.API.WithValidation;
using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidator<Person, PersonValidator>();
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
        ? Ok(value) 
        : ValidationProblem(person.Errors);
});

app.Run();