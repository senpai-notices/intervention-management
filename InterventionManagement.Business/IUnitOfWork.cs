using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;

namespace ASDF.ENETCare.InterventionManagement.Business
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Client { get; }
        // IAuthorRepository Authors { get; }
        int Complete();
    }
}
