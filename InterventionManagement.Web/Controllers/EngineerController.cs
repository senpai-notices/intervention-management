using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
        public ActionResult CreateClient([Bind(Include = "ClientId,Name,Location,DistrictId")] Client client)
        {
            var c = new CreateClientViewModel();
            
            if (ModelState.IsValid)
            {
                client.DistrictId = 6; //change this
                c.Name = client.Name;
                c.Location = client.Location;
                  
                clientRepository.InsertClient(client);
                clientRepository.Save();
                return RedirectToAction("Index");
            }

            return View(c);
        }

        // GET: Engineer/Edit/5
        public ActionResult Edit(int id)
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
