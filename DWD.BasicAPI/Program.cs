using System.Text;
using DWD.BasicAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IMathService, MathService>();
builder.Services.AddTransient<SumService, SumService>();
builder.Services.AddTransient<SubtractService, SubtractService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.Run(async httpContext =>
{
    var randomText = "Hey there!";
    httpContext.Response.StatusCode = 400;
    await httpContext.Response.Body.WriteAsync(Encoding.UTF8.GetBytes(randomText));
});

app.MapControllers();
app.Run();