
using System;
using ASDF.ENETCare.InterventionManagement.Business.Validators;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class ClientTests
    {

        [TestMethod]
        public void Invalid_Client_Name_When_NULL()
        {
            try
            {
                string name = null;
                ClientValidator.ValidateName(name);
                Assert.Fail();

            }
            catch (ArgumentException)
            { }
        }

        [TestMethod]
        public void Invalid_Client_Name_When_WhiteSpace()
        {
            string name;

            try
            {
                name = " ";
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){ }

            try
            {
                name = "               ";
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){ }
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Numbers()
        {
            try
            {
                string name = "123456";
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){ }
        }
    
        [TestMethod]
        public void Invalid_Client_Name_When_AlphaNumeric()
        {
            string name;
            try
            {
                name = "Nathan123456";
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){}

            try
            {
                name = "123456Nathan";
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){}
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Over_Character_Limit()
        {
            // TODO: Replace string length with max name variable from config file.
            try
            {
                string name = new String('A', 101);
                ClientValidator.ValidateName(name);
                Assert.Fail();
            }
            catch (ArgumentException){}
        }

        [TestMethod]
        public void Invalid_Client_Location_When_NULL()
        {
            try
            {
                string loc = null;
                ClientValidator.ValidateName(loc);
                Assert.Fail();
            }
            catch (ArgumentException){}
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Whitespace()
        {
            string loc;

            try
            {
                loc = " ";
                ClientValidator.ValidateName(loc);
                Assert.Fail();

            }
            catch (ArgumentException){}

            try
            {
                loc = "               ";
                ClientValidator.ValidateName(loc);
                Assert.Fail();
            }
            catch (ArgumentException){}
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Over_Character_Limit()
        {
            // TODO: Replace string length with location char limit variable from config file.
            try
            {
                string loc = new String('A', 10000);
                ClientValidator.ValidateName(loc);
                Assert.Fail();
            }
            catch (ArgumentException){}
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

