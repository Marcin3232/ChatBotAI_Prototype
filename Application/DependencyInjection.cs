using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using MediatR;
using Application.Common.Interfaces.Services;
using Application.Services;

namespace Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        services.AddTransient<IChatAiResponseService, ChatAiResponseService>();
        return services;
    }
}
