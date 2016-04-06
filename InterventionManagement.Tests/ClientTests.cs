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
        public void CreateClient_ValidFields_NewClient()
        {
            Client sut = new Client(1, "Steve", "Ashfield", DistrictName.Sydney);
            Assert.AreEqual(1, sut.ClientId);
            Assert.AreEqual("Steve", sut.ClientName);
            Assert.AreEqual("Ashfield", sut.ClientLocation);
            Assert.AreEqual(DistrictName.Sydney, sut.ClientDistrictName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid name. Name must not contain numbers.")]
        public void CreateClient_EmptyName_ThrowsException()
        {
            Client sut = new Client(1, "", "Ashfield", DistrictName.Sydney); 
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid name. Name must not contain numbers.")]
        public void CreateClient_NumericName_ThrowsException()
        {
            Client sut = new Client(1, "0395430", "Ashfield", DistrictName.Sydney);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid location description.")]
        public void CreateClient_EmptyLocation_ThrowsExceptionn()
        {
            Client sut = new Client(1, "Steve ha", "", DistrictName.Sydney); ;
        }
    }
}