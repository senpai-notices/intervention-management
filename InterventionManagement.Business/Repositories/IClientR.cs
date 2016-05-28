using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public interface IClientR
    {
        IEnumerable<Client> GetClients();

        void InsertClient(Client client);
    }
}