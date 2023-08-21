using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class AdvertisementAppUserStatusConfiguration : IEntityTypeConfiguration<AdvertisementAppUserStatus>
{
    public void Configure(EntityTypeBuilder<AdvertisementAppUserStatus> builder)
    {
        builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
        builder.HasData(new AdvertisementAppUserStatus[]
        {
            new()
            {
                Id = 1,
                Definition = "Başvurdu"
            },
            new()
            {
                Id = 2,
                Definition = "Mülakata Çağrıldı"
            },
            new()
            {
                Id = 3,
                Definition = "Olumlu Sonuçlandı"
            },
            new()
            {
                Id = 4,
                Definition = "Olumsuz Sonuçlandı"
            }
        });
    }
}