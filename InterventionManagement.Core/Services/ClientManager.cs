using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.DataClasses;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core.Services
{
    // Should this be static? Static classes cannot implement interfaces
    public static class ClientManager
    {
        private static readonly List<Client> _clients = new List<Client>();

        public static List<Client> Clients => _clients;

        public static void Add(Client client)
        {
            _clients.Add(client);
        }

        public static Client GetClientById(int clientId)
        {
            return _clients.FirstOrDefault(c => c.ClientId == clientId);
        }
    }
}
