using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _clientRepo;
        
        // GET: Engineer
        public ClientController()
            : this (new ClientRepository(new ApplicationDbContext()))
        {
        }

        public ClientController(IClientRepository clientRepo)
        {
            _clientRepo = clientRepo;
        }

        /// <summary>
        /// This ActionResult will list all the clients in the Engineer's district
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            var listModel = new ClientListsViewModel {Clients = _clientRepo.GetClientsOfDistrict(GetCurrentDistrictId())};
            return View(listModel);
        }

        /// <summary>
        /// This ActionResult will redirect to Intervention Controller to list all the created interventions
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAllInterventions()
        {
            return RedirectToAction("ViewAllInterventions", "Intervention");
        }

        /// <summary>
        /// This ActionResult will allow the Engineer to view the detail of the client
        /// </summary>
        /// <param name="id">Id of the client to be viewed - ClientId</param>
        /// <returns></returns>
        // GET: Engineer/Details/5
        public ActionResult ViewDetails(int id)
        {
            
            var client = _clientRepo.GetById(id);
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

        /// <summary>
        /// This ActionResult will allow the Engineer to create a client
        /// </summary>
        /// <returns></returns>
        // GET: Engineer/Create
        public ActionResult CreateClient()
        {
            return View();
        }

        /// <summary>
        /// This ActionResult will allow the Engineer to create a client based on the model
        /// </summary>
        /// <param name="model">The model to be checked and used to create client</param>
        /// <returns></returns>
        // POST: Engineer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateClient(CreateClientViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var client = new Client
            {
                DistrictId = GetCurrentDistrictId(),
                Name = model.Name,
                Location = model.Location
            };
                
            _clientRepo.Insert(client);
            return RedirectToAction("Index");
        }

        /// <summary>
        /// This ActionResult will redirect to Intervention Controller and then it allows the Engineer to view the 
        /// interventions associated with this client
        /// </summary>
        /// <param name="id">id of the client to be viewed - ClientId</param>
        /// <returns></returns>
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

        /// <summary>
        /// This method is used to get the district id of the user
        /// </summary>
        /// <returns></returns>
        private int GetCurrentDistrictId()
        {
            var userManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId<int>());
            int districtId = user.DistrictId.GetValueOrDefault();
            return districtId;
        }
    }
}
