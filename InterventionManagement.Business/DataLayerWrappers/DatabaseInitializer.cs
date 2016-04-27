using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class DatabaseInitializer
    {
        public void InitializeDatabase()
        {
            new DbUpHelper().InitializeDatabase();
        }
    }
}
