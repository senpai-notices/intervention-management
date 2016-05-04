using System;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Business.DataLayerWrappers;
using au.edu.uts.ASDF.ENETCare.InterventionManagement.Data.DataSets.MainDataSetTableAdapters;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class InterventionTests
    {
        private string _username;
        private string _engineerName;
        private int _engineerHour;
        private int _engineerCost;
        private int _engineeDistrictId;

        private string _clientName;
        private string _clientLocation;
        private int _clientDistrictId;

        private int _interventionTemplateId;
        DateTime _datePerformed;
        private int _interventionStateId;
        private int _hours;
        private int _cost;
        private string _proposerUsername;
        private string _approverUsername;
        private int _clientId;
        private string _notes;
        private int _remainingLife;
        private DateTime? _dateOfLastVisit;

        private ClientTableWrapper _clientTw;
        private InterventionTableWrapper _interventionTw;

        [TestInitialize]
        public void TestInitialize()
        {
            _username = "alex";
            _engineerName="Alex T";
            _engineerHour = 10;
            _engineerCost = 11;
            _engineeDistrictId = 1;

            _clientName = "the client";
            _clientLocation = "Main Road";
            _clientDistrictId = 1;

            _interventionTemplateId = 2;
            _datePerformed = new DateTime(2016,04,01);
            _interventionStateId = 1;
            _hours = 4;
            _cost = 5;
            _proposerUsername = "alex";
            _approverUsername = "alex";
            _notes = "";
            _remainingLife = 100;
            _dateOfLastVisit = null;

            _clientTw.InsertClient(_clientName,_clientLocation,_clientDistrictId);
            //var x = _clientTw.get
            //_interventionTw.InsertIntervention(_interventionTemplateId,_datePerformed,_interventionStateId,_hours,_cost,_proposerUsername,_approverUsername,);
        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestMethod]
        public void InsertIntervention_ValidData_Success()
        {

        }
    }
}