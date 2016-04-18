using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public interface IRepository<T>
    {
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);

        void Add(T entity);
        void AddRange(IEnumerable<T> entities);

        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}