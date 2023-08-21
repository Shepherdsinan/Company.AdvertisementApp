using System.Security.Claims;
using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common.Enums;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.UI.Extensions;
using Company.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.AdvertisementApp.UI.Controllers;

public class AccountController : Controller
{
    private readonly IGenderManager _genderManager;
    private readonly IValidator<UserCreateModel> _userCreateModelValidator;
    private readonly IAppUserManager _appUserManager;
    private readonly IMapper _mapper;

    public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator,
        IAppUserManager appUserManager, IMapper mapper)
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
            var appUserCreateResponse = await _appUserManager.CreateWithRoleAsync(dto, (int)RoleType.Member);
            return this.ResponseRedirectAction(appUserCreateResponse, "SignIn");
        }

        foreach (var error in resultuserCreateModelValidator.Errors)
        {
            ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
        }

        var responseGender = await _genderManager.GetAllAsync();
        userCreateModel.Genders = new SelectList(responseGender.Data, "Id", "Definition");
        return View(userCreateModel);
    }

    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> SignIn(AppUserLoginDto dto)
    {
        var result = await _appUserManager.CheckUserAsync(dto);
        if (result.ResponseType == Common.ResponseType.Success)
        {
            var claims = new List<Claim>
            {
            };
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);
            
            var authProperties = new AuthenticationProperties
            {
                //ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                IsPersistent = dto.RememberMe
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity), authProperties);
        }
        ModelState.AddModelError("",result.Message);
        return View(dto);
    }
}