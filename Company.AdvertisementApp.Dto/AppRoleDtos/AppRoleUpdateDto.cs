using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AppRoleUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Definition { get; set; }
}