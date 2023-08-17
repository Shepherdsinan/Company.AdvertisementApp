using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Interfaces;

public interface IGenderManager : IService<GenderCreateDto,GenderUpdateDto,GenderListDto,Gender>
{
    
}