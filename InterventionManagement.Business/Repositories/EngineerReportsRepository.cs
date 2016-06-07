/*
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;

namespace ASDF.ENETCare.InterventionManagement.Business.Repositories
{
    public class EngineerReportsRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser, int> _userManager;
        
        public EngineerReportsRepository()
        {
            _context = new ApplicationDbContext();
            _userManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
        }

        public IEnumerable<ApplicationUser> GetEngineers()
        {
            var engineers = new List<ApplicationUser>();
            var users = new Repository<ApplicationUser>(_context);

            foreach (var user in users.SelectAll())
            {
                if (_userManager.IsInRole(user.Id, "Engineer"))
                {
                    engineers.Add(user);
                }
            }

            return engineers;
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
*/
