using AutoMapper;
using Company.AdvertisementApp.Dto;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.Business.Mappings.AutoMapper;

public class MilitaryStatusProfile : Profile
{
    public MilitaryStatusProfile()
    {
        CreateMap<MilitaryStatus, MilitaryStatusListDto>().ReverseMap();
    }
}