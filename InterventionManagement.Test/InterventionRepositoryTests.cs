using System.Collections.Generic;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class InterventionRepositoryTests
    {
        private Mock<IInterventionRepository> _mock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mock = new Mock<IInterventionRepository>();
        }

        [TestMethod]
        public void InsertIntervention_0()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.InsertIntervention(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.GetInterventions()).Returns(allInterventions);

            Assert.IsTrue(!_mock.Object.GetInterventions().Any());
        }

        [TestMethod]
        public void InsertIntervention_1()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.InsertIntervention(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.GetInterventions()).Returns(allInterventions);

            _mock.Object.InsertIntervention(new Intervention());

            Assert.IsTrue(_mock.Object.GetInterventions().Count() == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void InsertIntervention_2()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.InsertIntervention(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.GetInterventions()).Returns(allInterventions);

            _mock.Object.InsertIntervention(new Intervention());
            _mock.Object.InsertIntervention(new Intervention());

            Assert.IsTrue(_mock.Object.GetInterventions().Count() == 2);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetInterventionById()
        {
            _mock.Setup(x => x.GetInterventionById(It.IsAny<int>())).Returns(new Intervention());

            _mock.Object.GetInterventionById(2);

            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetInterventions()
        {
            _mock.Setup(x => x.GetInterventions()).Returns(new List<Intervention>());

            _mock.Object.GetInterventions();

            _mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateIntervention()
        {
            _mock.Setup(x => x.UpdateIntervention(It.IsAny<Intervention>()));

            _mock.Object.UpdateIntervention(new Intervention());

            _mock.VerifyAll();
        }
    }
}