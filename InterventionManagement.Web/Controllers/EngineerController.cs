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

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class EngineerController : Controller
    {
        private IClientRepository clientRepository;
        // GET: Engineer
        public EngineerController()
        {
            this.clientRepository = new ClientRepository(new ApplicationDbContext());
        }

        public ActionResult Index()
        {
            var listModel = new ClientListsViewModel {Clients = clientRepository.GetClients()};
            //.Where(x=>x.DistrictId==1);
            
            return View(listModel.Clients);
        }

        // GET: Engineer/Details/5
        public ActionResult ViewDetails(int id)
        {
            
            Client client = clientRepository.GetClientById(id);
            var clientModel = new ClientDetailsViewModel
            {
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
                    DistrictId = 6,//change this
                    Name = createClientViewModel.Name,
                    Location = createClientViewModel.Location
                };
                

                clientRepository.InsertClient(client);
                clientRepository.Save();
                return RedirectToAction("Index");
            }

            return View(createClientViewModel);
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
