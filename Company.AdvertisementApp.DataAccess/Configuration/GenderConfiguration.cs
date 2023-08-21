using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class GenderConfiguration : IEntityTypeConfiguration<Gender>
{
    public void Configure(EntityTypeBuilder<Gender> builder)
    {
        builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
        builder.HasData(new Gender[]
        {
            new()
            {
                Definition = "Erkek",
                Id = 1
                
            },
            new()
            {
                Definition = "Kadın",
                Id = 2
            }
        });
    }
}