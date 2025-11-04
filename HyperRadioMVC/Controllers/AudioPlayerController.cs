using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class AudioPlayerController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    
}