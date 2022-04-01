using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SoccerStats.Core.Interfaces.Repositories;

public interface IRepository<TEntity> where TEntity: class
{
    // RETRIEVE METHODS
    // retrieve item based on primary key
    TEntity Get(int id);
    //retrieve all entries from the repository
    IEnumerable<TEntity> GetAll(int? limit);
    // retrieve the first entry
    TEntity SingleOrdDefault(Expression<Func<TEntity, bool>> predicate);
    // filter items in repository
    IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

    // MODIFY METHODS
    // add item to repository
    void Add(TEntity item);
    // add a collection of items to the repository
    void AddMany(IEnumerable<TEntity> items);
    // remove item from the repository
    void Remove(TEntity item);
    // remove a collection of items from the repository
    void RemoveMany(TEntity items);
}

