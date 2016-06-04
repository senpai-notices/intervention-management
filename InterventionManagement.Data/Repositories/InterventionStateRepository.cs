using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class InterventionStateRepository : Repository<InterventionState>, IInterventionStateRepository
    {
        public InterventionStateRepository(ApplicationDbContext appContext) : base(appContext)
        {
        }

        public IEnumerable<InterventionState> GetRemainingInterventionStates(InterventionState currenState)
        {
            return Context.InterventionState.Where(
                i => i.InterventionStateId != currenState.InterventionStateId
                ).ToList();
        }
    }
}
