using Microsoft.EntityFrameworkCore;
using MinFin.DB.Context;
using MinFin.ParseService.Interfaces;
using MinFin.ParseService.Services;
using MinFin.UoW;
using MinFin.Web.MapperConfigs;
using MinFin.Web.Services.CustomServices;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web;

public static class ServiceProviderExtensions
{
    public static void ConfigureServices(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection
            .AddControllers()
            .AddXmlDataContractSerializerFormatters();
        
        serviceCollection
            .AddEndpointsApiExplorer();
        
        serviceCollection
            .AddSwaggerGen();

        serviceCollection
            .AddDbContext(configuration)
            .AddUnitOfWork()
            .AddCustomServices()
            .AddParserServices()
            .AddCustomMapperProfiles();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        return serviceCollection
            .AddDbContext<MinFinDbContext>(opt => 
                opt.UseSqlServer(configuration.GetConnectionString("MinFinDbConnectionString"), 
                    b => b.MigrationsAssembly("MinFin.Web")));
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection serviceCollection)
    {
        return serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IUserService, UserService>();
    }

    private static IServiceCollection AddParserServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IXmlService, XmlService>()
            .AddScoped<ICsvService, CsvService>();
    }

    private static void AddCustomMapperProfiles(this IServiceCollection serviceCollection)
    {
        serviceCollection
            .AddAutoMapper(typeof(UserConfig));
    }
}