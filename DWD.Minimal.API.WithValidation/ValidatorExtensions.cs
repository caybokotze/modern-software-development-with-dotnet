using System.Runtime.CompilerServices;
using FluentValidation;

namespace Minimal.API.WithValidation;

public static class ValidatorExtensions
{
    public static IServiceCollection AddValidator<TModel, TValidator>(this IServiceCollection serviceCollection) where TValidator : class, IValidator<TModel>
    {
        return serviceCollection.AddScoped<IValidator<TModel>, TValidator>();
    }
}