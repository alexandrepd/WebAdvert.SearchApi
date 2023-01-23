using Nest;
using WebAdvert.SearchApi.Models;

namespace WebAdvert.SearchApi.Services
{
    public class SearchService : ISearchService
    {
        private readonly IElasticClient _ElasticClient;
        public SearchService(IElasticClient elasticClient) => _ElasticClient = elasticClient;

        public async Task<List<AdvertType>> Search(string keyword)
        {
            var searchResponse = await _ElasticClient.SearchAsync<AdvertType>(search =>
            search.Query(query =>
            query.Term(field =>
            field.Title, keyword.ToLower())));

            List<AdvertType> result = searchResponse.Hits.Select(hit => hit.Source).ToList<AdvertType>();

            return result;
        }
    }
}
