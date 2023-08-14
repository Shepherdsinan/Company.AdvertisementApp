﻿using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class ProvidedServiceConfiguration : IEntityTypeConfiguration<ProvidedService>
{
    public void Configure(EntityTypeBuilder<ProvidedService> builder)
    {
        builder.Property(x => x.Description).HasColumnType("ntext").IsRequired();
        builder.Property(x => x.ImagePath).HasMaxLength(500).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(300).IsRequired();
        builder.Property(x => x.CreateDate).HasDefaultValueSql("getdate()");
    }
}