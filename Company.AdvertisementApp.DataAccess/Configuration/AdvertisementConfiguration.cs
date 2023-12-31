﻿using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisement>
{
    public void Configure(EntityTypeBuilder<Advertisement> builder)
    {
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired();
        builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
        builder.Property(x => x.CreatedDate).HasDefaultValueSql("date('now')");
        //Example seed data
        builder.HasData(new Advertisement[]
        {
            new()
            {
                Id = 1,
                Title = "Senior Software Engineer",
                Status = true,
                Description = "Senior Software Engineer",
                CreatedDate = new DateTime(2021,02,02) //"2021-02-02"
                
            },
            new()
            {
                Id = 2,
                Title = "Software Engineer",
                Status = true,
                Description = "Software Engineer",
                CreatedDate = new DateTime(2021,01,02) //"2021-01-02"
            },
            new()
            {
                Id = 3,
                Title = "Junior Software Engineer",
                Status = true,
                Description = "Junior Software Engineer",
                CreatedDate = new DateTime(2021,03,02) //"2021-03-02"
            },
            new()
            {
                Id = 4,
                Title = "Business Analyst",
                Status = true,
                Description = "Business Analyst",
                CreatedDate =  new DateTime(2021,02,04)//"2021-02-04"
            },
            new()
            {
                Id = 5,
                Title = "Business Analyst",
                Status = false,
                Description = "Business Analyst",
                CreatedDate =  new DateTime(2020,02,04)//"2020-02-04"
            },
        });
    }
}