using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class GenderCreateDtoValidator : AbstractValidator<GenderCreateDto>
{
    public GenderCreateDtoValidator()
    {
        RuleFor(x => x.Definition).NotEmpty();
    }
}