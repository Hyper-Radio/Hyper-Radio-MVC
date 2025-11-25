using HyperRadioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HyperRadioMVC.ViewModels;

namespace HyperRadioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;

        private const string ApiBase = "https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net";

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

        // =========================
        //   RIGHT PANEL - Artist
        // =========================
        [HttpGet]
        public async Task<IActionResult> ArtistProfile()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var artist = await client.GetFromJsonAsync<ArtistProfileVM>(
                    $"{ApiBase}/api/stream/live/info"
                );

                if (artist == null)
                {
                    artist = new ArtistProfileVM
                    {
                        Name = "Frank Ocean (artist list is null)",
                        Description = "Weekly electronic music broadcast featuring indie and electronic artists.",
                        ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                    };
                }

                return PartialView("_ArtistProfile", artist);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Artist fetch error: {ex.Message}");

                var fallbackArtist = new ArtistProfileVM
                {
                    Name = "Frank Ocean (fallback)",
                    Description = "Weekly electronic music broadcast featuring indie and electronic artists.",
                    ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                };

                return PartialView("_ArtistProfile", fallbackArtist);
            }
        }

        // =========================
        //   LEFT PANEL - Show Info
        // =========================
        [HttpGet]
        public async Task<IActionResult> ShowDetails()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var show = await client.GetFromJsonAsync<ShowDetailsVM>(
                    $"{ApiBase}/api/stream/live/info"
                );

                if (show == null)
                {
                    show = new ShowDetailsVM
                    {
                        Name = "Default Music Show",
                        Description = "Weekly electronic music broadcast featuring indie and electronic artists.",
                        ScheduledStart = DateTime.UtcNow
                    };
                }

                return PartialView("_ShowDetails", show);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ShowDetails fetch error: {ex.Message}");

                var fallbackShow = new ShowDetailsVM
                {
                    Name = "Default Music Show",
                    Description = "Weekly electronic music broadcast featuring indie and electronic artists.",
                    ScheduledStart = DateTime.UtcNow
                };

                return PartialView("_ShowDetails", fallbackShow);
            }
        }

        // =========================
        //  SHOWS LIST PANEL
        // =========================
        [HttpGet]
        public async Task<IActionResult> Shows()
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var shows = await client.GetFromJsonAsync<List<ShowDetails>>(
                    $"{ApiBase}/api/shows"
                );

                if (shows == null)
                    shows = new List<ShowDetails>();

                return PartialView("_Shows", shows);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Shows fetch error: {ex.Message}");
                return PartialView("_Shows", new List<ShowDetails>());
            }
        }

        // =========================
        // AJAX: Load details for a specific show
        // =========================
        [HttpGet]
        public async Task<IActionResult> GetShowDetails(int id)
        {
            var client = _httpClientFactory.CreateClient();

            try
            {
                var show = await client.GetFromJsonAsync<ShowDetailsVM>(
                    $"{ApiBase}/api/shows/{id}"
                );

                if (show == null)
                {
                    show = new ShowDetailsVM
                    {
                        Name = "Unknown Show",
                        Description = "No details found.",
                        ScheduledStart = DateTime.UtcNow
                    };
                }

                return PartialView("_ShowDetails", show);
            }
            catch
            {
                return PartialView("_ShowDetails", new ShowDetailsVM
                {
                    Name = "Error Loading Show",
                    Description = "Could not fetch show info.",
                    ScheduledStart = DateTime.UtcNow
                });
            }
        }

        // =========================
        // DEFAULT HOME VIEW MODEL
        // =========================
        private HomeVM BuildHomeViewModel()
        {
            return new HomeVM
            {
                ArtistProfile = new ArtistProfileVM
                {
                    Name = "Frank Ocean",
                    Description = "Frank Ocean is an American singer, songwriter, and one of the most influential contemporary artists.",
                    ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
                },
                ShowDetails = new ShowDetailsVM
                {
                    Name = "Indie Music Show",
                    Description = "Weekly electronic music broadcast with indie artists.",
                    ScheduledStart = DateTime.UtcNow
                }
            };
        }
        
        
        // AJAX: Load Now Playing Artist based on show
        [HttpGet]
        public async Task<IActionResult> GetNowPlayingArtist(int showId)
        {
            var client = _httpClientFactory.CreateClient();

            // For demo: map showId -> artistId
            int artistId = showId; // simple mapping; adjust if you want random

            try
            {
                var artist = await client.GetFromJsonAsync<ArtistProfileVM>(
                    $"https://hyper-radio-api-ezgpemf9d5g2cuc0.norwayeast-01.azurewebsites.net/api/Creators/{artistId}"
                );

                if (artist == null)
                {
                    artist = new ArtistProfileVM
                    {
                        Name = "Unknown Artist",
                        Description = "No artist info available.",
                        ImageUrl = "https://via.placeholder.com/200"
                    };
                }

                return PartialView("_ArtistProfile", artist);
            }
            catch
            {
                return PartialView("_ArtistProfile", new ArtistProfileVM
                {
                    Name = "Error Loading Artist",
                    Description = "Could not fetch artist info.",
                    ImageUrl = "https://via.placeholder.com/200"
                });
            }
        }
    }
}