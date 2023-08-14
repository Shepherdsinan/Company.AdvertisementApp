using Company.AdvertisementApp.DataAccess.Interfaces;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.DataAccess.UnitOfWork;

public interface IUow
{
    IRepository<T> GetRepository<T>() where T : BaseEntity;
    Task SaveChangesAsync();
}