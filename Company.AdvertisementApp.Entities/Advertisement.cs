namespace Company.AdvertisementApp.Entities;

public class Advertisement : BaseEntity
{
    public string? Title { get; set; }
    public bool Status { get; set; }
    public string? Description { get; set; }
    public string? CreateDate { get; set; }
    public List<AdvertisementAppUser>? AdvertisementAppUsers { get; set; }
}