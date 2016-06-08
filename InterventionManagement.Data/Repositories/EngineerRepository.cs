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
    public class UserRepository
    {
        private ApplicationDbContext Context;
        private readonly UserManager<ApplicationUser, int> _usersManager;

        public UserRepository()
        {
            Context = new ApplicationDbContext();
            _usersManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
        }

        public IEnumerable<ApplicationUser> GetEngineers()
        {
            var engineers = new List<ApplicationUser>();
            
            foreach (var user in _usersManager.Users.ToArray())
            {
                if (_usersManager.IsInRole(user.Id, "Engineer"))
                {
                    engineers.Add(user);
                }
            }
            return engineers;
        }
        public IEnumerable<ApplicationUser> GetManagers()
        {
            var managers = new List<ApplicationUser>();

            foreach (var user in _usersManager.Users.ToArray())
            {
                if (_usersManager.IsInRole(user.Id, "Manager"))
                {
                    managers.Add(user);
                }
            }
            return managers;
        }

        public IEnumerable<ApplicationUser>GetManagersAndEngineers()
        {
            var employees = new List<ApplicationUser>();

            employees.AddRange(GetEngineers());
            employees.AddRange(GetManagers());
            return employees;
        }
    }
}
