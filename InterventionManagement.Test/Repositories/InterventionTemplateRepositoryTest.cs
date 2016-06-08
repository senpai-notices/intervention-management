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
    public class InterventionTemplateRepositoryTest
    {
        private IList<InterventionTemplate> _interventionTemplates;
        private Mock<IInterventionTemplateRepository> _mockRepo;

        [TestInitialize]
        public void Initialize()
        {
            _interventionTemplates = new List<InterventionTemplate>
            {
                new InterventionTemplate{ InterventionTemplateId=1, Name="Supply Mosquito Net", Hours=1, Cost=60.00M },
                new InterventionTemplate{ InterventionTemplateId=2, Name="Supply and Install Storm-proof Home Kit", Hours=40, Cost=1000.00M },
                new InterventionTemplate{ InterventionTemplateId=3, Name="Supply and Install Portable Toilet", Hours=4, Cost=150.00M },
                new InterventionTemplate{ InterventionTemplateId=4, Name="Hepatitis Avoidance Training", Hours=3, Cost=80.00M }
            };

            _mockRepo = new Mock<IInterventionTemplateRepository>();

            _mockRepo.Setup(m => m.SelectAll()).Returns(_interventionTemplates);
            _mockRepo.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int i) => _interventionTemplates.Single(x => x.InterventionTemplateId == i));
            _mockRepo.Setup(m => m.Insert(It.IsAny<InterventionTemplate>())).Callback((InterventionTemplate i) => { _interventionTemplates.Add(i); });
            _mockRepo.Setup(m => m.Update(It.IsAny<InterventionTemplate>())).Callback((InterventionTemplate i) =>
            {
                var temp = _interventionTemplates.SingleOrDefault(x => x.InterventionTemplateId == i.InterventionTemplateId);
                _interventionTemplates.Remove(temp);
                _interventionTemplates.Add(i);
            });
        }

        [TestMethod]
        public void SelectAll_Normal_AllReturned()
        {
            var returned = _mockRepo.Object.SelectAll();
            Assert.IsTrue(_interventionTemplates.Count == returned.Count());
        }

        [TestMethod]
        public void GetById_Normal_InterventionStateReturned()
        {
            var returned = _mockRepo.Object.GetById(2);
            Assert.IsTrue(returned.InterventionTemplateId == 2);
        }

        [TestMethod]
        public void Insert_Normal_InterventionStateAdded()
        {
            _mockRepo.Object.Insert(new InterventionTemplate { InterventionTemplateId = 5 });
            Assert.IsTrue(_interventionTemplates.Count == 5);
            Assert.IsTrue(_interventionTemplates.Last().InterventionTemplateId == 5);
        }

        [TestMethod]
        public void Update_Normal_InterventionStateUpdated()
        {
            _mockRepo.Object.Update(new InterventionTemplate { InterventionTemplateId = 4, Name = "Updated" });
            Assert.IsTrue(_interventionTemplates.Count == 4);
            Assert.IsTrue(_interventionTemplates.Single(c => c.InterventionTemplateId == 4).Name == "Updated");
        }
    }
}
