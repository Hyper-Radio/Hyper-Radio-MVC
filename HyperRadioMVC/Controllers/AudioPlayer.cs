using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class AudioPlayer : Controller
{

    public IActionResult Index()
    {
        return View();
    }



}