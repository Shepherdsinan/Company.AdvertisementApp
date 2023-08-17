using AutoMapper;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class AppUserManager : Service<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>,IAppUserManager
{
    public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator, IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow) : base(mapper, createDtoValidator, updateDtoValidator, uow)
    {
    }
}