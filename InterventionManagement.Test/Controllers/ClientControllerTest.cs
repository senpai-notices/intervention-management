using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Controllers;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ASDF.ENETCare.InterventionManagement.Test.Controllers
{
    [TestClass]
    public class ClientControllerTest
    {
        private Mock<IClientRepository> _clientRepoMock;
        private Mock<IInterventionRepository> _interventionRepoMock;
        private ClientController _objController;
        private List<Client> _listClient;
        private List<Intervention> _listIntervention;
        private Mock<IUserStore<ApplicationUser, int>> _userStoreMock;
        private UserManager<ApplicationUser, int> _userManager;

        [TestInitialize]
        public void Initialize()
        {
            _clientRepoMock = new Mock<IClientRepository>();
            _interventionRepoMock = new Mock<IInterventionRepository>();
            _objController = new ClientController(_clientRepoMock.Object, _interventionRepoMock.Object);
            _listClient = new List<Client>
            {
                new Client { ClientId = 1, DistrictId = 5, Name = "Alex", Location = "Sydney" },
                new Client { ClientId = 2, DistrictId = 5, Name = "Bob", Location = "Ultimo" },
                new Client { ClientId = 3, DistrictId = 1, Name = "Chris", Location = "Chippendale" },
                new Client { ClientId = 4, DistrictId = 2, Name = "Derek", Location = "Surry Hills" },
            };
            _listIntervention = new List<Intervention>
            {
                new Intervention { InterventionId = 1, ClientId = 4, Hours = 2, Cost = 400, ProposerId = 27, DatePerformed = new DateTime(2016,1,1), InterventionTemplateId = 1, InterventionStateId = 2},
                new Intervention { InterventionId = 2, ClientId = 3, Hours = 7, Cost = 455, ProposerId = 27, DatePerformed = new DateTime(2016,1,1), InterventionTemplateId = 1, InterventionStateId = 2},
                new Intervention { InterventionId = 3, ClientId = 2, Hours = 5, Cost = 600, ProposerId = 27, DatePerformed = new DateTime(2016,1,1), InterventionTemplateId = 1, InterventionStateId = 2},
            };

            _userStoreMock = new Mock<IUserStore<ApplicationUser, int>>();
            _userManager = new UserManager<ApplicationUser, int>(_userStoreMock.Object);
        }
        // http://techbrij.com/unit-testing-asp-net-mvc-controller-service
        [TestMethod]
        public void SelectAll()
        {
            _clientRepoMock.Setup(x => x.SelectAll()).Returns(_listClient);
            _userStoreMock.Setup(x => x.FindByIdAsync(0)).ReturnsAsync((ApplicationUser) null);

            var result = _objController.Index() as ViewResult;
            var viewModel = _objController.ViewData.Model as List<Client>;

            Assert.IsTrue(viewModel.Count == _listClient.Count);
        }   
    }
}
