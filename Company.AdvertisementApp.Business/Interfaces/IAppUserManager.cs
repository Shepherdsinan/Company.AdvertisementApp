using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IAppUserManager : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
{
    Task<IResponse<AppUserCreateDto>> CreateWithRoleAsync(AppUserCreateDto dto, int roleId);
    Task<IResponse<AppUserListDto>> CheckUserAsync(AppUserLoginDto dto);
}