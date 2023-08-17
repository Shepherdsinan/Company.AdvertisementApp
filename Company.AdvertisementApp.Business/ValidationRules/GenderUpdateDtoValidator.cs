using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class GenderUpdateDtoValidator : AbstractValidator<GenderUpdateDto>
{
    public GenderUpdateDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Definition).NotEmpty();
    }
}