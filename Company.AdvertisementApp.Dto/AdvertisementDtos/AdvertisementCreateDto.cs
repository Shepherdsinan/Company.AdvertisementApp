using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AdvertisementCreateDto : IDto
{
    public string Title { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
}