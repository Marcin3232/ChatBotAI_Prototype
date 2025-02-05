using Application.Common.Mappings;
using AutoMapper;

namespace Application.Tests.Mappings;

public class AutoMapperUtils
{
    public static IMapper GetMapper()
    {
        return new Mapper(GetConfiguration());
    }

    public static MapperConfiguration GetConfiguration()
    {
        return new MapperConfiguration(cfg => cfg.AddMaps(new[] { typeof(MappingProfile) }));
    }
}