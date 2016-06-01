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
        ApplicationDbContext Context;
        UserManager<ApplicationUser> UserManager;
        
        public EngineerReportsRepository()
        {
            Context = new ApplicationDbContext();
            UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(Context));
        }

        public IEnumerable<string> GetEngineerIds()
        {
            var EngineerIds = new List<string>();
            var users = new GenericRepository<ApplicationUser>(Context);

            foreach (var user in users.SelectAll())
            {
                if (UserManager.IsInRole(user.Id, "Engineer"))
                {
                    EngineerIds.Add(user.Id);
                }
            }

            return EngineerIds;
        }
    }
}
