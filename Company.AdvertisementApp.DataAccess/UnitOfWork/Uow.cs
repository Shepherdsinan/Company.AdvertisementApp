using Company.AdvertisementApp.DataAccess.Contexts;
using Company.AdvertisementApp.DataAccess.Interfaces;
using Company.AdvertisementApp.DataAccess.Repositories;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.DataAccess.UnitOfWork;

public class Uow
{
    private readonly AdvertisementContext _context;

    public Uow(AdvertisementContext context)
    {
        _context = context;
    }
    
    public IRepository<T> GetRepository<T>() where T : BaseEntity
    {
        return new Repository<T>(_context);
    } 
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}