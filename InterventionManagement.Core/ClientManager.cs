using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    // Should this be static?
    public static class ClientManager
    {
        private static readonly List<Client> _clients = new List<Client>();

        public static List<Client> Clients => _clients;

        public static void Add(Client client)
        {
            _clients.Add(client);
        }
    }
}
