using HyperRadioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HyperRadioMVC.ViewModels;

namespace HyperRadioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;


        public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;

        }

        // Full page render
        public IActionResult Index()
        {
            var vm = BuildHomeViewModel();
            return View(vm);
        }

        // === Partial for RIGHT PANEL (Artist Profile) ===
        [HttpGet]
        public async Task<IActionResult> ArtistProfile()
        {
            var client = _httpClientFactory.CreateClient();
            
            //TODOUpdate this to happen every 15 seconds

            try
            {
                // Fetch data from the API
                var artist = await client.GetFromJsonAsync<ArtistProfileVM>("https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net/api/stream/live/info"); //Update this to Azure location

                // If API returns null, fallback to default
                if (artist == null)
                {
                    artist = new ArtistProfileVM()
                    {
                        Name = "Frank Ocean (artist list is null)",
                        Description = "Weekly electronic music broadcast featuring indie and electronic artists from around the world.",
                        ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                    };
                }

                return PartialView("_ArtistProfile", artist);
            }
            catch (Exception ex)
            {
                // Log error and fallback
                Console.WriteLine($"Error fetching show info: {ex.Message}");

                var fallbackArtist = new ArtistProfileVM
                {
                    Name = "Frank Ocean (fallback artist because of error in fetching show)",
                    Description = "Weekly electronic music broadcast featuring indie and electronic artists from around the world.",
                    ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                };

                return PartialView("_ArtistProfile", fallbackArtist);
            }
        }

        // Left panel partial (show details)
        [HttpGet]
        public async Task<IActionResult> ShowDetails()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                // Fetch data from the API
                var show = await client.GetFromJsonAsync<ShowDetailsVM>("https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net/api/stream/live/info"); //Update this to Azure location

                // If API returns null, default fallback
                if (show == null)
                {
                    show = new ShowDetailsVM
                    {
                        Name = "Default Music Show",
                        Description = "Weekly electronic music broadcast featuring indie and electronic artists from around the world.",
                        ScheduledStart = DateTime.UtcNow
                    };
                }

                return PartialView("_ShowDetails", show);
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error fetching show info: {ex.Message}");

                var fallbackShow = new ShowDetailsVM
                {
                    Name = "Default Music Show",
                    Description = "Weekly electronic music broadcast featuring indie and electronic artists from around the world.",
                    ScheduledStart = DateTime.UtcNow
                };

                return PartialView("_ShowDetails", fallbackShow);
            }
        }

        // Right panel Partial (List of shows)
        [HttpGet]
        public async Task<IActionResult> Shows()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                // Call API
                var shows = await client.GetFromJsonAsync<List<ShowDetails>>("https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net/api/shows"); //Update to Azure location

                if (shows == null)
                {
                    shows = new List<ShowDetails>();
                }

                return PartialView("_Shows", shows);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return PartialView("_Shows", new List<ShowDetails>());
            }
        }
        
        
        // Helper so that first time it loads (before any track is loaded) there is a default, this ensures the UI doesnt break
        private HomeVM BuildHomeViewModel()
        {
            return new HomeVM
            {
                ArtistProfile = new ArtistProfileVM
                {
                    Name = "Frank Ocean",
                    Description = "Frank Ocean is an American singer, songwriter, record producer, and photographer. Known for his unconventional production and eclectic musical style, he has been acclaimed as one of the most influential contemporary artists.",
                    ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                },
                ShowDetails = new ShowDetailsVM
                {
                    Name = "Indie Music Show",
                    Description = "Weekly electronic music broadcast. This is a description of a show that includes information relevant to the show to be displayed hopefully taking up some space so that it is interesting.",
                    ScheduledStart = DateTime.UtcNow
                }
            };
        }
    }
}