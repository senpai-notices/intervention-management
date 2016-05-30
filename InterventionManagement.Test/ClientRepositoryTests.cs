using System.Collections.Generic;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class ClientRepositoryTests
    {
        private Mock<IGenericRepository<Client>> _mock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mock = new Mock<IGenericRepository<Client>>(MockBehavior.Strict);
        }

        [TestMethod]
        public void InsertClient_Zero_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.Insert(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });

            Assert.IsTrue(!allClients.Any());
        }
        //take out selectall() and test getall
        [TestMethod]
        public void InsertClient_One_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.Insert(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            //_mock.Setup(x => x.SelectAll()).Returns(allClients);

            _mock.Object.Insert(new Client());

            //Assert.IsTrue(_mock.Object.SelectAll().Count() == 1);
            Assert.IsTrue(allClients.Count == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void InsertClient_Two_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.Insert(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            //_mock.Setup(x => x.SelectAll()).Returns(allClients);

            _mock.Object.Insert(new Client());
            _mock.Object.Insert(new Client());

            //Assert.IsTrue(_mock.Object.SelectAll().Count() == 2);
            Assert.IsTrue(allClients.Count == 2);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_0()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.SelectAll()).Returns(allClients);

            var returnedClients = _mock.Object.SelectAll();

            Assert.IsTrue(allClients.Count == 0);
            Assert.IsTrue(!returnedClients.Any());
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_1()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.Insert(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            _mock.Setup(x => x.SelectAll()).Returns(allClients);

            _mock.Object.Insert(new Client());

            var returnedClients = _mock.Object.SelectAll();

            Assert.IsTrue(allClients.Count == 1);
            Assert.IsTrue(returnedClients.Count() == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void SelectAll_2()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.Insert(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            _mock.Setup(x => x.SelectAll()).Returns(allClients);

            _mock.Object.Insert(new Client());
            _mock.Object.Insert(new Client());

            var returnedClients = _mock.Object.SelectAll();

            Assert.IsTrue(allClients.Count == 2);
            Assert.IsTrue(returnedClients.Count() == 2);
            _mock.VerifyAll();
        }

        

        [TestMethod]
        public void GetClientById()
        {
            _mock.Setup(x => x.GetById(It.IsAny<int>())).Returns(new Client());

            _mock.Object.GetById(2);

            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetClients()
        {
            _mock.Setup(x => x.SelectAll()).Returns(new List<Client>());

            _mock.Object.SelectAll();

            _mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateClient()
        {
            _mock.Setup(x => x.Update(It.IsAny<Client>()));

            _mock.Object.Update(new Client());

            _mock.VerifyAll();
        }
    }
}