using Diet.Application.UseCase.FoodGroup.Commands.Create;
using Diet.Application.UseCase.FoodGroup.Commands.Delete;
using Diet.Application.UseCase.FoodGroup.Commands.Update;
using Diet.Application.UseCase.FoodGroup.Queries.GetAll;
using Diet.Application.UseCase.FoodGroup.Queries.GetById;
using Diet.Domain.Contract.Commands.Order.Create;
using Diet.Domain.Contract.Commands.Order.Delete;
using Diet.Domain.Contract.Commands.Order.Update;
using Diet.Domain.Contract.Queries.FoodGroup.GetAll;
using Diet.Domain.Contract.Queries.FoodGroup.GetById;
using Diet.Framework.Core.Bus;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Application.UseCase.Order.Commands.Create;
using Order.Application.UseCase.Order.Commands.Update;


namespace Diet.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        //services.AddScoped<ICommandHandler<CreateFoodGroupCommand, CreateFoodGroupCommandResult>, CreateFoodGroupCommandHandler>();
        //services.AddScoped<IValidator<CreateFoodGroupCommand>, CreateFoodGroupCommandValidator>();

        var assembly = typeof(DependencyInjection).Assembly;

        services.Scan(scan => scan
            .FromAssemblies(assembly)
            // CommandHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()

            // QueryHandlers
            .AddClasses(classes => classes.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()

            // Validators
            .AddClasses(classes => classes.AssignableTo(typeof(IValidator<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
        );

        return services;
    }
}
