namespace Company.AdvertisementApp.Entities;

public class AppUser : BaseEntity
{
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string? PhoneNumber { get; set; }
    public int GenderId { get; set; }
    public Gender? Gender { get; set; }
    public List<AppUserRole> AppUserRoles { get; set; } = new();
    public List<AdvertisementAppUser>? AdvertisementAppUsers { get; set; }
}