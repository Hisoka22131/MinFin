using MinFin.DB.Context;
using MinFin.UoW;
using MinFin.Web.Services.CustomServices;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web;

public static class ServiceProviderExtensions
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        
        return services
            .AddDbContext()
            .AddUnitOfWork()
            .AddCustomServices();
    }

    private static IServiceCollection AddDbContext(this IServiceCollection services) => services.AddDbContext<MinFinDBContext>();
    
    private static IServiceCollection AddUnitOfWork(this IServiceCollection services) => services.AddScoped<IUnitOfWork, UnitOfWork>();
    
    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserService, UserService>();
    }
    
}