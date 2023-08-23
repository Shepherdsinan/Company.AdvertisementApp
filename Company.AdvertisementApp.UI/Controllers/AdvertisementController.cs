

using System.Security.Claims;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.Common.Enums;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.UI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.AdvertisementApp.UI.Controllers;

public class AdvertisementController : Controller
{
    private readonly IAppUserManager _appUserManager;
    private readonly IAdvertisementAppUserManager _advertisementAppUserManager;

    public AdvertisementController(IAppUserManager appUserManager, IAdvertisementAppUserManager advertisementAppUserManager)
    {
        _appUserManager = appUserManager;
        _advertisementAppUserManager = advertisementAppUserManager;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [Authorize(Roles = "Member")]
    public async Task<IActionResult> Send(int advertisementId)
    {
        var userId = int.Parse((User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)!).Value);
        var userResponse = await _appUserManager.GetByIdAsync<AppUserListDto>(userId);
        ViewBag.GenderId = userResponse.Data.GenderId;

        var items = Enum.GetValues(typeof(MilitaryStatusType));
        
        var list = new List<MilitaryStatusListDto>();
        
        foreach (int item in items)
        {
            list.Add(new MilitaryStatusListDto
            {
                Id = item,
                Definition = Enum.GetName(typeof(MilitaryStatusType), item)
            });
        }

        ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
        
        return View(new AdvertisementAppUserCreateModel
        {
            AdvertisementId = advertisementId,
            AppUserId = userId
        });
    }

    [Authorize(Roles = "Member")]
    [HttpPost]
    public async Task<IActionResult> Send(AdvertisementAppUserCreateModel model)
    {
        AdvertisementAppUserCreateDto dto = new();
        if (model.CvFile!=null)
        {
            var fileName = Guid.NewGuid().ToString();
            var extName = Path.GetExtension(model.CvFile.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","cvFiles",fileName + extName);
            var stream = new FileStream(path, FileMode.Create);
            await model.CvFile.CopyToAsync(stream);
            dto.CvPath = path;
        }

        dto.AdvertisementAppUserStatusId = model.AdvertisementAppUserStatusId;
        dto.AdvertisementId = model.AdvertisementId;
        dto.AppUserId = model.AppUserId;
        dto.EndDate = model.EndDate;
        dto.MilitaryStatusId = model.MilitaryStatusId;
        dto.WorkExperience = model.WorkExperience;
        var response = await _advertisementAppUserManager.CreateAsync(dto);
        if (response.ResponseType == ResponseType.ValidationError)
        {
            foreach (var error in response.ValidationErrors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            var userId = int.Parse((User.Claims.FirstOrDefault(x=>x.Type == ClaimTypes.NameIdentifier)!).Value);
            var userResponse = await _appUserManager.GetByIdAsync<AppUserListDto>(userId);
            ViewBag.GenderId = userResponse.Data.GenderId;
            var items = Enum.GetValues(typeof(MilitaryStatusType));
        
            var list = new List<MilitaryStatusListDto>();
        
            foreach (int item in items)
            {
                list.Add(new MilitaryStatusListDto
                {
                    Id = item,
                    Definition = Enum.GetName(typeof(MilitaryStatusType), item)
                });
            }

            ViewBag.MilitaryStatus = new SelectList(list, "Id", "Definition");
            return View(model);
        }
        else
        {
            return RedirectToAction("HumanResource", "Home");
        }
        
    }
}