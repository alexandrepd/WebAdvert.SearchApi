using Nest;
using WebAdvert.SearchApi.Models;

namespace WebAdvert.SearchApi.Extensions
{
    public static class AddNestConfigurationExtension
    {
        public static void AddElasticSearch(this IServiceCollection services, IConfiguration configuration)
        {
            string? elasticSearchUrl = configuration.GetSection("ES").GetValue<string>("URL");

            ConnectionSettings connectionString = new ConnectionSettings(new Uri(uriString: elasticSearchUrl!))
                .BasicAuthentication("elastic", "6Mz=ZgQ5j+evfwxJtCzH")
                .DefaultIndex("adverts")
                .DefaultMappingFor<AdvertType>(advert => advert.IdProperty(id => id.Id));
            ElasticClient client = new ElasticClient(connectionString);

            services.AddSingleton<IElasticClient>(client);
        }
    }
}
