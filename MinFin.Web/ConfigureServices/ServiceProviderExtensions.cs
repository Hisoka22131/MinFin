namespace MinFin.Web.ConfigureServices;

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
            .AddServices()
            .AddParser()
            .AddMapperServices();
    }
}