using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class ManagerController : Controller
    {
        private readonly IGenericRepository<Intervention> _interventionRepository;
        private readonly IGenericRepository<InterventionState> _interventionStateRepository;
        // GET: Manager

        public ManagerController()
        {
            _interventionRepository = new GenericRepository<Intervention>(new ApplicationDbContext());
            _interventionStateRepository = new GenericRepository<InterventionState>(new ApplicationDbContext());
        }

        public ActionResult Index()
        {
            //var i = _ClientRepository.SelectAll().Where(x => x.DistrictId == GetDistrictId());
            var listViewModel = new InterventionsListViewModel
            {
                Interventions = _interventionRepository.SelectAll().Where(x => x.InterventionStateId == 1)
            };
            return View(listViewModel);
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
            return RedirectToAction("Index", new { id = i.ClientId });
        }

        // GET: Manager/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manager/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manager/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manager/Edit/5
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

        // GET: Manager/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manager/Delete/5
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
        private int GetDistrictId()
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
            var user = userManager.FindById(User.Identity.GetUserId());
            int districtId = user.DistrictId.GetValueOrDefault();
            return districtId;
        }
    }
}
