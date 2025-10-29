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

    
    [HttpPost]
    public async Task<IActionResult> Create(CreatePitchVM pitch)
    {
        if (!ModelState.IsValid)
            return View(pitch);

        await _client.PostAsJsonAsync("upload",pitch);
        
        return RedirectToAction("Index");
    }
}