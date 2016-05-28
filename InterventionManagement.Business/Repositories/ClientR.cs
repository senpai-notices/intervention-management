using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class ClientR
    {
        private readonly ApplicationDbContext _context;

        public ClientR(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Client.ToList();
        }
    }
}
