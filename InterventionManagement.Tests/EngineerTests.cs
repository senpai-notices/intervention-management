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
            const string username = "alex";
            const string name = "Alex";
            const int hours = 13;
            const int cost = 24;
            const int districtId = 5;

            var engineerTableWrapper = new EngineerTableWrapper();
            engineerTableWrapper.InsertEngineer(username, name, hours, cost, districtId);

            var engineerDataTable = engineerTableWrapper.GetEngineerByEngineerUsername(username);

            Assert.AreEqual(engineerDataTable.FindByEngineerUsername(username).EngineerUsername, username);
            Assert.AreEqual(engineerDataTable.FindByEngineerUsername(username).HoursApprovalLimit, hours);
            Assert.AreEqual(engineerDataTable.FindByEngineerUsername(username).CostApprovalLimit, cost);

            engineerTableWrapper.DeleteEngineer(username);
        }

        public void InsertEngineers_ValidData_Success()
        {
            
        }

        public void InsertEngineer_InvalidData_Exception()
        { }

        public void InsertEngineer_DuplicateUsername_Exception() { }
    }
}
