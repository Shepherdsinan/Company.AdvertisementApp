using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class AppUserCreateDtoValidator : AbstractValidator<AppUserCreateDto>
{
    public AppUserCreateDtoValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.SurName).NotEmpty();
        RuleFor(x => x.UserName).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
        RuleFor(x => x.GenderId).NotEmpty();
        RuleFor(x => x.PhoneNumber).NotEmpty();
    }
}