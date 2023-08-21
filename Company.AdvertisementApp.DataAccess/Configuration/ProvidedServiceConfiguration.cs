using Company.AdvertisementApp.Entities;
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
        builder.Property(x => x.CreateDate).HasDefaultValueSql("date('now')");
        //Example Seed Data
        builder.HasData(new ProvidedService[]
        {
            new()
            {
                Id = 1,
                Title = "Masaüstü Uygulamalar",
                ImagePath = "/images/01.jpg",
                Description = "Masaüstü Uygulamalar",
                CreateDate = new DateTime(2023,08,16)
            },
            new()
            {
                Id = 2,
                Title = "Web Uygulamalar",
                ImagePath = "/images/02.jpg",
                Description = "Web Uygulamalar",
                CreateDate = new DateTime(2021,05,25)
            },
            new()
            {
                Id = 3,
                Title = "Mobil Uygulamalar",
                ImagePath = "/images/03.jpg",
                Description = "Mobil Uygulamalar",
                CreateDate = new DateTime(2021,04,05)
            }
        });
    }
}