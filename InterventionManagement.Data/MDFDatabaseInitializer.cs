using DbUp;
using System.Reflection;
using System.Configuration;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Data
{
    public class MDFDatabaseInitializer
    {
        public void InitializeDatabaseUsingDbUp()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // DbUp methods to initialise the database using embedded SQL scripts
            var upgrader =
                DeployChanges.To
                    .SqlDatabase(connectionString)
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();
        }
    }
}
