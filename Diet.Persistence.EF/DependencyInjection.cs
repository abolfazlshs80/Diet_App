using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Order.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using Diet.Domain.user.Repository;
using Diet.Persistence.EF.Repository;
using Diet.Domain.Contract;

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
        services.AddScoped<IFoodGroupRepository, FoodGroupRepository>();
        services.AddScoped<IUnitOfWorkService, UnitOfWorkService>();
        
        return services;
    }

}
