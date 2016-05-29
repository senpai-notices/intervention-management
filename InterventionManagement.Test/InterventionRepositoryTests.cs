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
        private Mock<IGenericRepository<Intervention>> _mock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mock = new Mock<IGenericRepository<Intervention>>();
        }

        [TestMethod]
        public void InsertIntervention_0()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            Assert.IsTrue(!_mock.Object.SelectAll().Any());
        }

        [TestMethod]
        public void InsertIntervention_1()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            _mock.Object.Insert(new Intervention());

            Assert.IsTrue(_mock.Object.SelectAll().Count() == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void InsertIntervention_2()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention i) => { allInterventions.Add(i); });
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            _mock.Object.Insert(new Intervention());
            _mock.Object.Insert(new Intervention());

            Assert.IsTrue(_mock.Object.SelectAll().Count() == 2);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetInterventionById()
        {
            _mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Intervention());

            _mock.Object.GetById(2);

            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetInterventions()
        {
            _mock.Setup(x => x.SelectAll()).Returns(new List<Intervention>());

            _mock.Object.SelectAll();

            _mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateIntervention()
        {
            _mock.Setup(x => x.Update(It.IsAny<Intervention>()));

            _mock.Object.Update(new Intervention());

            _mock.VerifyAll();
        }
    }
}