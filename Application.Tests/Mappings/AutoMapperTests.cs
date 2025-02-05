using AutoMapper;

namespace Application.Tests.Mappings;

public class AutoMapperTests
{
    [Fact]
    public void Configuration_Valid_IsValid()
    {
        MapperConfiguration config = AutoMapperUtils.GetConfiguration();

        config.AssertConfigurationIsValid();
    }
}