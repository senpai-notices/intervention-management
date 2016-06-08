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
    public class ClientRepositoryTest
    {
        private IList<Client> _clients;
        private Mock<IClientRepository> _mockRepo;

        [TestInitialize]
        public void Initialize()
        {
            _clients = new List<Client>
            {
                new Client { ClientId = 1, DistrictId = 5, Name = "Alex", Location = "Sydney" },
                new Client { ClientId = 2, DistrictId = 5, Name = "Bob", Location = "Ultimo" },
                new Client { ClientId = 3, DistrictId = 1, Name = "Chris", Location = "Chippendale" },
                new Client { ClientId = 4, DistrictId = 2, Name = "Derek", Location = "Surry Hills" }
            };

            _mockRepo = new Mock<IClientRepository>();

            _mockRepo.Setup(m => m.SelectAll()).Returns(_clients);
            _mockRepo.Setup(m => m.GetById(It.IsAny<int>()))
                .Returns((int i) => _clients.Single(x => x.ClientId == i));
            _mockRepo.Setup(m => m.Insert(It.IsAny<Client>())).Callback((Client c) => { _clients.Add(c); });
            _mockRepo.Setup(m => m.Update(It.IsAny<Client>())).Callback((Client c) =>
            {
                var temp = _clients.SingleOrDefault(x => x.ClientId == c.ClientId);
                _clients.Remove(temp);
                _clients.Add(c);
            });

            _mockRepo.Setup(m => m.GetClientsOfDistrict(It.IsAny<int>()))
                .Returns((int i) =>_clients.Where(x => x.DistrictId == i));
        }

        [TestMethod]
        public void SelectAll_Normal_AllReturned()
        {
            var returned = _mockRepo.Object.SelectAll();
            Assert.IsTrue(_clients.Count == returned.Count());
        }

        [TestMethod]
        public void GetById_Normal_ClientReturned()
        {
            var returned = _mockRepo.Object.GetById(2);
            Assert.IsTrue(returned.ClientId == 2);
        }

        [TestMethod]
        public void Insert_Normal_ClientAdded()
        {
            _mockRepo.Object.Insert(new Client {ClientId = 5});
            Assert.IsTrue(_clients.Count == 5);
            Assert.IsTrue(_clients.Last().ClientId == 5);
        }

        [TestMethod]
        public void Update_Normal_ClientUpdated()
        {
            _mockRepo.Object.Update(new Client {ClientId = 4, Name = "Updated" });
            Assert.IsTrue(_clients.Count == 4);
            Assert.IsTrue(_clients.Single(c => c.ClientId == 4).Name == "Updated");
        }

        [TestMethod]
        public void GetClientsOfDistrict_Five_TwoReturned()
        {
            var returned = _mockRepo.Object.GetClientsOfDistrict(5);
            Assert.IsTrue(returned.Count() == 2);
        }

        [TestMethod]
        public void GetClientsOfDistrict_Three_ZeroReturned()
        {
            var returned = _mockRepo.Object.GetClientsOfDistrict(0);
            Assert.IsTrue(returned.Count() == 0);
        }
    }
}
