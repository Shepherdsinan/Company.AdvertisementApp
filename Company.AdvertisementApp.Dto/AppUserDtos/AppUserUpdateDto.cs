using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AppUserUpdateDto : IUpdateDto
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public int GenderId { get; set; }
}