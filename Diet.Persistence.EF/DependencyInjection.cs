using Diet.Application.Interface;
using Diet.Application.Service;
using Diet.Domain.user.Repository;
using Diet.Framework.Core.Interface;
using Diet.Persistence.EF.Context;
using Diet.Persistence.EF.Repository;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

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
 
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        //services.AddScoped<IUsersRepository, UsersRepository>();
        services.AddScoped<IAuthenticationService, AuthenticationService>();



        services.Scan(scan => scan
       .FromAssemblyOf<LifeCourseRepository>() // یا هر Repository دیگر که در همان پروژه است
       .AddClasses(c => c.AssignableTo<IRepository>())
           .AsImplementedInterfaces()
           .WithScopedLifetime());

        return services;
    }

}
