using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class GenderManager : Service<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>,IGenderManager
{
    public GenderManager(IMapper mapper, IValidator<GenderCreateDto> createDtoValidator, IValidator<GenderUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
    {
    }
}