using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using Xunit;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    public class EngineerTests
    {
        [Theory]
        [InlineData("tester", "Tester Smith", 3, 4, 1)]
        [InlineData("alex", "Alex Smith", 0, 0, 2)]
        public void Meth1(string username, string name, int hours, int cost, int districtId)
        {
            var engineerTableWrapper = new EngineerTableWrapper();
            engineerTableWrapper.InsertEngineer(username, name, hours, cost, districtId);

            var engineerDataTable = engineerTableWrapper.GetEngineerByEngineerUsername(username);

            Assert.Equal(engineerDataTable.FindByEngineerUsername(username).EngineerUsername, username);

            engineerTableWrapper.DeleteEngineer(username);
        }
    }
}
