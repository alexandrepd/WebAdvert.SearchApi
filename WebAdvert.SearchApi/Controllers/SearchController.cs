using Microsoft.AspNetCore.Mvc;
using WebAdvert.SearchApi.Models;
using WebAdvert.SearchApi.Services;

namespace WebAdvert.SearchApi.Controllers
{
    [ApiController]
    [Produces("application/json")]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        public SearchController(ISearchService searchService) => _searchService = searchService;

        [HttpGet]
        [Route("search/v1/{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword)
        {
            return await _searchService.Search(keyword);
        }
    }
}
