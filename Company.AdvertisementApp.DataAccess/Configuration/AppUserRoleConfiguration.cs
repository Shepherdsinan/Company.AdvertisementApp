using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Company.AdvertisementApp.DataAccess.Configuration;

public class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
{
    public void Configure(EntityTypeBuilder<AppUserRole> builder)
    {
        builder.HasIndex(x=> new { x.AppUserId, x.AppRoleId }).IsUnique();

        builder.HasOne(x => x.AppRole).WithMany(x => x.AppUserRoles).HasForeignKey(x => x.AppRoleId);        
        builder.HasOne(x=>x.AppUser).WithMany(x=>x.AppUserRoles).HasForeignKey(x=>x.AppUserId);
        // Seed Data of Admin
        builder.HasData(new AppUserRole[]
        {
        new()
        {
            Id = 1,
            AppUserId = 1,
            AppRoleId = 1
        },
        new()
        {
            Id = 2,
            AppUserId = 2,
            AppRoleId = 2
        }
        });
    }
}