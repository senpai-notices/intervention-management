using Microsoft.VisualStudio.TestTools.UnitTesting;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CreateClientTest()
        {
            Client sut = new Client(1, "Steve ha", "Ashfield", DistrictName.Sydney);
            Assert.AreEqual(1, sut.ClientID);
            Assert.AreEqual("Steve", sut.ClientName);
            Assert.AreEqual("Ashfield", sut.ClientLocation);
            Assert.AreEqual(DistrictName.Sydney, sut.ClientDistrictName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid name. Name must not contain numbers.")]
        public void Empty_Name_Client()
        {
            Client sut = new Client(1, "", "Ashfield", DistrictName.Sydney); 
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid location description.")]
        public void Empty_Location_Description()
        {
            Client sut = new Client(1, "Steve ha", "", DistrictName.Sydney); ;
        }
    }
}