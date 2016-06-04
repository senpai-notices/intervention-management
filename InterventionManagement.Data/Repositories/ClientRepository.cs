using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }

        public IEnumerable<Client> GetClientsOfDistrict(int districtId)
        {
            return Context.Client.Where(c => c.DistrictId == districtId).ToList();
        }

/*        public IEnumerable<Client> GetPreviousClients(int currentUserId)
        {
            return Context.Intervention.Where(i => i.ApproverId == currentUserId 
            || i.ProposerId == currentUserId).Select(i => i.Client).ToList();
        }*/
    }
}
