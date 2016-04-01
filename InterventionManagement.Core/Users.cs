using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class Users
    {
        private readonly List<User> _users = new List<User>();


        // public List<User> Users { get { return _users; } }
        // List cannot be same name as enclosing class
        // So I will make a manual getter instead.

        public List<User> GetUsers()
        {
            return _users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public void Login(string username, string password)
        {
            
        }

    }
}
