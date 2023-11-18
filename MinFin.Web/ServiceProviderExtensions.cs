using Microsoft.EntityFrameworkCore;
using MinFin.DB.Context;
using MinFin.ParseService.Interfaces;
using MinFin.ParseService.Services;
using MinFin.UoW;
using MinFin.Web.Services.CustomServices;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web;

public static class ServiceProviderExtensions
{
    public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers()
            .AddXmlDataContractSerializerFormatters();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services
            .AddDbContext(configuration)
            .AddUnitOfWork()
            .AddCustomServices()
            .AddParserServices();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<MinFinDbContext>(opt =>
            opt.UseSqlServer(configuration.GetConnectionString("MinFinDbConnectionString"),
                b => b.MigrationsAssembly("MinFin.Web")));

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services) =>
        services.AddScoped<IUnitOfWork, UnitOfWork>();

    private static IServiceCollection AddCustomServices(this IServiceCollection services) =>
        services.AddScoped<IUserService, UserService>();

    private static IServiceCollection AddParserServices(this IServiceCollection services) =>
        services.AddScoped<IXmlService, XmlService>();
}