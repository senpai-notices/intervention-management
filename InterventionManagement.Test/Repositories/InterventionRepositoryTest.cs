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
    public class InterventionRepositoryTest
    {
        private IList<Intervention> _interventions;
        private Mock<IInterventionRepository> _mockRepo;

        [TestInitialize]
        public void Initialize()
        {
            _interventions = new List<Intervention>
            {
                new Intervention { InterventionId = 1, ClientId = 4, Hours = 2, Cost = 400, ProposerId = 27, DatePerformed = new DateTime(2016,1,1), InterventionTemplateId = 1, InterventionStateId = 1},
                new Intervention { InterventionId = 2, ClientId = 3, Hours = 7, Cost = 455, ProposerId = 27, DatePerformed = new DateTime(2016,1,2), InterventionTemplateId = 2, InterventionStateId = 2},
                new Intervention { InterventionId = 3, ClientId = 2, Hours = 5, Cost = 600, ProposerId = 28, DatePerformed = new DateTime(2016,1,3), InterventionTemplateId = 3, InterventionStateId = 1},
                new Intervention { InterventionId = 4, ClientId = 2, Hours = 5, Cost = 600, ProposerId = 28, DatePerformed = new DateTime(2016,1,4), InterventionTemplateId = 4, InterventionStateId = 2}
            };

            _mockRepo = new Mock<IInterventionRepository>();

            _mockRepo.Setup(m => m.SelectAll()).Returns(_interventions);
            _mockRepo.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int i) => _interventions.Single(x => x.InterventionId == i));
            _mockRepo.Setup(m => m.Insert(It.IsAny<Intervention>())).Callback((Intervention i) => { _interventions.Add(i); });
            _mockRepo.Setup(m => m.Update(It.IsAny<Intervention>())).Callback((Intervention i) =>
            {
                var temp = _interventions.SingleOrDefault(x => x.InterventionId == i.InterventionId);
                _interventions.Remove(temp);
                _interventions.Add(i);
            });

            _mockRepo.Setup(m => m.GetInterventionsOfClient(It.IsAny<int>()))
                .Returns((int i) =>_interventions.Where(
                    x => x.ClientId == i
                    && x.InterventionStateId != 3)
                    .OrderByDescending(z=>z.DatePerformed));

            _mockRepo.Setup(m => m.GetInterventionsOfUser(It.IsAny<int>()))
                .Returns((int i) => _interventions.Where(
                    x => x.ProposerId == i
                    || x.ApproverId == i)
                    .Where(z => z.InterventionStateId != 3)
                    .OrderByDescending(z => z.DatePerformed));
        }

        [TestMethod]
        public void SelectAll_Normal_AllReturned()
        {
            var returned = _mockRepo.Object.SelectAll();
            Assert.IsTrue(_interventions.Count == returned.Count());
        }

        [TestMethod]
        public void GetById_Normal_InterventionReturned()
        {
            var returned = _mockRepo.Object.GetById(2);
            Assert.IsTrue(returned.InterventionId == 2);
        }

        [TestMethod]
        public void Insert_Normal_InterventionAdded()
        {
            _mockRepo.Object.Insert(new Intervention { InterventionId = 5});
            Assert.IsTrue(_interventions.Count == 5);
            Assert.IsTrue(_interventions.Last().InterventionId == 5);
        }

        [TestMethod]
        public void Update_Normal_InterventionUpdated()
        {
            _mockRepo.Object.Update(new Intervention { InterventionId = 4, Notes = "Updated" });
            Assert.IsTrue(_interventions.Count == 4);
            Assert.IsTrue(_interventions.Single(c => c.InterventionId == 4).Notes == "Updated");
        }

        [TestMethod]
        public void GetInterventionsOfClient_Two_TwoReturned()
        {
            var returned = _mockRepo.Object.GetInterventionsOfClient(2);
            Assert.IsTrue(returned.Count() == 2);
        }

        [TestMethod]
        public void GetInterventionsOfUser_27_TwoReturned()
        {
            var returned = _mockRepo.Object.GetInterventionsOfUser(27);
            Assert.IsTrue(returned.Count() == 2);
        }
    }
}