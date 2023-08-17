using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class AppUserUpdateDtoValidator: AbstractValidator<AppUserUpdateDto>
{
    public AppUserUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x=>x.FirstName).NotEmpty().WithMessage("Ad alanı boş geçilemez");
        RuleFor(x=>x.SurName).NotEmpty().WithMessage("Soyad alanı boş geçilemez");
        RuleFor(x=>x.UserName).NotEmpty().WithMessage("Kullanıcı adı alanı boş geçilemez");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("Şifre alanı boş geçilemez");
        RuleFor(x=>x.GenderId).NotEmpty().WithMessage("Cinsiyet alanı boş geçilemez");
        RuleFor(x=>x.PhoneNumber).NotEmpty().WithMessage("Telefon numarası alanı boş geçilemez");
    }
}