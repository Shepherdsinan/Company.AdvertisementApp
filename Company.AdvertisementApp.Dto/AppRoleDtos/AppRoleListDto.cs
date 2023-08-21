using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AppRoleListDto : IDto
{
    public string Id { get; set; }
    public string Definition { get; set; }
}