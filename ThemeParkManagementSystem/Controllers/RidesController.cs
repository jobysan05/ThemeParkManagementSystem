using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Controllers
{
    public class RidesController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Rides
        public ActionResult Index()
        {
            return View(db.RIDES.ToList());
        }

        // GET: Rides/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDE rIDE = db.RIDES.Find(id);
            if (rIDE == null)
            {
                return HttpNotFound();
            }
            return View(rIDE);
        }

        // GET: Rides/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideID,RideName,RidePrice,IsOutside,RainOutCount,IsOpen")] RIDE rIDE)
        {
            if (ModelState.IsValid)
            {
                db.RIDES.Add(rIDE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rIDE);
        }

        // GET: Rides/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDE rIDE = db.RIDES.Find(id);
            if (rIDE == null)
            {
                return HttpNotFound();
            }
            return View(rIDE);
        }

        // POST: Rides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideID,RideName,RidePrice,IsOutside,RainOutCount,IsOpen")] RIDE rIDE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rIDE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rIDE);
        }

        // GET: Rides/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDE rIDE = db.RIDES.Find(id);
            if (rIDE == null)
            {
                return HttpNotFound();
            }
            return View(rIDE);
        }

        // POST: Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RIDE rIDE = db.RIDES.Find(id);
            db.RIDES.Remove(rIDE);
            db.SaveChanges();
            return RedirectToAction("Index");
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
