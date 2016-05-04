using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace au.edu.uts.ASDF.ENETCare.InterventionManagement.Tests
{
    [TestClass]
    public class InterventionTests
    {
        private string _username1;
        private string _engineerName1;
        private int _engineerHour1;
        private int _engineerCost1;
        private int _engineeDistrictId1;

        private string _username2;
        private string _engineerName2;
        private int _engineerHour2;
        private int _engineerCost2;
        private int _engineeDistrictId2;

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
        private DateTime _dateOfLastVisit;

        [TestInitialize]
        public void TestInitialize()
        {
            _username1 = "alex";
            _engineerName1="Alex T";
            _engineerHour1 = 10;
            _engineerCost1 = 11;
            _engineeDistrictId1 = 1;

            _username2 = "jane";
            _engineerName2 = "Jane";
            _engineerHour2 = 13;
            _engineerCost2 = 14;
            _engineeDistrictId2 = 1;

            _interventionTemplateId = 2;
            _datePerformed = new DateTime(2016,04,01);
            _interventionStateId = 1;
            _hours = 4;
            _cost = 5;
            _proposerUsername = "alex";
            _approverUsername = "alex";
            _clientId = 99;
            _notes = "";
            _remainingLife = 100;
            _dateOfLastVisit = null;
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