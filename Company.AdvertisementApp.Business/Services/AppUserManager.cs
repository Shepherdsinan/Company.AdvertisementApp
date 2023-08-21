using AutoMapper;
using Company.AdvertisementApp.Business.Containe;
using Company.AdvertisementApp.Business.Interfaces;
using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.DataAccess.UnitOfWork;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;
using FluentValidation;

namespace Company.AdvertisementApp.Business.Services;

public class AppUserManager : Service<AppUserCreateDto, AppUserUpdateDto, AppUserListDto, AppUser>, IAppUserManager
{
    private readonly IUow _uow;
    private readonly IMapper _mapper;
    private readonly IValidator<AppUserCreateDto> _createDtoValidator;
    private readonly IValidator<AppUserLoginDto> _appUserLoginDtoValidator;

    public AppUserManager(IMapper mapper, IValidator<AppUserCreateDto> createDtoValidator,
        IValidator<AppUserUpdateDto> updateDtoValidator, IUow uow,IValidator<AppUserLoginDto> appUserLoginDtoValidator) : base(mapper, createDtoValidator,
        updateDtoValidator, uow)
    {
        _uow = uow;
        _mapper = mapper;
        _createDtoValidator = createDtoValidator;
        _appUserLoginDtoValidator = appUserLoginDtoValidator;
    }

    public async Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId)
    {
        var validationResult = _createDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
            var user = _mapper.Map<AppUser>(dto);
            await _uow.GetRepository<AppUser>().CreateAsync(user);
            await _uow.GetRepository<AppUserRole>().CreateAsync(new AppUserRole
            {
                AppUser = user,
                AppRoleId = roleId
            });
            await _uow.SaveChangesAsync();
            return new Response<AppUserCreateDto>(ResponseType.Success, dto);
        }

        return new Response<AppUserCreateDto>(dto, validationResult.ConvertToCustomValidationError());
    }

    public async Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto)
    {
        var validationResult = _appUserLoginDtoValidator.Validate(dto);
        if (validationResult.IsValid)
        {
           var user = await _uow.GetRepository<AppUser>()
               .GetByFilterAsync(x => x.UserName == dto.UserName && x.Password == dto.Password);
           if (user !=null)
           {
               var appUserDto = _mapper.Map<AppUserListDto>(user);
               return new Response<AppUserListDto>(ResponseType.Success, appUserDto);
           }
           return new Response<AppUserListDto>(ResponseType.NotFound, "Username and password is not correct");
        }
        return new Response<AppUserListDto>(ResponseType.ValidationError,"Username and password is not empty");
    }
}