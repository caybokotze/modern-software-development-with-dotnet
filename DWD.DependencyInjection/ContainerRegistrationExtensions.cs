using Microsoft.Extensions.DependencyInjection;

namespace DWD.DependencyInjection;

public static class ContainerRegistrationExtensions
{
    public static void ConfigureContainer(this IServiceCollection collection)
    {
        collection.AddTransient(sp => new SumService("SumService 1", 1));
        collection.AddTransient<SubtractService>();
        collection.AddScoped<MathService>();
    }
}