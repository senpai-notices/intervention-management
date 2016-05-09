using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class DistrictTests
    {
        [TestMethod]
        public void GetDistrictForUser_ValidData_Success()
        {
            var dtw = new DistrictTableWrapper();
            string district = dtw.getDistrictForUser("DebugEngineer");
            Assert.AreEqual(district, "Urban Indonesia");
        }
        [TestMethod]
        public void GetDistrictsAndIdList_ValidData_Success()
        {
            var dtw = new DistrictTableWrapper();
            List<string> districts = dtw.getDistrictsAndIdsList();
            int indexOfLast = districts.Count - 1;

            string firstDistrict = districts[0];
            string lastDistrict = districts[indexOfLast];
            Assert.AreEqual(firstDistrict, "1 Urban Indonesia");
            Assert.AreEqual(lastDistrict, "6 Rural New South Wales");
        }

        [TestMethod]
        public void GetDistrictsList_ValidData_Success()
        {
            var dtw = new DistrictTableWrapper();
            List<string> districts = dtw.getDistrictsList();
            int indexOfLast = districts.Count - 1;

            string firstDistrict = districts[0];
            string lastDistrict = districts[indexOfLast];
            Assert.AreEqual(firstDistrict, "Urban Indonesia");
            Assert.AreEqual(lastDistrict, "Rural New South Wales");
        }
    }
}
