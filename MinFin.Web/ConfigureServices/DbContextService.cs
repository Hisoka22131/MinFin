using Microsoft.EntityFrameworkCore;
using MinFin.DB.Context;
using MinFin.OtherDb.Context;
using MinFin.UoW;
using MinFin.Web.Services.CustomServices;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.ConfigureServices;

public static class DbContextService
{
    public static IServiceCollection AddDbContext(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        return serviceCollection
            .AddMinFinDbContext(configuration)
            .AddRestDbContext(configuration)
            .AddUnitOfWork()
            .AddCustomSqlServices();
    }

    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
    
    private static IServiceCollection AddMinFinDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddDbContext<MinFinDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("MinFinDbConnectionString"),
                    b => b.MigrationsAssembly("MinFin.Web")));
    }
    
    private static IServiceCollection AddRestDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddDbContext<RestDbContext>(opt =>
                opt.UseSqlServer(configuration.GetConnectionString("RestDbConnectionString"),
                    b => b.MigrationsAssembly("MinFin.Web")));
    }

    private static IServiceCollection AddCustomSqlServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSingleton<ISqlConnectionService, SqlConnectionService>();
    }
}