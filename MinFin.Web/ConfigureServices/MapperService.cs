using MinFin.Web.MapperConfigs;

namespace MinFin.Web.ConfigureServices;

public static class MapperService
{
    public static IServiceCollection AddMapperServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddCustomMapperProfiles();
    }

    private static IServiceCollection AddCustomMapperProfiles(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddAutoMapper(typeof(UserConfig));
    }
}