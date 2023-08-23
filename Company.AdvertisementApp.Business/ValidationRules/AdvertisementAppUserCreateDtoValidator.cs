using Company.AdvertisementApp.Common.Enums;
using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class AdvertisementAppUserCreateDtoValidator : AbstractValidator<AdvertisementAppUserCreateDto>
{
    public AdvertisementAppUserCreateDtoValidator()
    {
        RuleFor(x=>x.AdvertisementAppUserStatusId).NotEmpty();
        RuleFor(x=>x.AdvertisementId).NotEmpty();
        RuleFor(x=>x.AppUserId).NotEmpty();
        RuleFor(x=>x.CvPath).NotEmpty().WithMessage("Cv file not empty");
        RuleFor(x=>x.EndDate).NotEmpty().When(x=>x.MilitaryStatusId == (int)MilitaryStatusType.Tecilli).WithMessage("Military date not empty");
    }
}