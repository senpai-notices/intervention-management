using System;
using System.Collections.Generic;
using System.Linq;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataClasses;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class EngineerTests
    {
        private Engineer _eAlice;
        private Engineer _eSam;
        private Engineer _eGeorge;
        private Manager _mDavy;
        private Manager _mDena;
        private Accountant _aCarol;

        private Client _client1;
        private Client _client2;
        private Client _client3;

        private Intervention _intervention1;
        private Intervention _intervention2;
        private Intervention _intervention3;

        private InterventionTemplate _tPortableToilet;
        private InterventionTemplate _tHepatitis;
        private InterventionTemplate _tStormProof;
        private InterventionTemplate _tMosquitoNet;
        private InterventionTemplate _tWaterPump;
        private InterventionTemplate _tWaterFilter;
        private InterventionTemplate _tSewerage;

        private QualityReport _qualityReport1;
        private QualityReport _qualityReport2;
        private QualityReport _qualityReport3;
        private QualityReport _qualityReport4;


        [TestMethod]
        public void Create_Client_Normal_Exists()
        {
            _eAlice.CreateClient(_client1);

            Assert.IsNotNull(ClientManager.Clients);
            Assert.AreEqual(true, ClientManager.Clients.Contains(_client1));
            Assert.AreEqual(_client1, ClientManager.Clients.First());
        }

        [TestMethod]
        public void ViewLocalClients_Normal_OnlyLocalClientsDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eSam.CreateClient(_client2);
            _eSam.CreateClient(_client3);

            var actual = _eAlice.ViewLocalClients();
            var expected = new List<Client>() { _client1, _client2 };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewClient_ClientWithNoInterventions_ClientDetailsDisplayed()
        {
            _eAlice.CreateClient(_client1);

            var actual = _eAlice.ViewClient(_client1);
            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "21",
                "The Client",
                "24 Main St, blue house",
                "RuralPapuaNewGuinea",
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
            _eAlice.CreateIntervention(_intervention1);

            Assert.AreEqual(_intervention1, InterventionManager.Interventions.First());
        }

        [TestMethod]
        public void ViewClient_ClientWithIntervention_ClientDetailsDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eAlice.CreateIntervention(_intervention1);

            var actual = _eAlice.ViewClient(_client1);
            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "21",
                "The Client",
                "24 Main St, blue house",
                "RuralPapuaNewGuinea",
                "",
                "Interventions",
                "-------------",
                "31 15/02/2016"
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewClient_ClientWith2Interventions_ClientDetailsDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eAlice.CreateIntervention(_intervention1);
            _eAlice.CreateIntervention(_intervention2);

            var actual = _eAlice.ViewClient(_client1);
            var expected = new List<string>()
            {
                "--------------",
                "CLIENT DETAILS",
                "--------------",
                "21",
                "The Client",
                "24 Main St, blue house",
                "RuralPapuaNewGuinea",
                "",
                "Interventions",
                "-------------",
                "31 15/02/2016",
                "32 16/02/2016"
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewPreviousInterventions_InterventionsCreated_InterventionsDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eAlice.CreateClient(_client2);
            _eAlice.CreateIntervention(_intervention1);
            _eAlice.CreateIntervention(_intervention2);
            _eSam.CreateClient(_client3);
            _eSam.CreateIntervention(_intervention3);

            var actual1 = _eAlice.ViewCreatedInterventions();
            var actual2 = _eSam.ViewCreatedInterventions();
            var expected1 = new List<string>()
            {
                "----------------------",
                "PREVIOUS INTERVENTIONS",
                "----------------------",
                "31 15/02/2016",
                "32 16/02/2016"
            };
            var expected2 = new List<string>()
            {
                "----------------------",
                "PREVIOUS INTERVENTIONS",
                "----------------------",
                "33 17/02/2016"
            };

            CollectionAssert.AreEqual(actual1, expected1);
            CollectionAssert.AreEqual(actual2, expected2);
        }

        [TestMethod]
        public void ViewPreviousInterventions_NoInterventions_NoneDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eAlice.CreateClient(_client2);

            var actual = _eAlice.ViewCreatedInterventions();
            var expected = new List<string>()
            {
                "----------------------",
                "PREVIOUS INTERVENTIONS",
                "----------------------",
                "None"
            };

            CollectionAssert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void ViewQualityReports_Normal_QualityReportsDisplayed()
        {
            _eAlice.CreateClient(_client1);
            _eAlice.CreateClient(_client2);
            _eAlice.CreateIntervention(_intervention1);
            _eAlice.CreateIntervention(_intervention2);
            _eSam.CreateClient(_client3);
            _eSam.CreateIntervention(_intervention3);

            _eAlice.AddQualityReport(_qualityReport1);
            _eAlice.AddQualityReport(_qualityReport2);
            _eAlice.AddQualityReport(_qualityReport3);
            _eSam.AddQualityReport(_qualityReport4);

            var actual1 = _eAlice.ViewQualityReports(_intervention1);
            var actual2 = _eSam.ViewQualityReports(_intervention3);
            var expected1 = new List<QualityReport>() { _qualityReport1, _qualityReport3 };
            var expected2 = new List<QualityReport>() { _qualityReport4 };

            CollectionAssert.AreEqual(actual1, expected1);
            CollectionAssert.AreEqual(actual2, expected2);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _eAlice = new Engineer(1, "alice@example.com", "password", "Alice Nelson", 50, 2000, DistrictName.RuralPapuaNewGuinea);
            _eSam = new Engineer(2, "sam@example.com", "password", "Sam Franklin", 100, 5200, DistrictName.RuralPapuaNewGuinea);
            _eGeorge = new Engineer(3, "george@example.com", "password", "George Glass", 10, 10000, DistrictName.Sydney);
            _mDavy = new Manager(4, "davy@example.com", "password", "Davy Jones", 200, 50000, DistrictName.RuralPapuaNewGuinea);
            _mDena = new Manager(5, "dena@example.com", "password", "Dena Dittmeyer", 1000, 200000, DistrictName.Sydney);
            _aCarol = new Accountant(6, "carol@example.com", "password", "Carol Brady");

            _client1 = new Client(21, "The Client", "24 Main St, blue house", DistrictName.RuralPapuaNewGuinea);
            _client2 = new Client(22, "Community A", "24 Big Rd, black house", DistrictName.RuralPapuaNewGuinea);
            _client3 = new Client(23, "UTS Students ", "Broadway, brown building", DistrictName.Sydney);

            _tPortableToilet = new InterventionTemplate("Supply and Install Portable Toilet", 2, 600);
            _tHepatitis = new InterventionTemplate("Hepatitis Avoidance Training", 3, 0);
            _tStormProof = new InterventionTemplate("Supply and Install Storm-proof Home Kit", 8, 5000);
            _tMosquitoNet = new InterventionTemplate("Supply Mosquito Net", 0, 25);
            _tWaterPump = new InterventionTemplate("Install Water Pump", 80, 1200);
            _tWaterFilter = new InterventionTemplate("Supply High-Volume Water Filter and Train Users", 1, 2000);
            _tSewerage = new InterventionTemplate("Prepare Sewerage Trench", 50, 0);

            _intervention1 = new Intervention(31, new DateTime(2016, 2, 15), _tMosquitoNet, _eAlice.UserId, -1, _client1.ClientId);
            _intervention2 = new Intervention(32, new DateTime(2016, 2, 16), _tSewerage, _eAlice.UserId, -1, _client1.ClientId);
            _intervention3 = new Intervention(33, new DateTime(2016, 2, 17), _tHepatitis, _eSam.UserId, -1, _client3.ClientId);

            _qualityReport1 = new QualityReport(71, new DateTime(2016, 4, 1), "Notes!", 90, _intervention1.InterventionId);
            _qualityReport2 = new QualityReport(72, new DateTime(2016, 4, 2), "Some notes!", 75, _intervention2.InterventionId);
            _qualityReport3 = new QualityReport(73, new DateTime(2016, 4, 3), "Depreciation", 60, _intervention1.InterventionId);
            _qualityReport4 = new QualityReport(74, new DateTime(2016, 4, 3), "Important notes", 28, _intervention3.InterventionId);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            ClientManager.Clients.Clear();
            InterventionManager.Interventions.Clear();
            UserManager.Users.Clear();
            QualityReportManager.QualityReports.Clear();
        }
    }
}