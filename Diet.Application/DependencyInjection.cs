using Diet.Application.UseCase.FoodGroup.Commands.Create;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Framework.Core.Bus;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.UseCase.Order.Commands.Create;


namespace Diet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        services.AddScoped<ICommandHandler<CreateFoodGroupCommand, CreateFoodGroupCommandResult>, CreateFoodGroupCommandHandler>();
        services.AddScoped<IValidator<CreateFoodGroupCommand>, CreateFoodGroupCommandValidator>();
        
        return services;
    }
}
