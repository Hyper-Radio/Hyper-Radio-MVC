using HyperRadioMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class AboutController : Controller
{

    public IActionResult Index()
    {
        var viewModel = new ShowDetailsVM
        {
            Name = "Morning Vibes",
            Description = "A calm start to your day with smooth beats.",
            ScheduledStart = DateTime.Now.AddHours(1)
        };

        return View(viewModel);
    }



}