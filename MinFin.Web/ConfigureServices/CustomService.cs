using MinFin.Web.Services.CustomServices;
using MinFin.Web.Services.Interfaces;

namespace MinFin.Web.ConfigureServices;

public static class CustomService
{
    public static IServiceCollection AddServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddCustomServices();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IUserService, UserService>();
    }
}