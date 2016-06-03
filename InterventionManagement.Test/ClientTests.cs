
using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Validatores;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class ClientTests
    {

        [TestMethod]
        public void Invalid_Client_Name_When_NULL()
        {
            string name = null;
            bool results = ClientValidator.ValidateName(name);

            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Name_When_WhiteSpace()
        {
            string name = " ";
            bool results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);

            name = "               ";
            results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Numbers()
        {
            string name = "123456";
            bool results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);
        }
    
        [TestMethod]
        public void Invalid_Client_Name_When_AlphaNumeric()
        {
            string name = "Nathan123456";
            bool results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);

            name = "123456Nathan";
            results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Over_Character_Limit()
        {
            // TODO: Replace string length with max name variable from config file.
            string name = new String('A',101);
            bool results = ClientValidator.ValidateName(name);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Location_When_NULL()
        {
            string loc = null;
            bool results = ClientValidator.ValidateName(loc);

            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Whitespace()
        {
            string loc = " ";
            bool results = ClientValidator.ValidateName(loc);
            Assert.IsFalse(results);

            loc = "               ";
            results = ClientValidator.ValidateName(loc);
            Assert.IsFalse(results);
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Over_Character_Limit()
        {
            // TODO: Replace string length with location char limit variable from config file.
            string loc = new String('A', 10000);
            bool results = ClientValidator.ValidateName(loc);
            Assert.IsFalse(results);
        }

        /* Are these required anymore?
        [TestMethod]
        public void Invalid_Client_District_When_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_District_When_Text()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_District_When_Negative()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_District_When_Out_Of_Range()
        {
            //Above the assigned 4(?) districts.
            Assert.Fail();
        }
        */
    }

}

