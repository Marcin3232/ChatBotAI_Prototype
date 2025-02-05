using Application.Common.Interfaces.Mappings;
using AutoMapper;
using System.Reflection;

namespace Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public void ApplyMappingsFromAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(t => t.GetInterfaces().Any(i =>
                i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) || i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var interfaces = type.GetInterfaces();

            foreach (var iface in interfaces.Where(x => x.GetGenericTypeDefinition() == typeof(IMapFrom<>) || x.GetGenericTypeDefinition() == typeof(IMapTo<>)).ToList())
            {
                var ifaceMethod = iface.GetMethod("Mapping");
                ifaceMethod?.Invoke(instance, [this]);
            }
        }
    }
}
