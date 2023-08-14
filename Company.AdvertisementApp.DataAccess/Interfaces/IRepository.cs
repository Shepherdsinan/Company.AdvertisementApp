using System.Linq.Expressions;
using Company.AdvertisementApp.Common.Enums;
using Company.AdvertisementApp.Entities;

namespace Company.AdvertisementApp.DataAccess.Interfaces;

public interface IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync();
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, TKey>> selector, OrderByType orderByType);

    Task<List<T>> GetAllAsync<TKey>(Expression<Func<T, bool>> filter, Expression<Func<T, TKey>> selector,
        OrderByType orderByType = OrderByType.DESC);

    Task<T> FindAsync(object id);
    Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter, bool asNoTracking = false);
    IQueryable<T> GetQuery();
    void Remove(T entity);
    Task CreateAsync(T entity);
    void Update(T entity, T unchanged);
}