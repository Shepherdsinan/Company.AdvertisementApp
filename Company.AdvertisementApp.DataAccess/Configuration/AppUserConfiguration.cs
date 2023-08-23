using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.Property(x=>x.FirstName).HasMaxLength(300).IsRequired();
        builder.Property(x=>x.SurName).HasMaxLength(300).IsRequired();
        builder.Property(x=>x.UserName).HasMaxLength(300).IsRequired();
        builder.Property(x=>x.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(x=>x.Password).HasMaxLength(50).IsRequired();
        
        builder.HasOne(x=>x.Gender).WithMany(x=>x.AppUsers).HasForeignKey(x=>x.GenderId);
        builder.HasData(new AppUser[]
        {
            new()
            {
                Id=1,
                FirstName = "Admin",
                SurName = "Admin",
                UserName = "Admin",
                Password = "Admin",
                GenderId = 1,
                PhoneNumber = "1234567890"
            },
            new()
            {
                Id = 2,
                FirstName = "Member",
                SurName = "Member",
                UserName = "Member",
                Password = "Member",
                GenderId = 2,
                PhoneNumber = "1234567890"
            }
        });
    }
}