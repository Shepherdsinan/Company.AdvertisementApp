using System.Linq.Expressions;
using Company.AdvertisementApp.DataAccess.Contexts;
using Company.AdvertisementApp.DataAccess.Interfaces;
using Company.AdvertisementApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace Company.AdvertisementApp.DataAccess.Repositories;

public class Repository<T> : IRepository<T> where T : BaseEntity
{
    private readonly AdvertisementContext _context;

    public Repository(AdvertisementContext context)
    {
        _context = context;
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync();
    }
    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
    {
        return await _context.Set<T>().Where(filter).ToListAsync();
    }
    public async Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector)
    {
        return await _context.Set<T>().OrderBy(selector).ToListAsync();
    }
}