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
        services.AddRepositoriesFromAssemblies();
        
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
}