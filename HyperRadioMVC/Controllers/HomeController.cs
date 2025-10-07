using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HyperRadioMVC.Models;

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
        var artist = new ArtistProfile
        {
            Name = "Frank Ocean",
            Description = "Frank Ocean is an American singer, songwriter, record producer, and photographer. Known for his unconventional production and eclectic musical style, he has been acclaimed as one of the most influential contemporary artists.",
            ImageUrl = "https://www.nme.com/wp-content/uploads/2016/09/2011FrankOcean02PR070212.jpg"
        };

        return View(artist);
    }

    public IActionResult Privacy()
    {
        return View();
    }

  
}