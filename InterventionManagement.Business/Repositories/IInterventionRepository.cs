using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public interface IInterventionRepository : IDisposable
    {
        IEnumerable<Intervention> GetInterventions();

        Intervention GetInterventionById(int interventionId);

        void InsertIntervention(Intervention intervention);

        void DeleteIntervention(int interventionId);

        void UpdateIntervention(Intervention intervention);

        void Save();
    }
}
