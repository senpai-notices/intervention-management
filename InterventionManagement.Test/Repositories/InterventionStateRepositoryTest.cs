using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test.Repositories
{
    [TestClass]
    public class InterventionStateRepositoryTest
    {
        private IList<InterventionState> _interventionStates;
        private Mock<IInterventionStateRepository> _mockRepo;

        [TestInitialize]
        public void Initialize()
        {
            _interventionStates = new List<InterventionState>
            {
                new InterventionState{ InterventionStateId=1, Name="Proposed" },
                new InterventionState{ InterventionStateId=2, Name="Approved" },
                new InterventionState{ InterventionStateId=3, Name="Cancelled" },
                new InterventionState{ InterventionStateId=4, Name="Completed" }
            };

            _mockRepo = new Mock<IInterventionStateRepository>();

            _mockRepo.Setup(m => m.SelectAll()).Returns(_interventionStates);
            _mockRepo.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int i) => _interventionStates.Single(x => x.InterventionStateId == i));
            _mockRepo.Setup(m => m.Insert(It.IsAny<InterventionState>())).Callback((InterventionState i) => { _interventionStates.Add(i); });
            _mockRepo.Setup(m => m.Update(It.IsAny<InterventionState>())).Callback((InterventionState i) =>
            {
                var temp = _interventionStates.SingleOrDefault(x => x.InterventionStateId == i.InterventionStateId);
                _interventionStates.Remove(temp);
                _interventionStates.Add(i);
            });

            /*_mockRepo.Setup(m => m.GetRemainingInterventionStates(It.IsAny<int>()))
                .Returns((int i) =>_interventionStates.Where(x => x.DistrictId == i));*/
        }

        [TestMethod]
        public void SelectAll_Normal_AllReturned()
        {
            var returned = _mockRepo.Object.SelectAll();
            Assert.IsTrue(_interventionStates.Count == returned.Count());
        }

        [TestMethod]
        public void GetById_Normal_InterventionStateReturned()
        {
            var returned = _mockRepo.Object.GetById(2);
            Assert.IsTrue(returned.InterventionStateId == 2);
        }

        [TestMethod]
        public void Insert_Normal_InterventionStateAdded()
        {
            _mockRepo.Object.Insert(new InterventionState { InterventionStateId = 5 });
            Assert.IsTrue(_interventionStates.Count == 5);
            Assert.IsTrue(_interventionStates.Last().InterventionStateId == 5);
        }

        [TestMethod]
        public void Update_Normal_InterventionStateUpdated()
        {
            _mockRepo.Object.Update(new InterventionState { InterventionStateId = 4, Name = "Updated" });
            Assert.IsTrue(_interventionStates.Count == 4);
            Assert.IsTrue(_interventionStates.Single(c => c.InterventionStateId == 4).Name == "Updated");
        }

/*        [TestMethod]
        public void GetClientsOfDistrict_Five_TwoReturned()
        {
            var returned = _mockRepo.Object.GetClientsOfDistrict(5);
            Assert.IsTrue(returned.Count() == 2);
        }*/
    }
}
