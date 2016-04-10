using System;
using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class EngineerTests
    {
        [TestCleanup()]
        public void TestCleanup()
        {
            ClientManager.Clients.Clear();
            InterventionManager.Interventions.Clear();
        }

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
            ClientManager.Add(new Client(4, "Big Client", "24 Main St, <further description", DistrictName.UrbanIndonesia));
            ClientManager.Add(new Client(5, "Smith Family", "24 Main St, <further description", DistrictName.RuralNewSouthWales));
            ClientManager.Add(new Client(6, "Community Alpha", "24 Main St, <further description", DistrictName.UrbanPapuaNewGuineea));

            var actual = engineer.ViewLocalClients();

            var expected = new List<Client> {localClient1, localClient2, localClient3};

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewClient_ClientWithNoInterventions_ClientDetailsDisplayed()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            var client = new Client(1, "The Client", "24 Main St, <further description...>", engineer.District);

            engineer.CreateClient(client);

            var actual = engineer.ViewClient(client);

            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "1",
                "The Client",
                "24 Main St, <further description...>",
                "Sydney",
                "",
                "Interventions",
                "-------------",
                "None"
            };

            CollectionAssert.AreEqual(actual, expected);
        }


        [TestMethod]
        public void CreateIntervention_Normal_Exists()
        {
            var engineer = new Engineer(1, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);
            var client = new Client(2, "The Client", "24 Main St, <further description...>", engineer.District);

            var intervention = new Intervention(
                3, 
                new DateTime(2016,2,15), 
                InterventionState.Proposed, 
                new List<QualityReport>(), 
                "An Intervention",
                2,
                100,
                engineer.UserId,
                -1,
                client.ClientId);

            engineer.CreateIntervention(intervention);

            Assert.AreEqual(intervention, InterventionManager.Interventions.First());
        }

        
        [TestMethod]
        public void ViewClient_ClientWithIntervention_ClientDetailsDisplayed()
        {
            var engineer = new Engineer(31, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            var client = new Client(32, "The Client", "24 Main St, <further description...>", engineer.District);

            engineer.CreateClient(client);

            var intervention = new Intervention(
                33,
                new DateTime(2016,2,15),
                InterventionState.Proposed,
                new List<QualityReport>(),
                "The Intervention",
                2,
                200,
                engineer.UserId,
                -1,
                client.ClientId  
                );

            

            engineer.CreateIntervention(intervention);

            var actual = engineer.ViewClient(client);

            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "32",
                "The Client",
                "24 Main St, <further description...>",
                "Sydney",
                "",
                "Interventions",
                "-------------",
                "33 15/02/2016"
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewClient_ClientWith2Interventions_ClientDetailsDisplayed()
        {
            var engineer = new Engineer(11, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            var client = new Client(12, "The Client", "24 Main St, <further description...>", engineer.District);

            engineer.CreateClient(client);

            var intervention1 = new Intervention(
                13,
                new DateTime(2016, 2, 15),
                InterventionState.Proposed,
                new List<QualityReport>(),
                "The Intervention",
                2,
                200,
                engineer.UserId,
                -1,
                client.ClientId
                );

            var intervention2 = new Intervention(
                18,
                new DateTime(2016, 3, 20),
                InterventionState.Proposed,
                new List<QualityReport>(),
                "Big Intervention",
                3,
                500,
                engineer.UserId,
                -1,
                client.ClientId
                );

            engineer.CreateIntervention(intervention1);
            engineer.CreateIntervention(intervention2);

            var actual = engineer.ViewClient(client);

            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "12",
                "The Client",
                "24 Main St, <further description...>",
                "Sydney",
                "",
                "Interventions",
                "-------------",
                "13 15/02/2016",
                "18 20/03/2016"
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        
        [TestMethod]
        public void SomeQuery()
        {
            var engineer = new Engineer(21, "johndoe", "password", "John Doe", 2.5m, 550.53m, DistrictName.Sydney);

            var client = new Client(22, "The Client", "24 Main St, <further description...>", engineer.District);

            var intervention = new Intervention(
                23,
                new DateTime(2016, 2, 15),
                InterventionState.Proposed,
                new List<QualityReport>(),
                "The Intervention",
                2,
                200,
                engineer.UserId,
                -1,
                client.ClientId
                );

            engineer.CreateClient(client);

            engineer.CreateIntervention(intervention);

            var iResult = from i in InterventionManager.Interventions
                          where engineer.UserId == i.ProposerId
                select i;

            var cResult = from c in ClientManager.Clients
                select c;

            Assert.AreEqual(iResult.First(), intervention);
            Assert.AreEqual(cResult.First(), client);
        }
    }
}