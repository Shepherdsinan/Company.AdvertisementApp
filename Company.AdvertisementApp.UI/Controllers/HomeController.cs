using System.Diagnostics;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Mvc;
using Company.AdvertisementApp.UI.Models;

namespace Company.AdvertisementApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IProvidedServiceManager _providedServiceManager;
    private readonly IAdvertisementManager _advertisementManager;


    public HomeController(ILogger<HomeController> logger, IProvidedServiceManager providedServiceManager, IAdvertisementManager advertisementManager)
    {
        _logger = logger;
        _providedServiceManager = providedServiceManager;
        _advertisementManager = advertisementManager;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _providedServiceManager.GetAllAsync();
        return this.ResponseView(response);
    }

    public async Task<IActionResult> HumanResource()
    {
        var response = await _advertisementManager.GetActiveAsync();
        return this.ResponseView(response);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
}