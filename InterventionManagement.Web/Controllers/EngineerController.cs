using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using ASDF.ENETCare.InterventionManagement.Data;

namespace ASDF.ENETCare.InterventionManagement.Web.Controllers
{
    public class EngineerController : Controller
    {
        private MainContext db = new MainContext();

        // GET: Engineer views clients in his/her own district
        public ActionResult Index() //Add int id as parameter to retrieve engineer id. Currently, we assume id is 6
        {
            
            var query = from client in db.Client where client.DistrictId == 6 select client; //Assume 6 is the DistrictID of the engineer

            return View(query); //db.Client.ToList() => This will show all clients
        }

        // GET: Engineer views details of a single client
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Engineer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Engineer create new client
        // NOTE: Engineer can only add client to
        // his/her own district
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,Location,DistrictId")] Client client)
        {
            if (ModelState.IsValid)
            {
                Client newClient = new Client();
                newClient.Name = client.Name;
                newClient.Location = client.Location;
                newClient.DistrictId = 6;// Assume 6 is the DistrictID of the engineer. Engineer can only add client to
                                         // his/her own district. To avoid trouble selecting the wrong district, we input it here    
                db.Client.Add(newClient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Engineer/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Engineer/Edit/5
        // Engineer edit client details, Name, Location
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Location,DistrictId")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Engineer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Client.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Engineer/Delete/5
        // Engineer delete a client (out of scope but nice to have)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Client.Find(id);
            db.Client.Remove(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ViewInterventions(int id)
        {
            return RedirectToAction("Index","Interventions",new {id}); //Move to different page. id is equal to client ID. See Engineer/Details.cshtml
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
