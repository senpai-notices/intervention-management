using System;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class InterventionController : Controller
    {
        private readonly IInterventionRepository _interventionRepo;
        private readonly IInterventionTemplateRepository _interventionTemplateRepo;
        private readonly IInterventionStateRepository _interventionStateRepo;
        private int? _hours;
        private decimal? _cost;

        public InterventionController()
            : this (new InterventionRepository(new ApplicationDbContext()),
                  new InterventionTemplateRepository(new ApplicationDbContext()),
                  new InterventionStateRepository(new ApplicationDbContext()))
        {
        }

        public InterventionController(IInterventionRepository interventionRepo, IInterventionTemplateRepository interventionTemplateRepo, IInterventionStateRepository interventionStateRepo)
        {
            _interventionRepo = interventionRepo;
            _interventionTemplateRepo = interventionTemplateRepo;
            _interventionStateRepo = interventionStateRepo;
        }

        // GET: Intervention
        /// <summary>
        /// This ActionResult will list all the interventions associated with a client and are not deleted
        /// </summary>
        /// <param name="id">Client Id</param>
        /// <returns></returns>
        public ActionResult Index(int id)
        {
            var listModel = new InterventionsListViewModel()
            {
                Interventions = _interventionRepo.GetInterventionsOfClient(id),
                ClientId = id
            };
            //_clientId = id;
            return View(listModel);
        }

        /// <summary>
        /// This ActionResult will list all the interventions that the engineer has created
        /// </summary>
        /// <returns></returns>
        public ActionResult ViewAllInterventions()
        {
            var list = new InterventionsListViewModel()
            {
                Interventions = _interventionRepo.GetInterventionsOfUser(User.Identity.GetUserId<int>())
            };

            return View(list);
        }

        /// <summary>
        /// This ActionResult will allow an Engineer to update the state of the intervention
        /// </summary>
        /// <param name="id">Id of the intervention - InterventionId</param>
        /// <returns></returns>
        public ActionResult ChangeState(int id)
        {

            var i = _interventionRepo.GetById(id);
            var model = new ChangeStateViewModel
            {
                CurrentInterventionState = i.InterventionState.Name,
                StateList = _interventionStateRepo.SelectAll()
            };
            return View(model);
        }
        /// <summary>
        /// This ActionResult will update the intervention state of the intervention
        /// </summary>
        /// <param name="id">Id of the intervention to be updated</param>
        /// <param name="model">view model to be checked</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult ChangeState(int id, ChangeStateViewModel model)
        {
            GetApprovalInfo();
            var i = _interventionRepo.GetById(id);
            try
            {
                if (ModelState.IsValid)
                {
                    i.InterventionStateId = Convert.ToInt32(model.NextInterventionState);
                    if (i.Cost > _cost || i.Hours > _hours)
                    {
                        return View("ErrorApprove");
                    }
                    else
                    {                       
                        i.ApproverId = User.Identity.GetUserId<int>();
                        _interventionRepo.Update(i);
                    }
                }
            }
            catch (Exception)
            {
                
                return View();
            }
            return RedirectToAction("Index",new {id = i.ClientId});
        }


        // GET: Intervention/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        /// <summary>
        /// This ActionResult will allow the Engineer to create an intervention
        /// </summary>
        /// <param name="id">ClientId</param>
        /// <returns></returns>
        // GET: Intervention/Create
        public ActionResult Create(int id)
        {
            
            var createModel = new CreateInterventionViewModel
            {
               TemplateList = _interventionTemplateRepo.SelectAll(),
               ClientId = id
               
            };

            return View(createModel);
        }

        /// <summary>
        /// This AcrionResult will create an intervention according to the model
        /// </summary>
        /// <param name="model">The model to be checked</param>
        /// <returns></returns>
        // POST: Intervention/Create
        [HttpPost]
        public ActionResult Create(CreateInterventionViewModel model)
        {
            
/*            try
            {*/
                if (ModelState.IsValid)
                {
                GetApprovalInfo();
                    var intervention = new Intervention
                    {
                        DatePerformed = model.DatePerformed,
                        Hours = model.Hours,
                        Cost = model.Cost,
                        Notes = model.Notes,
                        RemainingLife = model.RemainingLife,
                        DateOfLastVisit = model.DateOfLastVisit,
                        ClientId = model.ClientId
                    };

                    if (intervention.Cost > _cost || intervention.Hours > _hours)
                    {
                        intervention.InterventionStateId = 1;
                        intervention.ApproverId = (int?) null;
                    }
                    else
                    {
                        intervention.InterventionStateId = 2;
                        intervention.ApproverId = User.Identity.GetUserId<int>();
                }
                    
                    intervention.InterventionTemplateId = Convert.ToInt32(model.InterventionTemplate);                    
                    intervention.ProposerId = User.Identity.GetUserId<int>();
                    _interventionRepo.Insert(intervention);
                }

                return RedirectToAction("Index",new {id = model.ClientId});
/*            }
            catch
            {
                return RedirectToAction("Index", new { id = model.ClientId});
            }*/
        }

        /// <summary>
        /// This ActionResult will allow the Engineer to edit the quality management of the intervention
        /// </summary>
        /// <param name="id">Id of the intervention to be edited - InterventionId</param>
        /// <returns></returns>
        // GET: Intervention/Edit/5
        public ActionResult Edit(int id)
        {
            var i = _interventionRepo.GetById(id);
            var model = new EditInterventionViewModel
            {
                Notes = i.Notes,
                DateOfLastVisit = i.DateOfLastVisit,
                RemainingLife = i.RemainingLife,
                InterventionId = i.InterventionId,                
            };

            return View(model);
        }

        /// <summary>
        /// This ActionResult will allow the Engineer to edit the quality management of the intervention based on the model
        /// </summary>
        /// <param name="id"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: Intervention/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,EditInterventionViewModel model)
        {
            try
            {
                var i = _interventionRepo.GetById(id);
                if (ModelState.IsValid)
                {
                    
                    
                    i.Notes = model.Notes;
                    i.RemainingLife = model.RemainingLife;
                    i.DateOfLastVisit = model.DateOfLastVisit;
                    
                    _interventionRepo.Update(i);
                }

                return RedirectToAction("Index", new { id = i.ClientId });

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

        private void GetApprovalInfo()
        {
            var userManager = new UserManager<ApplicationUser, int>(new UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId<int>());
            _cost = user.Cost;
            _hours = user.Hours;
        }
    }
}
