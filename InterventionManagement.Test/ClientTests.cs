
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class ClientTests
    {

        [TestMethod]
        public void Invalid_Client_Name_When_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Name_When_WhiteSpace()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Numbers()
        {
            Assert.Fail();
        }
    
        [TestMethod]
        public void Invalid_Client_Name_When_AlphaNumeric()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Name_When_Over_Character_Limit()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Location_When_NULL()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Whitespace()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void Invalid_Client_Location_When_Over_Character_Limit()
        {
            Assert.Fail();
        }

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


        /*
        [TestMethod]
        public void InsertClient_ValidData_Success()
        {
            // properties we need
            int clientId = -1;
            bool clientSuccessfullyAdded = false;

            // add a new client
            string name = "Unit Test Man";
            string location = "Mom's Basement";
            int districtId = 1;

            var ctw = new ClientTableWrapper();
            ctw.addClient(name, location, districtId);

            // check if client was added
            foreach (var client in ctw.GetClients())
            {
                if (client.Name == name)
                {
                    clientId = client.ClientId;
                    clientSuccessfullyAdded = true;
                }
            }

            Assert.AreEqual(clientSuccessfullyAdded, true);

            // delete the test client
            if (clientSuccessfullyAdded)
            {
                ctw.DeleteClient(clientId);
            }
        }

        [TestMethod]
        public void GetClientFields_ValidData_Success()
        {
            var ctw = new ClientTableWrapper();
            int clientId = 1;

            string name = ctw.getClientNameByClientId(clientId);
            string location = ctw.getClientLocationByClientId(clientId);
            int districtId = Convert.ToInt32(ctw.getClientDistrictIdByClientId(clientId));

            Assert.AreEqual(name, "Jane Doe");
            Assert.AreEqual(location, "1 Main Street, (Blue House)");
            Assert.AreEqual(districtId, 1);
        }
    */
    }

}

