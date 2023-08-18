using AutoMapper;
using Company.AdvertisementApp.Business.Mappings.AutoMapper;

namespace Company.AdvertisementApp.Business.Helper;

public static class ProfileHelper
{
    public static List<Profile> GetProfiles()
    {
        return new List<Profile>
        {
            new ProvidedServiceProfile(),
            new AdvertisementProfile(),
            new AppUserProfile(),
            new GenderProfile()
        };

    }
}