using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public interface IGenericRepository<TEntity>: IDisposable where TEntity:class
    {
        IEnumerable<TEntity> SelectAll();

        TEntity GetById(object id);

        void Insert(TEntity obj);

        void Update(TEntity obj);

        void Delete(object id);

        void Save();
    }
}
