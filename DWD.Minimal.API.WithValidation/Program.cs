using System.Text.Json;
using DWD.Shared;
using Minimal.API.WithValidation;
using static Microsoft.AspNetCore.Http.Results;

// using static Microsoft.AspNetCore.Http.Results;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PersonService, PersonService>();

builder.Services.AddValidator<Person, PersonValidator>();
builder.Services.AddTransient<IPersonService, PersonService>();
var app = builder.Build();

app.MapPost("/person", (Validated<Person> person) =>
{
    var (isValid, value) = person;
    
    return isValid 
        ? Ok(value) 
        : ValidationProblem(person.Errors);
});

app.MapPost("/service",
    (Validated<Person> person, IPersonService executor) => executor.Execute(person.Value));

app.Run();