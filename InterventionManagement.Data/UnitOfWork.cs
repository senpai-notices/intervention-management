using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;

namespace ASDF.ENETCare.InterventionManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MainContext _context;

        public UnitOfWork(MainContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            // Authors = new AuthorRepository(_context);
        }

        public IClientRepository Clients { get; private set; }
        // public IAuthorRepository Authors { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
