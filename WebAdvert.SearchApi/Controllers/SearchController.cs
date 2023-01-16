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
        private readonly ILogger<SearchController> _logger;
        public SearchController(ISearchService searchService, ILogger<SearchController> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpGet]
        [Route("search/v1/{keyword}")]
        public async Task<List<AdvertType>> Get(string keyword)
        {
            _logger.LogInformation("Search method was called");
            return await _searchService.Search(keyword);
        }
    }
}
