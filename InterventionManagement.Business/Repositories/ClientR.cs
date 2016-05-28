using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class ClientR : IClientR
    {
        private readonly IApplicationDbContext _context;

        public ClientR(IApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Client.ToList();
        }

        public void InsertClient(Client client)
        {
            _context.Client.Add(client);
        }
    }
}
