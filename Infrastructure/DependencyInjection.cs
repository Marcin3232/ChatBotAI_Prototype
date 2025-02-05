using Infrastructure.DB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Interfaces.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ChatAIDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("Default"),
                sqlServerOptions => sqlServerOptions.MigrationsAssembly("DBMigrations")))
            .AddRepositories();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddTransient<IChatMessageRepository, ChatMessageDbRepository>()
            .AddTransient<IChatResponseRepository, ChatResponseDbRepository>();
    }
}
