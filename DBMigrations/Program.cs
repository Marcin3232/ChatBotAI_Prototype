using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var hostBuilder = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((options) =>
    {
        options.Sources.Clear();
        options.AddJsonFile("appsettings.migrations.json");
    })
    .ConfigureServices(services =>
    {
        IServiceProvider serviceProvider = services.BuildServiceProvider();
        services.AddDbContext<IApplicationDbContext, ChatAIDbContext>(options =>
        options.UseSqlServer(serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString("Default"),
            sqlServer => sqlServer.MigrationsAssembly("DBMigrations")));
    });

IHost host = hostBuilder.Build();
IServiceProvider serviceProvider = host.Services;

using IServiceScope scope = serviceProvider.CreateScope();
var databaseContext = scope.ServiceProvider.GetRequiredService<ChatAIDbContext>();
await databaseContext.Database.MigrateAsync();
Console.WriteLine("Press any key to exit...");
Console.ReadKey();
