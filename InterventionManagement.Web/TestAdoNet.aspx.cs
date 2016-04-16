using System;
using System.Configuration;
using System.Data.SqlClient;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Web
{
    public partial class TestAdoNet : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // string connString = DatabaseHelper.ConnectionString;

            DatabaseHelper.ApplicationName = "New name";
            DatabaseHelper.ConnectionTimeout = 42;
            var conn = DatabaseHelper.GetSqlConnection();

        }
    }
}