using DWD.BasicAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DWD.BasicAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
  
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
       
        _logger = logger;
    }

    [HttpGet]
    [Route("sum")]
    public double Sum(double firstValue, double secondValue)
    {
        var mathService = new MathService(new SumService(), new SubtractService());
        return mathService.Sum(firstValue, secondValue);
    }
    
    [HttpGet]
    [Route("subtract")]
    public double Subtract(double firstValue, double secondValue)
    {
        var mathService = new MathService(new SumService(), new SubtractService());
        return mathService.Subtract(firstValue, secondValue);
    }
    
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}