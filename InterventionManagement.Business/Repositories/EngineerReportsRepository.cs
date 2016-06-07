using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class EngineerReportsRepository
    {
        private ApplicationDbContext Context;
        private UserManager<ApplicationUser> UserManager;
        
        public EngineerReportsRepository()
        {
            Context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }

        public IEnumerable<ApplicationUser> GetEngineers()
        {
            var Engineers = new List<ApplicationUser>();
            var users = new GenericRepository<ApplicationUser>(Context);

            foreach (var user in users.SelectAll())
            {
                if (UserManager.IsInRole(user.Id, "Engineer"))
                {
                    Engineers.Add(user);
                }
            }

            return Engineers;
        }

        //public IEnumerable<Intervention> GetCompletedInterventionsForEngineer(ApplicationUser engineer)
        //{
        //    var interventionRepository = new GenericRepository<Intervention>(Context);
        //    var interventions = interventionRepository.SelectAll();
            
        //    foreach (var intervention in interventions)
        //    {
        //        if (intervention.ProposerId == engineer.Id && intervention.InterventionStateId == 4)
        //        {

        //        }
        //    }
        //}
    }
}
