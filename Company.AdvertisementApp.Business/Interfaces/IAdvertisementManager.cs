using Company.AdvertisementApp.Common;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IAdvertisementManager : IService<AdvertisementCreateDto,AdvertisementUpdateDto,AdvertisementListDto,Advertisement>
{
    Task<IResponse<List<AdvertisementListDto>>> GetActiveAsync();
}