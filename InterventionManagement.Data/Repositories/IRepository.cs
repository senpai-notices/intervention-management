using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> SelectAll();

        TEntity GetById(int id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(int id);
    }
}
