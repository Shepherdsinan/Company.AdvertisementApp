using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.UI.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Company.AdvertisementApp.UI.Controllers;

public class AccountController : Controller
{
    private readonly IGenderManager _genderManager;
    private readonly IValidator<UserCreateModel>     _userCreateModelValidator;

    public AccountController(IGenderManager genderManager, IValidator<UserCreateModel> userCreateModelValidator)
    {
        _genderManager = genderManager;
        _userCreateModelValidator = userCreateModelValidator;
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
            return View(userCreateModel);
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