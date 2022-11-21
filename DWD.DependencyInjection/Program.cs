// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DWD.DependencyInjection;

public static class Program
{
    public static void Main()
    {
        var serviceProvider = ConfigureServices();
        var mathService = serviceProvider.GetService<IMathService>();
        mathService!.SetValue(5);
        var result = mathService.GetValue();
        var mathService2 = serviceProvider.GetService<IMathService>();
        var result2 = mathService2!.GetValue();
        mathService2.SetValue(10);
        var mathService3 = serviceProvider.GetService<IMathService>();
        var result3 = mathService3!.GetValue();
        //
        Console.WriteLine(result);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
    }
    
    private static IServiceProvider ConfigureServices()
    {
        //setup dependency injection
        IServiceCollection services = new ServiceCollection();
        services.AddTransient(sp => new SumService("SumService 1", 1));
        services.AddTransient<SubtractService>();
        services.AddScoped<IMathService, MathService>();
        services.AddLogging();
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}

public interface IMathService
{
    double Sum(double a, double b);
    double Subtract(double a, double b);

    void SetValue(int value);
    int GetValue();
}

public class MathService : IMathService
{
    private readonly SumService _sumService;
    private readonly SubtractService _subtractService;

    private int _value = 0;

    public MathService(SumService sumService, SubtractService subtractService)
    {
        _sumService = sumService;
        _subtractService = subtractService;
    }

    public void SetValue(int value)
    {
        _value = value;
    }

    public int GetValue()
    {
        return _value;
    }

    public double Sum(double a, double b)
    {
        return _sumService.AddTwoDigits(a, b);
    }

    public double Subtract(double a, double b)
    {
        return _subtractService.SubtractTwoDigits(a, b);
    }
}

public class SubtractService
{
    public double SubtractTwoDigits(double a, double b)
    {
        return a - b;
    }
}

public class SumService
{
    private readonly string _name;
    private readonly int _version;

    public SumService(string name, int version)
    {
        _name = name;
        _version = version;
    }
    public double AddTwoDigits(double a, double b)
    {
        return a + b;
    }
}

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<Person>? People { get; set; }
}

public class Person
{
    public string? Name { get; set; }
}