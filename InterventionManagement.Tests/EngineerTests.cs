using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class EngineerTests
    {
        [TestMethod]
        public void CreateClient_Normal_Exists()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.RuralNewSouthWales);
            var client = new Client(1, "The Client", "24 Main St, <further description", engineer.District);

            engineer.CreateClient(client);

            Assert.IsNotNull(ClientManager.Clients);
            Assert.AreEqual(true, ClientManager.Clients.Contains(client));
            Assert.AreEqual(client, ClientManager.Clients.First());
        }

        [TestMethod]
        public void ViewLocalClients_Normal_OnlyLocalClientsDisplayed()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            // Engineer creates (local) clients
            var localClient1 = new Client(1, "The Client", "24 Main St, <further description", engineer.District);
            var localClient2 = new Client(2, "Community Bravo", "24 Main St, <further description", engineer.District);
            var localClient3 = new Client(3, "UTS Students", "24 Main St, <further description", engineer.District);

            engineer.CreateClient(localClient1);
            engineer.CreateClient(localClient2);
            engineer.CreateClient(localClient3);

            // Other clients created
            ClientManager.Clients.Add(new Client(4, "Big Client", "24 Main St, <further description", DistrictName.UrbanIndonesia));
            ClientManager.Clients.Add(new Client(5, "Smith Family", "24 Main St, <further description", DistrictName.RuralNewSouthWales));
            ClientManager.Clients.Add(new Client(6, "Community Alpha", "24 Main St, <further description", DistrictName.UrbanPapuaNewGuineea));

            var actual = engineer.ViewLocalClients();

            var expected = new List<Client> {localClient1, localClient2, localClient3};

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewClient_Normal_ClientDetailsDisplayed()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            var client = new Client(1, "The Client", "24 Main St, <further description", engineer.District);

            engineer.CreateClient(client);

            var actual = engineer.ViewClient(client);

            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "1",
                "The Client",
                "24 Main St, <further description",
                "Sydney",
                "",
                "Interventions",
                "-------------",
                "None"
            };

            CollectionAssert.AreEqual(actual, expected);
        }
    }
}
// http://www.yegor256.com/2014/05/05/oop-alternative-to-utility-classes.html