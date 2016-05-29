using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class EngineerController : Controller
    {
        private readonly IGenericRepository<Client> _clientRepository;
        
        // GET: Engineer
        public EngineerController()
        {
            this._clientRepository = new GenericRepository<Client>(new ApplicationDbContext());
        }

        public ActionResult Index(int id)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            var districtId = user.DistrictId;
            var listModel = new ClientListsViewModel {Clients = clientRepository.SelectAll().Where(x => x.DistrictId == districtId)};
            
            return View(listModel);
        }

        // GET: Engineer/Details/5
        public ActionResult ViewDetails(int id)
        {
            
            Client client = _clientRepository.GetById(id);
            var clientModel = new ClientDetailsViewModel
            {
                Id = id,
                Name = client.Name,
                Location = client.Location
            };

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(clientModel);
            
        }

        // GET: Engineer/Create
        public ActionResult CreateClient()
        {
            return View();
        }

        // POST: Engineer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(CreateClientViewModel createClientViewModel)
        {
            //var c = new CreateClientViewModel();
            
            if (ModelState.IsValid)
            {
                Client client = new Client
                {
                    DistrictId = _engineerDistrictId,
                    Name = createClientViewModel.Name,
                    Location = createClientViewModel.Location
                };
                

                _clientRepository.Insert(client);
                _clientRepository.Save();
                return RedirectToAction("Index");
            }

            return View(createClientViewModel);
        }

        public ActionResult ViewInterventions(int id)
        {
            return RedirectToAction("Index", "Intervention", new { id }); //Move to different page. id is equal to client ID. See Engineer/Details.cshtml

        }

        // GET: Engineer/Edit/5
        public ActionResult EditDetails(int id)
        {
            return View();
        }

        // POST: Engineer/Edit/5
        [HttpPost]
        public ActionResult EditDetails(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Engineer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Engineer/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
