using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AdvertisementListDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool Status { get; set; }
    public string Description { get; set; }
}