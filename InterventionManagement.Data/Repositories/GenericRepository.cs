using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;
        private bool _disposed = false;

        public GenericRepository(ApplicationDbContext appContext)
        {
            _context = appContext;
            this._dbSet = appContext.Set<TEntity>();
        }


        public IEnumerable<TEntity> SelectAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity obj)
        {
            _dbSet.Add(obj);
        }

        public void Update(TEntity obj)
        {
            _dbSet.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }

        public void Delete(object id)
        {
            TEntity existing = _dbSet.Find(id);
            _dbSet.Remove(existing);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

       
        public void Dispose()
        {
            if (!this._disposed)
            {             
               _context.Dispose();               
            }
            this._disposed = true;
        }
    }
}
