using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web.Experimental
{
    public partial class TestAdoNet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string connString = DatabaseHelper.ConnectionString;

            // these two values override the default values, just for testing.
            DatabaseHelper.ApplicationName = "New name";
            DatabaseHelper.ConnectionTimeout = 42;

            // minimum requirement
            var conn = DatabaseHelper.GetSqlConnection();

        }

        protected void LinkButtonGetUser_Click(object sender, EventArgs e)
        {
            try
            {
                var userRepo = new Data.UserRepository();
                var user = userRepo.GetUser(int.Parse(TextboxUserId.Text));

                TextboxUsername.Text = user.Username;
                TextBoxPassword.Text = user.Password;
                TextBoxName.Text = user.Name;
            }
            catch { }
        }
    }
}