using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using HyperRadioMVC.ViewModels;

namespace HyperRadioMVC.Controllers
{
    public class ShowController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ShowController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET /Show/GetTracks - proxy to API
        [HttpGet]
        public async Task<IActionResult> GetTracks()
        {
            var client = _httpClientFactory.CreateClient("Hyper-Radio.API");
            try
            {
                var tracks = await client.GetFromJsonAsync<List<TrackDto>>("/api/tracks");
                return Json(tracks);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, $"Error fetching tracks: {ex.Message}");
            }
        }

        // POST /Show/CreateShow - proxy to API
        [HttpPost]
        public async Task<IActionResult> CreateShow(CreateShowVM model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var client = _httpClientFactory.CreateClient("Hyper-Radio.API");

            try
            {
                var response = await client.PostAsJsonAsync("/api/shows", model);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", $"API error: {response.StatusCode}");
                    return View("Index", model);
                }

                return RedirectToAction("Index"); // success page or reload
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", $"Error submitting show: {ex.Message}");
                return View("Index", model);
            }
        }
    }

    // DTO for track to use in frontend JS
    public class TrackDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Genre { get; set; }
    }
}