﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Business;
using ASDF.ENETCare.InterventionManagement.Business.Repositories;

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
            var clients = clientRepository.GetClients().Where(x=>x.DistrictId==1);
            return View(clients.ToList());
        }

        // GET: Engineer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Engineer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engineer/Create
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

        // GET: Engineer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Engineer/Edit/5
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