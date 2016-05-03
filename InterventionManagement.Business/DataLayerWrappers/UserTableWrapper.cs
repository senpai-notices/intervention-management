using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class UserTableWrapper
    {
        public void addUser(string username, string name)
        {
            MainDataSet.UserDataTable users = new UserTableAdapter().GetData();
            MainDataSet.UserRow newUser = users.NewUserRow();

            newUser.Username = username;
            newUser.Name = name;

            users.Rows.Add(newUser);

            new UserTableAdapter().Update(users);
        }
    }
}
