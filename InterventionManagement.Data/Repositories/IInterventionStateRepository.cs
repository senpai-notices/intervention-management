using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public interface IInterventionStateRepository : IRepository<InterventionState>
    {
        IEnumerable<InterventionState> GetRemainingInterventionStates(InterventionState currenState);
    }
}
