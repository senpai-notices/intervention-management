using System;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Data.Repositories;
using ASDF.ENETCare.InterventionManagement.Web.Models.Reports;

//remove

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class AccountantController : Controller
    {
        // GET: Accountant
        public ActionResult Index()
        {
            return View();
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

            var report = new EngineerReport(interventions, engineers)._report;
            return View(report);
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

        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }


}
