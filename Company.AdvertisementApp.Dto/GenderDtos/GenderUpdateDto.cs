using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class GenderUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string Definition { get; set; }
}