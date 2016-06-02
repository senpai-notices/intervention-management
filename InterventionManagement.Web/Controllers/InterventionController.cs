using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class InterventionController : Controller
    {
        private readonly IGenericRepository<Intervention> _interventionRepository;
        private readonly IGenericRepository<InterventionTemplate> _interventionTemplateRepository;
        private readonly IGenericRepository<InterventionState> _interventionStateRepository;
        public InterventionController()
        {
            _interventionRepository = new GenericRepository<Intervention>(new ApplicationDbContext());         
            _interventionTemplateRepository = new GenericRepository<InterventionTemplate>(new ApplicationDbContext());
            _interventionStateRepository = new GenericRepository<InterventionState>(new ApplicationDbContext());
        }

        // GET: Intervention
        public ActionResult Index(int id)
        {
            var listModel = new InterventionsListViewModel()
            {
                Interventions = _interventionRepository.SelectAll().Where(x=>x.ClientId == id && x.InterventionStateId !=3),
                ClientId = id
            };
            //_clientId = id;
            return View(listModel);
        }

        public ActionResult ViewAllInterventions()
        {
            var list = new InterventionsListViewModel()
            {
                Interventions = _interventionRepository.SelectAll().Where(x => x.ProposerId == User.Identity.GetUserId())
            };

            return View(list);
        }

        public ActionResult ChangeState(int id)
        {

            var i = _interventionRepository.GetById(id);
            var model = new ChangeStateViewModel
            {
                CurrentInterventionState = i.InterventionState.Name,
                StateList = _interventionStateRepository.SelectAll()
            };


            return View(model);
        }

        [HttpPost]
        public ActionResult ChangeState(int id, ChangeStateViewModel model)
        {
            var i = _interventionRepository.GetById(id);
            try
            {
                if (ModelState.IsValid)
                {
                    i.InterventionStateId = Convert.ToInt32(model.NextInterventionState);
                    i.ApproverId = User.Identity.GetUserId();

                    _interventionRepository.Update(i);
                    _interventionRepository.Save();
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
                if (ModelState.IsValid)
                {                   
                    Intervention i = new Intervention();
                    i.DatePerformed = model.DatePerformed;
                    i.Hours = model.Hours;
                    i.Cost = model.Cost;
                    i.Notes = model.Notes;
                    i.RemainingLife = model.RemainingLife;
                    i.DateOfLastVisit = model.DateOfLastVisit;
                    i.ClientId = model.ClientId;


                    i.InterventionStateId = 1; //New intervention will always have a state of Proposed
                    i.InterventionTemplateId = Convert.ToInt32(model.InterventionTemplate);

                    i.ApproverId = User.Identity.GetUserId(); //<---
                    i.ProposerId = User.Identity.GetUserId();

                    _interventionRepository.Insert(i);
                    _interventionRepository.Save();
                }

                return RedirectToAction("Index",new {id = model.ClientId});
            }
            catch
            {
                return RedirectToAction("Index", new { id = model.ClientId});
            }
        }

        // GET: Intervention/Edit/5
        public ActionResult Edit(int id)
        {
            var i = _interventionRepository.GetById(id);
            var model = new EditInterventionViewModel
            {
                Notes = i.Notes,
                DateOfLastVisit = i.DateOfLastVisit,
                RemainingLife = i.RemainingLife,
                InterventionId = i.InterventionId,                
            };

            return View(model);
        }

        // POST: Intervention/Edit/5
        [HttpPost]
        public ActionResult Edit(int id,EditInterventionViewModel model)
        {
            try
            {
                var i = _interventionRepository.GetById(id);
                if (ModelState.IsValid)
                {
                    
                    
                    i.Notes = model.Notes;
                    i.RemainingLife = model.RemainingLife;
                    i.DateOfLastVisit = model.DateOfLastVisit;
                    
                    _interventionRepository.Update(i);
                    _interventionRepository.Save();

                
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
    }
}
