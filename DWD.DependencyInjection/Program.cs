// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace DWD.DependencyInjection;


public static class MathServiceExtensions
{
    public static double Sum(this MathService mathService, double a, double b, double c)
    {
        return mathService.Sum(a, b) + c;
    }
    
    public static double Sum(this MathService mathService, double a, double b, double c, double d)
    {
        return mathService.Sum(a, b) + c + d;
    }
}


public static class Foo
{
    public static string? Name { get; set; }
}

public static class Program
{
    public static void Main()
    {
        var serviceProvider = ConfigureServices();
        var mathService = serviceProvider.GetService<MathService>();
        
        var result = mathService?.Sum(1, 2, 3);
        Console.WriteLine(result);

        var foo = Foo.Name = "John";
        Console.WriteLine(foo);
        Foo.Name = "Mark";
        var john = Foo.Name;
        Console.Write(john);
        
        // mathService!.SetValue(5);
        // var result = mathService.GetValue();
        // var mathService2 = serviceProvider.GetService<IMathService>();
        // var result2 = mathService2!.GetValue();
        // mathService2.SetValue(10);
        // var mathService3 = serviceProvider.GetService<IMathService>();
        // var result3 = mathService3!.GetValue();
        //
        // Console.WriteLine(result);
        // Console.WriteLine(result2);
        // Console.WriteLine(result3);
    }
    
    private static IServiceProvider ConfigureServices()
    {
        //setup dependency injection
        IServiceCollection services = new ServiceCollection();
        services.ConfigureContainer();
        services.AddLogging();
        var serviceProvider = services.BuildServiceProvider();
        return serviceProvider;
    }
}