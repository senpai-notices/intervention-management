using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class EngineerTests
    {
        [TestMethod]
        public void InsertEngineer_ValidData_Success()
        {
            const string username = "alex";
            const string name = "Alex";
            const int hours = 3;
            const int cost = 4;
            const int districtId = 5;

            var engineerTableWrapper = new EngineerTableWrapper();

            engineerTableWrapper.InsertEngineer(username, name, hours, cost, districtId);

            var userDataTable = new UserTableWrapper().GetUserByUsername(username);
            var engineerDataTable = engineerTableWrapper.GetEngineerByEngineerUsername(username);


            var userRow = userDataTable.FindByUsername(username);
            var engineerRow = engineerDataTable.FindByEngineerUsername(username);
            Assert.AreEqual(username, userRow.Username);
            Assert.AreEqual(username, engineerRow.EngineerUsername);
            Assert.AreEqual(name, userRow.Name);
            Assert.AreEqual(hours, engineerRow.HoursApprovalLimit);
            Assert.AreEqual(cost, engineerRow.CostApprovalLimit);
            Assert.AreEqual(districtId, engineerRow.DistrictId);

            engineerTableWrapper.DeleteEngineer(username); // this method will also delete the record in User table
        }

        [TestMethod]
        public void InsertEngineers_ValidData_Success()
        {
            const string username1 = "alex";
            const string name1 = "Alex";
            const int hours1 = 3;
            const int cost1 = 4;
            const int districtId1 = 5;

            const string username2 = "bobby";
            const string name2 = "Bobby";
            const int hours2 = 14;
            const int cost2 = 15;
            const int districtId2 = 4;

            var userTableWrapper = new UserTableWrapper();
            var engineerTableWrapper = new EngineerTableWrapper();

            engineerTableWrapper.InsertEngineer(username1, name1, hours1, cost1, districtId1);
            engineerTableWrapper.InsertEngineer(username2, name2, hours2, cost2, districtId2);

            var userDataTable = userTableWrapper.GetUsers();
            var engineerDataTable = engineerTableWrapper.GetEngineers();

            var user1Row = userDataTable.FindByUsername(username1);
            var engineer1Row = engineerDataTable.FindByEngineerUsername(username1);
            Assert.AreEqual(username1, user1Row.Username);
            Assert.AreEqual(username1, engineer1Row.EngineerUsername);
            Assert.AreEqual(name1, user1Row.Name);
            Assert.AreEqual(hours1, engineer1Row.HoursApprovalLimit);
            Assert.AreEqual(cost1, engineer1Row.CostApprovalLimit);
            Assert.AreEqual(districtId1, engineer1Row.DistrictId);

            var user2Row = userDataTable.FindByUsername(username2);
            var engineer2Row = engineerDataTable.FindByEngineerUsername(username2);
            Assert.AreEqual(username2, user2Row.Username);
            Assert.AreEqual(username2, engineer2Row.EngineerUsername);
            Assert.AreEqual(name2, user2Row.Name);
            Assert.AreEqual(hours2, engineer2Row.HoursApprovalLimit);
            Assert.AreEqual(cost2, engineer2Row.CostApprovalLimit);
            Assert.AreEqual(districtId2, engineer2Row.DistrictId);

            engineerTableWrapper.DeleteEngineer(username1);
            engineerTableWrapper.DeleteEngineer(username2);
        }

        public void InsertEngineer_InvalidData_ExceptionThrown()
        { }

        // TODO make custom exception for duplicate username
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void InsertEngineers_DuplicateUsername_ExceptionThrown()
        {
            const string username1 = "alex";
            const string name1 = "Alex";
            const int hours1 = 3;
            const int cost1 = 4;
            const int districtId1 = 5;

            const string username2 = "alex";
            const string name2 = "Bobby";
            const int hours2 = 14;
            const int cost2 = 15;
            const int districtId2 = 4;

            var userTableWrapper = new UserTableWrapper();
            var engineerTableWrapper = new EngineerTableWrapper();

            try
            {
                engineerTableWrapper.InsertEngineer(username1, name1, hours1, cost1, districtId1);
                engineerTableWrapper.InsertEngineer(username2, name2, hours2, cost2, districtId2);
            }

            finally
            {
                engineerTableWrapper.DeleteEngineer(username1);
                engineerTableWrapper.DeleteEngineer(username2);
            }
        }

        [TestMethod]
        public void GetEngineerByUsername_Normal_Success()
        {
            const string username = "joeblogs";
            const string name = "Joe Blogs";
            const int hours = 4;
            const int cost = 5;
            const int districtId = 3;

            var engineerTw = new EngineerTableWrapper();           
            engineerTw.InsertEngineer(username, name, hours, cost, districtId);

            var engineerDt = engineerTw.GetEngineerByEngineerUsername(username);
            var engineerRow = engineerDt.FindByEngineerUsername(username);

            Assert.AreEqual(username, engineerRow.EngineerUsername);
            Assert.AreEqual(hours, engineerRow.HoursApprovalLimit);
            Assert.AreEqual(cost, engineerRow.CostApprovalLimit);
            Assert.AreEqual(districtId, engineerRow.DistrictId);

            engineerTw.DeleteEngineer(username);
        }

        [TestMethod]
        public void UpdateEngineerDistrict_Normal_Success()
        {
            const string username = "joeblogs";
            const string name = "Joe Blogs";
            const int hours = 4;
            const int cost = 5;
            const int districtId = 3;
            const int targetDistrict = 1;

            var engineerTw = new EngineerTableWrapper();
            engineerTw.InsertEngineer(username, name, hours, cost, districtId);
            engineerTw.UpdateEngineerDistrict(username, targetDistrict);

            var engineerDt = engineerTw.GetEngineerByEngineerUsername(username);
            var engineerRow = engineerDt.FindByEngineerUsername(username);

            Assert.AreEqual(username, engineerRow.EngineerUsername);
            Assert.AreEqual(hours, engineerRow.HoursApprovalLimit);
            Assert.AreEqual(cost, engineerRow.CostApprovalLimit);
            Assert.AreEqual(targetDistrict, engineerRow.DistrictId);

            engineerTw.DeleteEngineer(username);
        }
    }
}
