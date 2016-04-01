using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void CreateNewAccountant()
        {
            var sut = new Accountant(1, "alextan", "123456", "Alex Tan");

            Assert.AreEqual(sut.UserID, 1);
            Assert.AreEqual(sut.Username, "alextan");
            Assert.AreEqual(sut.Password, "123456");
            Assert.AreEqual(sut.Name, "Alex Tan");
        }

        [TestMethod]
        public void CreateNewManager()
        {
            var sut = new Manager(1, "manager", "123456", "John Smith", 10, 2000, DistrictName.Sydney);
            Assert.AreEqual(sut.UserID, 1);
            Assert.AreEqual(sut.Username, "manager");
            Assert.AreEqual(sut.Password, "123456");
            Assert.AreEqual(sut.Name, "John Smith");
            Assert.AreEqual(sut.HoursApprovalLimit, 10);
            Assert.AreEqual(sut.CostApprovalLimit, 2000);
            Assert.AreEqual(sut.District, DistrictName.Sydney);
        }



        [TestMethod]
        public void CreateNewSiteEngineer()
        {
            var sut = new Engineer(1, "steven", "testpassword", "Steven", 18.5, 5000, DistrictName.Sydney);
            Assert.AreEqual(sut.UserID,1);
            Assert.AreEqual(sut.Username, "steven");
            Assert.AreEqual(sut.Password, "testpassword");
            Assert.AreEqual(sut.Name, "Steven");
            Assert.AreEqual(sut.HoursApprovalLimit, 18.5);
            Assert.AreEqual(sut.CostApprovalLimit, 5000);
            Assert.AreEqual(sut.District, DistrictName.Sydney);

        }



    }
}
