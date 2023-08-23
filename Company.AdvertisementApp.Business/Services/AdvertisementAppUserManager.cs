using AutoMapper;
using Company.AdvertisementApp.Business.Containe;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class AdvertisementAppUserManager : IAdvertisementAppUserManager
{
    private readonly IUow _uow;
    private readonly IValidator<AdvertisementAppUserCreateDto> _createDtoValidator;
    private readonly IMapper _mapper;
    
    public AdvertisementAppUserManager(IUow uow, IValidator<AdvertisementAppUserCreateDto> createDtoValidator, IMapper mapper)
    {
        _uow = uow;
        _createDtoValidator = createDtoValidator;
        _mapper = mapper;
    }

    public async Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto)
    {
       var result = _createDtoValidator.Validate(dto);
       if (result.IsValid)
       {
           var control = await _uow.GetRepository<AdvertisementAppUser>().GetByFilterAsync(x =>
               x.AppUserId == dto.AppUserId && x.AdvertisementId == dto.AdvertisementId);
           if (control == null)
           {
               var createdAdvertisementAppUser = _mapper.Map<AdvertisementAppUser>(dto);
               await _uow.GetRepository<AdvertisementAppUser>().CreateAsync(createdAdvertisementAppUser);
               await _uow.SaveChangesAsync();
               return new Response<AdvertisementAppUserCreateDto>(ResponseType.Success, dto);
           }

           List<CustomValidationError> errors = new List<CustomValidationError>
           {
               new CustomValidationError
               {
                   ErrorMessage = "Daha önce bu ilana başvurdunuz",
                   PropertyName = ""
               }
           };
           return new Response<AdvertisementAppUserCreateDto>(dto, errors);
       }

       return new Response<AdvertisementAppUserCreateDto>(dto, result.ConvertToCustomValidationError());
    }
    
}