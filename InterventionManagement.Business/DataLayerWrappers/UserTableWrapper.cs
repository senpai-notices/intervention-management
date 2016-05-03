using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class UserTableWrapper
    {
        #region DEPRECATED
        [Obsolete()]
        public void addUser(string username, string name)
        {
            // add a new user
            MainDataSet.UserDataTable users = new UserTableAdapter().GetData();
            MainDataSet.UserRow newUser = users.NewUserRow();

            newUser.Username = username;
            newUser.Name = name;

            users.Rows.Add(newUser);

            // update the database
            new UserTableAdapter().Update(users);
        }
        #endregion

        public MainDataSet.UserDataTable GetUsers()
        {
            return new UserTableAdapter().GetData();
        }
        
        public MainDataSet.UserDataTable GetUserByUsername(string username)
        {
            return new UserTableAdapter().GetDataBy_Username(username);
        }

        public void InsertUser(string username, string name)
        {
            new UserTableAdapter().InsertUser(username, name);

            var dataTable = GetUserByUsername(username);

            if (dataTable.Rows.Count == 0)
            {
                new UserTableAdapter().InsertUser(username, name);
            }
            else
            {
                throw new Exception("Duplicate username.");
            }
        }

        public void DeleteUser(string username)
        {
            new UserTableAdapter().DeleteUser(username);
        }
    }
}
