using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class Pitch : Controller
{
    
    public IActionResult Index()
    {

        return View();
    }
}