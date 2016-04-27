using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers
{
    public class DatabaseInitializer
    {
        // wrapper around the DbUpHelper class, to separate the Web layer from the Data layer
        public void InitializeDatabase()
        {
            new DbUpHelper().InitializeDatabase();
        }
    }
}
