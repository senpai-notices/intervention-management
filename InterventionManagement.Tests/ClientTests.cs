using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class ClientTests
    {
        [TestMethod]
        public void CreateClient_ValidFields_NewClient()
        {
            Client sut = new Client(1, "Steve", "Ashfield", District.Sydney);
            Assert.AreEqual(1, sut.ClientId);
            Assert.AreEqual("Steve", sut.Name);
            Assert.AreEqual("Ashfield", sut.Location);
            Assert.AreEqual(District.Sydney, sut.District);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid name. Name must not contain numbers.")]
        public void CreateClient_EmptyName_ThrowsException()
        {
            Client sut = new Client(1, "", "Ashfield", District.Sydney); 
            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid name. Name must not contain numbers.")]
        public void CreateClient_NumericName_ThrowsException()
        {
            Client sut = new Client(1, "0395430", "Ashfield", District.Sydney);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException), "Please enter a valid location description.")]
        public void CreateClient_EmptyLocation_ThrowsExceptionn()
        {
            Client sut = new Client(1, "Steve ha", "", District.Sydney); ;
        }
    }
}