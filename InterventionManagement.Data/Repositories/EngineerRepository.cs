using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASDF.ENETCare.InterventionManagement.Business;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Data.Repositories
{
    public class EngineerRepository
    {
        private ApplicationDbContext Context;
        private UserManager<ApplicationUser, int> UsersManager;

        public EngineerRepository()
        {
            Context = new ApplicationDbContext();
            UsersManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
        }

        public IEnumerable<ApplicationUser> GetEngineers()
        {
            var Engineers = new List<ApplicationUser>();
            
            foreach (var user in UsersManager.Users)
            {
                if (UsersManager.IsInRole(user.Id, "Engineer"))
                {
                    Engineers.Add(user);
                }
            }

            return Engineers;
        }
    }
}
