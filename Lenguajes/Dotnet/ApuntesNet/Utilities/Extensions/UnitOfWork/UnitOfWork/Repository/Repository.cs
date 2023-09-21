using System.Linq.Expressions;
using System.Reflection;
using Garciss.UnitOfWork.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Garciss.UnitOfWork.Repository;

internal class Repository<T> : BaseRepository<T>, IRepository<T> where T : class
{
    public Repository(DbContext context) : base(context)
    {
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Add(params T[] entities)
    {
        _dbSet.AddRange(entities);
    }


    public void Add(IEnumerable<T> entities)
    {
        _dbSet.AddRange(entities);
    }


    public void Delete(T entity)
    {
        var existing = _dbSet.Find(entity);
        if (existing != null)
        {
            _dbSet.Remove(existing);
        }
    }


    public void Delete(object id)
    {
        var typeInfo = typeof(T).GetTypeInfo();
        var key = _dbContext.Model.FindEntityType(typeInfo).FindPrimaryKey().Properties.FirstOrDefault();
        var property = typeInfo.GetProperty(key?.Name);
        if (property != null)
        {
            var entity = Activator.CreateInstance<T>();
            property.SetValue(entity, id);
            _dbContext.Entry(entity).State = EntityState.Deleted;
        }
        else
        {
            var entity = _dbSet.Find(id);
            if (entity != null)
            {
                Delete(entity);
            }
        }
    }

    public void Delete(params T[] entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Delete(IEnumerable<T> entities)
    {
        _dbSet.RemoveRange(entities);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Update(params T[] entities)
    {
        _dbSet.UpdateRange(entities);
    }


    public void Update(IEnumerable<T> entities)
    {
        _dbSet.UpdateRange(entities);
    }

    public void Dispose()
    {
        _dbContext?.Dispose();
    }

    public virtual int Count(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return _dbSet.Count();
        }
        else
        {
            return _dbSet.Count(predicate);
        }
    }

    public virtual long LongCount(Expression<Func<T, bool>> predicate = null)
    {
        if (predicate == null)
        {
            return _dbSet.LongCount();
        }
        else
        {
            return _dbSet.LongCount(predicate);
        }
    }

    public virtual K Max<K>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, K>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.Max(selector);
        }
        else
        {
            return _dbSet.Where(predicate).Max(selector);
        }
    }

    public virtual K Min<K>(Expression<Func<T, bool>> predicate = null, Expression<Func<T, K>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.Min(selector);
        }
        else
        {
            return _dbSet.Where(predicate).Min(selector);
        }
    }

    public virtual decimal Average(Expression<Func<T, bool>> predicate = null, Expression<Func<T, decimal>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.Average(selector);
        }
        else
        {
            return _dbSet.Where(predicate).Average(selector);
        }
    }

    public virtual decimal Sum(Expression<Func<T, bool>> predicate = null, Expression<Func<T, decimal>> selector = null)
    {
        if (predicate == null)
        {
            return _dbSet.Sum(selector);
        }
        else
        {
            return _dbSet.Where(predicate).Sum(selector);
        }
    }

    public bool Exists(Expression<Func<T, bool>> selector = null)
    {
        if (selector == null)
        {
            return _dbSet.Any();
        }
        else
        {
            return _dbSet.Any(selector);
        }
    }
}
