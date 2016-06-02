using System.Linq;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class InterventionController : Controller
    {
        private readonly IGenericRepository<Intervention> _interventionRepository;
        private readonly IGenericRepository<InterventionState> _interventionStateRepository;
        private readonly IGenericRepository<InterventionTemplate> _interventionTemplateRepository;
        private int _clientId;

        public InterventionController()
        {
            _interventionRepository = new GenericRepository<Intervention>(new ApplicationDbContext());
            _interventionStateRepository = new GenericRepository<InterventionState>(new ApplicationDbContext());
            _interventionTemplateRepository = new GenericRepository<InterventionTemplate>(new ApplicationDbContext());
        }

        // GET: Intervention
        public ActionResult Index(int id)
        {
            var listModel = new InterventionsListViewModel()
            {
                Interventions = _interventionRepository.SelectAll().Where(x=>x.ClientId == id),
                ClientId = id
            };
            //_clientId = id;
            return View(listModel);
        }

        // GET: Intervention/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Intervention/Create
        public ActionResult Create(int id)
        {
            var createModel = new CreateInterventionViewModel
            {
               TemplateList = _interventionTemplateRepository.SelectAll(),
               ClientId = id
               
            };
            return View(createModel);
        }

        // POST: Intervention/Create
        [HttpPost]
        public ActionResult Create(CreateInterventionViewModel model)
        {
            try
            {
                //Intervention i = new Intervention();
                //i.DatePerformed = collection["DatePerformed"];
               
               // _interventionRepository.Save();
                return RedirectToAction("Index",new {id = model.ClientId});
            }
            catch
            {
                return View();
            }
        }

        // GET: Intervention/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Intervention/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
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

        // GET: Intervention/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Intervention/Delete/5
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
