using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext Context;

        public Repository(ApplicationDbContext appContext)
        {
            Context = appContext;
        }

        public IEnumerable<TEntity> SelectAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity obj)
        {
            Context.Set<TEntity>().Add(obj);
        }

        public void Update(TEntity obj)
        {
            Context.Set<TEntity>().Attach(obj);
            Context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var existing = Context.Set<TEntity>().Find(id);
            Context.Set<TEntity>().Remove(existing);
        }

        public int Save()
        {
            return Context.SaveChanges();
        }
    }
}
