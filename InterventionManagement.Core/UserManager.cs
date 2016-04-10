using System.Collections.Generic;
using System.Linq;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Core
{
    public static class UserManager
    {
        private static readonly List<User> _users = new List<User>();

        public static List<User> Users => _users;

        public static void Add(User user)
        {
            _users.Add(user);
        }

        public static User GetUserByUsername(string username)
        {
            return _users.FirstOrDefault(u => u.Username == username);
        }

        public static User GetUserById(int userId)
        {
            return _users.FirstOrDefault(u => u.UserId == userId);
        }

        public static User Login(string username, string password)
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
