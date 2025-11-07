using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class ShowController : Controller
{

    public IActionResult Index()
    {
        return View();

    }
    

    public IActionResult ShowList()
    {
        return View();

    }


    
}