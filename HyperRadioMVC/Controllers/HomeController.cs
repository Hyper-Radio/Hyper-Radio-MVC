using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HyperRadioMVC.Models;
using HyperRadioMVC.ViewModels;

namespace HyperRadioMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        
        var viewModel = new HomeVM
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

        return View(viewModel);    }

    public IActionResult Privacy()
    {
        return View();
    }

  
}