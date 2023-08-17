using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class ProvidedServiceCreateDtoValidator : AbstractValidator<ProvidedServiceCreateDto>
{
    public ProvidedServiceCreateDtoValidator()
    {
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.ImagePath).NotEmpty();
    }
}