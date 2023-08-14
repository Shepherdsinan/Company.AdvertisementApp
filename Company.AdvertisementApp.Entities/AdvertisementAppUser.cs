namespace Company.AdvertisementApp.Entities;

public class AdvertisementAppUser : BaseEntity
{
    public int AdvertisementId { get; set; }
    public Advertisement Advertisement { get; set; } = default!;
    public int AppUserId { get; set; }
    public AppUser AppUser { get; set; } = default!;
    public int AdvertisementAppUserStatusId { get; set; }
    public AdvertisementAppUserStatus? AdvertisementAppUserStatus { get; set; }
    public int MilitaryStatusId { get; set; }
    public MilitaryStatus? MilitaryStatus { get; set; }
    public DateTime? EndDate { get; set; }
    public int WorkExperience { get; set; }
    public string? CvPath { get; set; }
    
}