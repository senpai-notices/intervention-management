using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public interface IClientRepository: IRepository<Client>
    {
        IEnumerable<Client> GetClientsOfDistrict(int districtId);

        //IEnumerable<Client> GetPreviousClients(int currentUserId);
    }
}
