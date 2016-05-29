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
        private Mock<IClientRepository> _mock;

        [TestInitialize]
        public void TestInitialize()
        {
            _mock = new Mock<IClientRepository>();
        }

        [TestMethod]
        public void InsertClient_Zero_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.InsertClient(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            _mock.Setup(x => x.GetClients()).Returns(allClients);

            Assert.IsTrue(!_mock.Object.GetClients().Any());
        }

        [TestMethod]
        public void InsertClient_One_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.InsertClient(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            _mock.Setup(x => x.GetClients()).Returns(allClients);

            _mock.Object.InsertClient(new Client());

            Assert.IsTrue(_mock.Object.GetClients().Count() == 1);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void InsertClient_Two_Exists()
        {
            var allClients = new List<Client>();
            _mock.Setup(x => x.InsertClient(It.IsAny<Client>()))
                .Callback((Client c) => { allClients.Add(c); });
            _mock.Setup(x => x.GetClients()).Returns(allClients);

            _mock.Object.InsertClient(new Client());
            _mock.Object.InsertClient(new Client());

            Assert.IsTrue(_mock.Object.GetClients().Count() == 2);
            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetClientById()
        {
            _mock.Setup(x => x.GetClientById(It.IsAny<int>())).Returns(new Client());

            _mock.Object.GetClientById(2);

            _mock.VerifyAll();
        }

        [TestMethod]
        public void GetClients()
        {
            _mock.Setup(x => x.GetClients()).Returns(new List<Client>());

            _mock.Object.GetClients();

            _mock.VerifyAll();
        }

        [TestMethod]
        public void UpdateClient()
        {
            _mock.Setup(x => x.UpdateClient(It.IsAny<Client>()));

            _mock.Object.UpdateClient(new Client());

            _mock.VerifyAll();
        }
    }
}