﻿using Company.AdvertisementApp.Dto.Interfaces;

namespace Company.AdvertisementApp.Dto;

public class ProvidedServiceListDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime CreateDate { get; set; }
}