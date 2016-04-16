using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Helpers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Data
{
    public class SimpleUser
    {
        public int UserId { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }

        public void Load(SqlDataReader reader)
        {
            UserId = int.Parse(reader["UserId"].ToString());
            Username = reader["Username"].ToString();
            Password = reader["Password"].ToString();
            Name = reader["Name"].ToString();

        }
    }
}
