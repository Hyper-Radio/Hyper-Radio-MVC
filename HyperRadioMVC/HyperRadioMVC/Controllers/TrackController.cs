using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers
{
    [Route("api/[controller]")]
    public class TrackController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TrackController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> GetTracks()
        {
            var client = _httpClientFactory.CreateClient();
            var apiUrl = "https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net/api/tracks";

            try
            {
                var response = await client.GetAsync(apiUrl);
                var content = await response.Content.ReadAsStringAsync();
                return Content(content, "application/json");
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching tracks: {ex.Message}");
            }
        }
    }
}