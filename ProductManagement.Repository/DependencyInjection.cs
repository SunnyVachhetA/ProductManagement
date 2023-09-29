using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Repository.Contexts;
using ProductManagement.Repository.Interfaces;
using System.Reflection;

namespace ProductManagement.Repository;
public static class DependencyInjection
{
    public static void RegisterRepository(this IServiceCollection services)
    {
        Assembly? assembly = Assembly.GetAssembly(typeof(AppDbContext));

        if (assembly is null)
            throw new DllNotFoundException($"Repository with db context not found.");

        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IGenericRepository<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}
