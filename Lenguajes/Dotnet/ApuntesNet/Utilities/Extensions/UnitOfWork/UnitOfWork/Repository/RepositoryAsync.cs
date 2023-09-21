using System.Linq.Expressions;
using Garciss.UnitOfWork.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Garciss.UnitOfWork.Repository;

internal class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
{
    protected readonly DbContext _dbContext;
    protected readonly DbSet<T> _dbSet;

    public RepositoryAsync(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public DbContext GetContext()
    {
        return _dbContext;
    }

    public Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, bool disableTracking = true,
        IQueryable<T> queryCustom = null,
        bool ignoreQueryFilter = false)
    {
        IQueryable<T> query;
        if (queryCustom == null)
        {
            var sql = string.Empty;
            if (!string.IsNullOrEmpty(sql))
            {
                query = _dbSet.FromSqlRaw(sql);
            }
            else
            {
                query = _dbSet;
            }
        }
        else
        {
            query = queryCustom;
        }
        if (disableTracking)
        {
            query = query.AsNoTracking();
        }

        if (include != null)
        {
            query = include(query);
        }

        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        if (ignoreQueryFilter)
        {
            query = query.IgnoreQueryFilters();
        }

        return orderBy != null ? orderBy(query).SingleOrDefaultAsync() : query.SingleOrDefaultAsync();
    }

    public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        var addEntity = await _dbSet.AddAsync(entity, cancellationToken);
        return addEntity.Entity;
    }

    public Task AddAsync(IEnumerable<T> entities,
        CancellationToken cancellationToken = default)
    {
        return _dbSet.AddRangeAsync(entities, cancellationToken);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public virtual Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return _dbSet.CountAsync();
        }
        else
        {
            return _dbSet.CountAsync(predicate);
        }
    }

    public virtual Task<long> LongCountAsync(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return _dbSet.LongCountAsync();
        }
        else
        {
            return _dbSet.LongCountAsync(predicate);
        }
    }

    public virtual Task<K> MaxAsync<K>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, K>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.MaxAsync(selector);
        }
        else
        {
            return _dbSet.Where(predicate).MaxAsync(selector);
        }
    }

    public virtual Task<K> MinAsync<K>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, K>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.MinAsync(selector);
        }
        else
        {
            return _dbSet.Where(predicate).MaxAsync(selector);
        }
    }

    public virtual Task<decimal> AverageAsync(Expression<Func<T, bool>> predicate = null, Expression<Func<T, decimal>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.AverageAsync(selector);
        }
        else
        {
            return _dbSet.Where(predicate).AverageAsync(selector);
        }
    }

    public virtual Task<decimal> SumAsync(Expression<Func<T, bool>> predicate = null, Expression<Func<T, decimal>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.SumAsync(selector);
        }
        else
        {
            return _dbSet.Where(predicate).SumAsync(selector);
        }
    }

    public Task<bool> ExistsAsync(Expression<Func<T, bool>> selector = null)
    {
        if (selector == null)
        {
            return _dbSet.AnyAsync();
        }
        else
        {
            return _dbSet.AnyAsync(selector);
        }
    }

    public IAsyncEnumerable<T> GetAsync(Expression<Func<T, bool>> predicate)
    {
        return _dbSet.Where(predicate).AsAsyncEnumerable();
    }
}
