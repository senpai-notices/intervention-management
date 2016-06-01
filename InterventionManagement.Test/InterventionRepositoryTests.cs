using System.Collections.Generic;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
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
            _mock = new Mock<IGenericRepository<Intervention>>(MockBehavior.Strict);
        }

        [TestMethod]
        public void InsertIntervention_Zero_Exists()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention c) => { allInterventions.Add(c); });

            Assert.IsTrue(!allInterventions.Any());
        }

        [TestMethod]
        public void InsertIntervention_One_Exists()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention c) => { allInterventions.Add(c); });

            _mock.Object.Insert(new Intervention());

            Assert.IsTrue(allInterventions.Count == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void InsertIntervention_Two_Exists()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention c) => { allInterventions.Add(c); });

            _mock.Object.Insert(new Intervention());
            _mock.Object.Insert(new Intervention());

            Assert.IsTrue(allInterventions.Count == 2);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_0()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            var returnedInterventions = _mock.Object.SelectAll();

            Assert.IsTrue(allInterventions.Count == 0);
            Assert.IsTrue(!returnedInterventions.Any());
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_1()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention c) => { allInterventions.Add(c); });
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            _mock.Object.Insert(new Intervention());

            var returnedInterventions = _mock.Object.SelectAll();

            Assert.IsTrue(allInterventions.Count == 1);
            Assert.IsTrue(returnedInterventions.Count() == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_2()
        {
            var allInterventions = new List<Intervention>();
            _mock.Setup(x => x.Insert(It.IsAny<Intervention>()))
                .Callback((Intervention c) => { allInterventions.Add(c); });
            _mock.Setup(x => x.SelectAll()).Returns(allInterventions);

            _mock.Object.Insert(new Intervention());
            _mock.Object.Insert(new Intervention());

            var returnedInterventions = _mock.Object.SelectAll();

            Assert.IsTrue(allInterventions.Count == 2);
            Assert.IsTrue(returnedInterventions.Count() == 2);
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