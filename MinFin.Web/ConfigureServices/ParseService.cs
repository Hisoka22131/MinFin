using MinFin.Parse.Interfaces;
using MinFin.Parse.Services;

namespace MinFin.Web.ConfigureServices;

public static class ParseService
{
    public static IServiceCollection AddParser(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddParserServices();
    }

    private static IServiceCollection AddParserServices(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddScoped<IXmlService, XmlService>()
            .AddScoped<ICsvService, CsvService>();
    }
}