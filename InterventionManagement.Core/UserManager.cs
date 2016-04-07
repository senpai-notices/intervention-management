using System.Collections.Generic;
using System.Linq;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public class UserManager : IManager<User>
    {
        private readonly List<User> _users = new List<User>();

        public List<User> Users => _users;

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(x => x.Username == username);
        }

        public User Login(string username, string password)
        {
            var user = GetUserByUsername(username);

            if (user != null)
            {
                return password == user.Password ? user : null;
            }
            else
            {
                return null;
            }
        }
    }
}
