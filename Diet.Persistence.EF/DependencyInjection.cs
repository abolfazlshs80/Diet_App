using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Repository;
using Diet.Domain.Contract;
using Diet.Domain.durationAge.Repository;
using Diet.Domain.durationAge.Entities;
using Scrutor;
namespace Diet.Persistence.EF;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services
          .AddPersistence(configuration);

        return services;
    }

    private static IServiceCollection AddPersistence(
        this IServiceCollection services,
        IConfiguration configuration)
    {

        services.AddDbContext<DietDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("DientConnection")));

        //services.AddScoped<IOrderRepository, OrderRepository>();
        //services.AddScoped<IDurationAgeRepository, DurationAgeRepository>();
        //services.AddScoped<ILifeCourseRepository, LifeCourseRepository>();
        //services.AddScoped<IDrugRepository, DrugRepository>();
        //services.AddScoped<IFoodRepository, FoodRepository>();
        //services.AddScoped<IFoodGroupRepository, FoodGroupRepository>();
        //services.AddScoped<IFoodStuffRepository, FoodStuffRepository>();
        //services.AddScoped<IFoodDrugIntractionRepository, FoodDrugIntractionRepository>();
        //services.AddScoped<IFoodFoodIntractionRepository, FoodFoodIntractionRepository>();
        //services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
        services.Scan(scan => scan
       .FromAssemblyOf<IFoodRepository>() // یا یکی از Interfaceهای داخل لایه‌ی Infrastructure
       .AddClasses(c => c.Where(x => x.Name.EndsWith("Repository")))
           .AsImplementedInterfaces()
           .WithScopedLifetime());
        return services;
    }

}
