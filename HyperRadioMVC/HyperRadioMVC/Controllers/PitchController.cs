using HyperRadioMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HyperRadioMVC.Controllers
{
    public class PitchController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public PitchController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateTrackVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var client = _clientFactory.CreateClient("Hyper-Radio.API");

            using var content = new MultipartFormDataContent();
            content.Add(new StringContent(model.Title), "Title");
            content.Add(new StringContent(model.Description), "Description");
            content.Add(new StringContent(model.Genre), "Genre");
            content.Add(new StringContent(model.ReleaseYear.ToString()), "ReleaseYear");
            content.Add(new StringContent(model.ImageURL ?? ""), "ImageURL");

            if (model.File != null && model.File.Length > 0)
            {
                var streamContent = new StreamContent(model.File.OpenReadStream());
                streamContent.Headers.ContentType = new MediaTypeHeaderValue(model.File.ContentType);
                content.Add(streamContent, "File", model.File.FileName);
            }

            try
            {
                var response = await client.PostAsync("/api/tracks", content);
                if (!response.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", $"API error: {response.StatusCode}");
                    return View(model);
                }

                TempData["Success"] = "Track submitted successfully!";
                return RedirectToAction("Index");
            }
            catch (HttpRequestException ex)
            {
                ModelState.AddModelError("", $"Error submitting track: {ex.Message}");
                return View(model);
            }
        }
    }
}