using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class EngineerTests
    {
        [TestMethod]
        public void InsertEngineer_ValidData_Success()
        {
            var username = "alex";
            var name = "Alex";
            var hours = 3;
            var cost = 4;
            var districtId = 5;

            var engineerTableWrapper = new EngineerTableWrapper();
            engineerTableWrapper.InsertEngineer(username, name, hours, cost, districtId);

            var engineerDataTable = engineerTableWrapper.GetEngineerByEngineerUsername(username);

            Assert.AreEqual(engineerDataTable.FindByEngineerUsername(username).EngineerUsername, username);

            engineerTableWrapper.DeleteEngineer(username);
        }

        public void InsertEngineers_ValidData_Success() { }

        public void InsertEngineer_InvalidData_Exception()
        { }

        public void InsertEngineer_DuplicateUsername_Exception() { }
    }
}
