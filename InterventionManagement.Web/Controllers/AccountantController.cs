using System;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models;
using ASDF.ENETCare.InterventionManagement.Web.Models.Reports;
using EngineerReport = ASDF.ENETCare.InterventionManagement.Web.Models.Reports.EngineerReport;

//remove

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class AccountantController : Controller
    {
        
        // GET: Accountant
        public ActionResult Index()
        {
            EngineerRepository eRepo = new EngineerRepository();
            ManagerRepository mRepo = new ManagerRepository();
            DistrictRepository dRepo = new DistrictRepository(new ApplicationDbContext());
            var accountantIndex = new AccountantIndexViewModel
            {
                Engineers = eRepo.GetEngineers(),
                Managers = mRepo.GetManagers(),                
            };

            return View(accountantIndex);
        }

        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        public ActionResult TotalCostsByEngineerReport()
        {
            
            InterventionRepository iRepo = new InterventionRepository(new ApplicationDbContext());
            EngineerRepository eRepo = new EngineerRepository();

            var interventions = iRepo.SelectAll();
            var engineers = eRepo.GetEngineers();

            var report = new EngineerReport(interventions, engineers).Report;
            return View(report);
        }

        public ActionResult CostsByDistrictReport()
        {
            var context = new ApplicationDbContext();
            InterventionRepository interventionRepo = new InterventionRepository(context);
            var districtRepo = new Repository<District>(context);

            var interventions = interventionRepo.SelectAll();
            var districts = districtRepo.SelectAll();

            var reports = new DistrictReport(interventions, districts);
            return View(reports);
        }

        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        public ActionResult Edit(int id)
        {
            return View();
        }

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
    }


}
