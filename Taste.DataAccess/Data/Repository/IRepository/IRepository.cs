using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Taste.DataAccess.Data.Repository.IRepository
{
    // Generic Class T for all the object (eg. Category, Order ...)
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        // all data
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null
        );
        
        // one record (one object)
        T GetFirstOrDefault(
           Expression<Func<T, bool>> filter = null,
           string includeProperties = null
        );

        void Add(T entity);

        void Remove(int id);
        void Remove(T entity);
        
        void RemoveRange(IEnumerable<T> entity);
        //
    }
}