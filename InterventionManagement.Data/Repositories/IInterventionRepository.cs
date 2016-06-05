using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public interface IInterventionRepository : IRepository<Intervention>
    {
        IEnumerable<Intervention> GetInterventionsOfClient(int clientId);

        IEnumerable<Intervention> GetInterventionsOfUser(int userId);

        IEnumerable<Intervention> GetPendingInterventions(int districtId, int? userHours, decimal? userCost);
    }
}
