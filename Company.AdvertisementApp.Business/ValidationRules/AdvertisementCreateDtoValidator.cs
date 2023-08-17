﻿using Company.AdvertisementApp.Dto;
using FluentValidation;

namespace Company.AdvertisementApp.Business.ValidationRules;

public class AdvertisementCreateDtoValidator : AbstractValidator<AdvertisementCreateDto>
{
    public AdvertisementCreateDtoValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }
}