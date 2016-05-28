using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity:class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

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
    }
}
