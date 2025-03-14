using System.Reflection;
using Domain.Common;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, 
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString));

        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddSignalR();
        services.AddHttpContextAccessor();
        services.AddRepositoriesFromAssemblies();
        services.AddServicesFromAssemblies();
        
        return services;
    } 
    
    public static void MigrateContext(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope();
        using var context = scope?.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        context?.Database.Migrate();
    }
    
    private static void AddRepositoriesFromAssemblies(this IServiceCollection services)
    {
        var entityAssembly = Assembly.GetAssembly(typeof(EntityBase));
        var repositoryType = typeof(IRepository<>);

        foreach (var entityType in entityAssembly!.GetTypes().Where(t => t.IsClass && t.IsSubclassOf(typeof(EntityBase))))
        {
            var repositoryInterface = repositoryType.MakeGenericType(entityType);
            var repositoryImplementation = typeof(Repository<>).MakeGenericType(entityType);

            services.AddScoped(repositoryInterface, repositoryImplementation);
        }
    }
    
    private static void AddServicesFromAssemblies(this IServiceCollection services)
    {
        var interfaceAssembly = Assembly.GetAssembly(typeof(IUserService));
        var implementationAssembly = Assembly.GetAssembly(typeof(UserService));

        var interfaces = interfaceAssembly!.GetTypes()
            .Where(t => t.IsInterface && t.Namespace == typeof(IUserService).Namespace && t.Name.EndsWith("Service"));

        foreach (var @interface in interfaces)
        {
            var implementationName = @interface.Name.Substring(1);
            var implementation = implementationAssembly!.GetTypes()
                .FirstOrDefault(t => t.IsClass && t.Namespace == typeof(UserService).Namespace && t.Name == implementationName);
            
            if (implementation != null && @interface.IsAssignableFrom(implementation))
            {
                services.AddScoped(@interface, implementation);

                foreach (var additionalInterface in implementation.GetInterfaces().Where(i => i.Name.EndsWith("Service")))
                {
                    services.AddScoped(additionalInterface, implementation);
                }
            }
        }
    }
}