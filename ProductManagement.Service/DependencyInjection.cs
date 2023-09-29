using AutoMapper.Extensions.ExpressionMapping;
using Microsoft.Extensions.DependencyInjection;
using ProductManagement.Repository;
using ProductManagement.Service.Common.Mappings;
using ProductManagement.Service.Interfaces;
using ProductManagement.Service.UOW;
using System.Reflection;

namespace ProductManagement.Service;
public static class DependencyInjection
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services.RegisterRepository(); //Registering all repository

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        //Registering Automapper
        services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile).Assembly);

        //Registering Services
        Assembly? assembly = Assembly.GetAssembly(typeof(IGenericService<>));

        if (assembly is null)
            throw new DllNotFoundException($"Sercice project not found.");

        services.Scan(scan => scan
            .FromAssemblies(assembly)
            .AddClasses(classes => classes.AssignableTo(typeof(IGenericService<>)), publicOnly: false)
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}
