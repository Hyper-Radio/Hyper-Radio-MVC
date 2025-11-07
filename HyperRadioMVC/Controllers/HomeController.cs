using HyperRadioMVC.Models;
using Microsoft.AspNetCore.Mvc;
using HyperRadioMVC.ViewModels;

namespace HyperRadioMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Full page render
        public IActionResult Index()
        {
            var vm = BuildHomeViewModel();
            return View(vm);
        }

        // === Partial for RIGHT PANEL (Artist Profile) ===
        [HttpGet]
        public IActionResult ArtistProfile()
        {
            var artist = new ArtistProfileVM
            {
                Name = "Frank Ocean",
                Description = "Frank Ocean is an American singer, songwriter, record producer, and photographer. Known for his unconventional production and eclectic musical style, he has been acclaimed as one of the most influential contemporary artists.",
                ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
            };
            return PartialView("_ArtistProfile", artist);
        }

        // === Partial for LEFT PANEL (Show Details) ===
        [HttpGet]
        public IActionResult ShowDetails()
        {
            var show = new ShowDetailsVM
            {
                Name = "Indie Music Show",
                Description = "Weekly electronic music broadcast featuring indie and electronic artists from around the world.",
                ScheduledStart = DateTime.UtcNow
            };
            return PartialView("_ShowDetails", show);
        }

        // === Partial for RIGHT PANEL alternative (Shows List) ===
        [HttpGet]
        public IActionResult Shows()
        {
            var shows = new List<ShowDetails>
            {
                new ShowDetails
                {
                    Name = "Future Beats",
                    Description = "Exploring forward-thinking beats and producers.",
                    ScheduledStart = DateTime.UtcNow.AddDays(1)
                },
                new ShowDetails
                {
                    Name = "Lo-Fi Lounge",
                    Description = "Chill instrumental hip-hop and ambient selections.",
                    ScheduledStart = DateTime.UtcNow.AddDays(2)
                }
            };

            return PartialView("_Shows", shows);
        }

        // === Helper ===
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