using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.UI.Extensions;
using Company.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.AdvertisementApp.UI.Controllers;

public class AccountController : Controller
{
    private readonly IGenderManager _genderManager;
    private readonly IValidator<UserCreateModel>     _userCreateModelValidator;
    private readonly IAppUserManager _appUserManager;
    private readonly IMapper _mapper;

    public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator , IAppUserManager appUserManager, IMapper mapper)
    {
        _genderManager = genderManager;
        _userCreateModelValidator = userCreateModelValidator;
        _appUserManager = appUserManager;
        _mapper = mapper;
    }

    public async Task<IActionResult> SignUp()
    {
        var responseGender = await _genderManager.GetAllAsync();
        var userCreateModel = new UserCreateModel
        {
            Genders = new SelectList(responseGender.Data, "Id", "Definition")
        };
        return View(userCreateModel);
    }

    [HttpPost]
    public async Task<IActionResult> SignUp(UserCreateModel userCreateModel)
    {
        var resultuserCreateModelValidator = _userCreateModelValidator.Validate(userCreateModel);
        if (resultuserCreateModelValidator.IsValid)
        {
            var dto = _mapper.Map<AppUserCreateDto>(userCreateModel);
            var appUserCreateResponse = await _appUserManager.CreateAsync(dto);
            return this.ResponseRedirectAction(appUserCreateResponse, "SignUp");
        }

        foreach (var error in resultuserCreateModelValidator.Errors)
        {
            ModelState.AddModelError(error.PropertyName,error.ErrorMessage);
        }
        var responseGender = await _genderManager.GetAllAsync();
        userCreateModel.Genders = new SelectList(responseGender.Data, "Id", "Definition");
        return View(userCreateModel);
    }
    
    
}