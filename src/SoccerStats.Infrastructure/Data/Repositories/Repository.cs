using Microsoft.EntityFrameworkCore;
using SoccerStats.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Infrastructure.Data.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
{
    protected readonly DbContext _context;
    protected readonly DbSet<TEntity> _entity;

    public Repository(DbContext context)
    {
        this._context = context;
        this._entity = context.Set<TEntity>();
    }


    // adds an item to the repository
    public void Add(TEntity item)
    {
        this._entity.Add(item);
    }

    // adds a collection of items to the repository
    public void AddMany(IEnumerable<TEntity> items)
    {
        this._entity.AddRange(items);
    }

    // locates records in the repository that match the condition provided
    public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
    {
        return this._entity.Where(predicate).ToList();
    }

    // locates the record in the repository that matches the primary key provided
    public TEntity Get(int id)
    {
        return this._entity.Find(id);
    }

    // returns all records in the repository up to the limit provided
    public IEnumerable<TEntity> GetAll(int? limit = null)
    {
        if (limit is null)
        {
            return this._entity.ToList();
        }
        else
        {
            return this._entity.Take(limit.GetValueOrDefault()).ToList();
        }
    }

    // removes record from the repository
    public void Remove(TEntity item)
    {
        this._entity.Remove(item);
    }

    // removes a collection of records from the repository
    public void RemoveMany(TEntity items)
    {
        this._entity.RemoveRange(items);
    }

    // returns the first record that matches the condition provided
    public TEntity SingleOrdDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return this._entity.SingleOrDefault(predicate);
    }
}

