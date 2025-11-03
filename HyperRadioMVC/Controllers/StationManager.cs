using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class StationManager : Controller
{


    public IActionResult Index()
    {
        return View();
    }
    
    
}