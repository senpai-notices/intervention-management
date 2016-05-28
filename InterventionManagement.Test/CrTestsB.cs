using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using ASDF.ENETCare.InterventionManagement.Test.Extensions;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test
{
    [TestClass]
    public class CrTestsB
    {
        private ClientR _repository;
        private Mock<DbSet<Client>> _mockClients;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockClients = new Mock<DbSet<Client>>();

            var mockContext = new Mock<IApplicationDbContext>();
            mockContext.SetupGet(c => c.Client).Returns(_mockClients.Object);

            _repository = new ClientR(mockContext.Object);
        }

        [TestMethod]
        public void ThisFails()
        {
            _repository.InsertClient(new Client { Name = "John Smith", Location = "53 Main St", DistrictId = 1 });
            var clients = _repository.GetClients();
            //clients.Should().HaveCount(1);
            Assert.AreEqual(1, clients.Count());
        }

        [TestMethod]
        public void InsertClient_Zero_Exists()
        {
            var client = new List<Client>();

            _mockClients.SetSource(client);

            var clients = _repository.GetClients();

            clients.Should().BeEmpty();
        }

        [TestMethod]
        public void InsertClient_One_Exists()
        {
            var client = new Client { Name = "John Smith", Location = "53 Main St", DistrictId = 1 };

            _mockClients.SetSource(new[] { client });

            var clients = _repository.GetClients();

            clients.Should().HaveCount(1);
        }

        [TestMethod]
        public void InsertClient_Two_Exists()
        {
            var client = new List<Client>
            {
                new Client { Name = "John Smith", Location = "53 Main St", DistrictId = 1},
                new Client { Name = "Donald", Location = "332 First Ave", DistrictId = 1}
            };

            _mockClients.SetSource(client);

            var clients = _repository.GetClients();

            clients.Should().HaveCount(2);
        }

    }
}
