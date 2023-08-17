using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IAppUserManager : IService<AppUserCreateDto,AppUserUpdateDto,AppUserListDto,AppUser>
{
    
}