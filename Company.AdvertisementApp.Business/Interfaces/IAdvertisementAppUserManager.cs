using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.Common.Enums;
using Company.AdvertisementApp.Dto;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IAdvertisementAppUserManager
{
    Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
    Task<List<AdvertisementAppUserListDto>> GetListAsync(AdvertisementAppUserStatusType type);
    Task SetStatusAsync(int advertisementAppUserId, AdvertisementAppUserStatusType type);
}