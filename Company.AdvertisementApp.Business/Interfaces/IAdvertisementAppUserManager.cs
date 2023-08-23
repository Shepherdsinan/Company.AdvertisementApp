using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.Dto;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IAdvertisementAppUserManager
{
    Task<IResponse<AdvertisementAppUserCreateDto>> CreateAsync(AdvertisementAppUserCreateDto dto);
}