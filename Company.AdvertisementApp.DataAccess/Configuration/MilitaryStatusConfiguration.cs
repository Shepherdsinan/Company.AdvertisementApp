using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class MilitaryStatusConfiguration : IEntityTypeConfiguration<MilitaryStatus>
{
    public void Configure(EntityTypeBuilder<MilitaryStatus> builder)
    {
        builder.Property(x => x.Definition).HasMaxLength(300).IsRequired();
    }
}