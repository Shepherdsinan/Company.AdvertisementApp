namespace Company.AdvertisementApp.Dto;

public class AdvertisementAppUserListDto
{
    public int Id { get; set; }
    public int AdvertisementId { get; set; }
    public AdvertisementListDto Advertisement { get; set; } = default!;
    public int AppUserId { get; set; }
    public AppUserListDto AppUser { get; set; } = default!;
    public int AdvertisementAppUserStatusId { get; set; }
    public AdvertisementAppUserStatusListDto? AdvertisementAppUserStatus { get; set; }
    public int MilitaryStatusId { get; set; }
    public MilitaryStatusListDto? MilitaryStatus { get; set; }
    public DateTime? EndDate { get; set; }
    public int WorkExperience { get; set; }
    public string? CvPath { get; set; }
}