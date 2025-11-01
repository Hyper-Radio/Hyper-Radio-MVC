using HyperRadioMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HyperRadioMVC.Controllers;

public class PitchController : Controller
{
    
    private readonly HttpClient _client;

    public PitchController(IHttpClientFactory clientFactory)
    {
        _client = clientFactory.CreateClient("Hyper-Radio-API");
    }


    
    //CREATE TABLE
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
}