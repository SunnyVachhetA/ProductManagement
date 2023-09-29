using AutoMapper;
using System.Reflection;

namespace ProductManagement.Service.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetAssembly(typeof(MappingProfile))!);
    }

    private void ApplyMappingsFromAssembly(Assembly assembly)
    {
        List<Type> types = assembly.GetExportedTypes()
            .Where(x => typeof(IMapFrom).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .ToList();

        foreach (Type type in types)
        {
            object? instance = Activator.CreateInstance(type);
            var methodInfo = type.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}