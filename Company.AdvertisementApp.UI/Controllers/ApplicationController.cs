using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.UI.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.AdvertisementApp.UI.Controllers;

[Authorize(Roles = "Admin")]
public class ApplicationController : Controller
{
    private readonly IAdvertisementManager _advertisementManager;

    public ApplicationController(IAdvertisementManager advertisementManager)
    {
        _advertisementManager = advertisementManager;
    }

    public async Task<IActionResult> List()
    {
        var response = await _advertisementManager.GetAllAsync();
        return this.ResponseView(response);
    }

    public IActionResult Create()
    {
        return View(new AdvertisementCreateDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(AdvertisementCreateDto dto)
    {
        var response = await _advertisementManager.CreateAsync(dto);
        return this.ResponseRedirectAction(response, "List");
    }

    public async Task<IActionResult> Update(int Id)
    {
        var response = await _advertisementManager.GetByIdAsync<AdvertisementUpdateDto>(Id);
        return this.ResponseView(response);
    }

    [HttpPost]
    public async Task<IActionResult> Update(AdvertisementUpdateDto dto)
    {
        var response = await _advertisementManager.UpdateAsync(dto);
        return this.ResponseRedirectAction(response, "List");
    }
    
    public async Task<IActionResult> Remove(int Id)
    {
        var response = await _advertisementManager.RemoveAsync(Id);
        return this.ResponseRedirectAction(response,"List");
    }
}