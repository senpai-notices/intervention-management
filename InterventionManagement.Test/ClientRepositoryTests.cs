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
        [TestMethod]
        public void InsertClient_Two_Success()
        {
            var mock = ClientRepositoryFake();

            mock.Object.InsertClient(new Client() { Name = "John Smith", Location = "53 Main St", DistrictId = 1});
            mock.Object.InsertClient(new Client() { Name = "Donald", Location = "332 First Ave", DistrictId = 1});

            Assert.IsTrue(mock.Object.GetClients().Count() == 2);
        }

        [TestMethod]
        public void InsertNoClients()
        {
            
        }

        [TestMethod]
        public void GetClientById()
        { }

        [TestMethod]
        public void GetClients() { }

        private Mock<IClientRepository> ClientRepositoryFake()
        {
            var allClients = new List<Client>();
            var mock = new Mock<IClientRepository>();
            mock.Setup(x => x.InsertClient(It.IsAny<Client>()))
                .Callback((Client c) =>
                {
                    allClients.Add(c);
                });
            mock.Setup(x => x.GetClients()).Returns(allClients);
            mock.Setup(x => x.GetClientById(It.IsAny<int>()))
                .Callback((int id) =>
                {
                    allClients.Find(c => id == c.ClientId);
                });
            
            return mock;
        }
    }
}
