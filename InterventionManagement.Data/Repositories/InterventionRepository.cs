using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class InterventionRepository : Repository<Intervention>, IInterventionRepository
    {
        public InterventionRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }

        public IEnumerable<Intervention> GetInterventionsOfClient(int clientId)
        {
            return Context.Intervention.Where(
                i => i.ClientId == clientId
                && i.InterventionStateId != 3)
                .OrderByDescending(i => i.DatePerformed)
                .ToList();
        }

        public IEnumerable<Intervention> GetInterventionsOfUser(int userId)
        {
            return Context.Intervention.Where(
                i => i.ProposerId == userId 
                || i.ApproverId == userId)
                .Where(i => i.InterventionStateId != 3)
                .OrderByDescending(i => i.DatePerformed)
                .ToList();
        }

        public IEnumerable<Intervention> GetPendingInterventions(int districtId, int? userHours, decimal? userCost)
        {
            return Context.Intervention.Where(
                i => i.Client.DistrictId == districtId
                && i.InterventionStateId == 1
                && i.Hours <= userHours
                && i.Cost <= userCost)
                .OrderBy(i => i.DatePerformed)
                .ToList();
        }
    }
}
