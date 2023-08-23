﻿using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class AdvertisementAppUserCreateDto : IDto
{
    public int AdvertisementId { get; set; }
    public int AppUserId { get; set; }
    public int AdvertisementAppUserStatusId { get; set; } 
    public int MilitaryStatusId { get; set; }
    public DateTime? EndDate { get; set; }
    public int WorkExperience { get; set; }
    public string CvPath { get; set; }
}