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
    public class Rides_StaffController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Rides_Staff
        public ActionResult Index()
        {
            var rIDES_STAFF = db.RIDES_STAFF.Include(r => r.RIDE).Include(r => r.STAFF);
            return View(rIDES_STAFF.ToList());
        }

        // GET: Rides_Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDES_STAFF rIDES_STAFF = db.RIDES_STAFF.Find(id);
            if (rIDES_STAFF == null)
            {
                return HttpNotFound();
            }
            return View(rIDES_STAFF);
        }

        // GET: Rides_Staff/Create
        public ActionResult Create()
        {
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName");
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "FirstName");
            return View();
        }

        // POST: Rides_Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,RideID,StartDate,EndDate")] RIDES_STAFF rIDES_STAFF)
        {
            if (ModelState.IsValid)
            {
                db.RIDES_STAFF.Add(rIDES_STAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", rIDES_STAFF.RideID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "FirstName", rIDES_STAFF.EmployeeID);
            return View(rIDES_STAFF);
        }

        // GET: Rides_Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDES_STAFF rIDES_STAFF = db.RIDES_STAFF.Find(id);
            if (rIDES_STAFF == null)
            {
                return HttpNotFound();
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", rIDES_STAFF.RideID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "FirstName", rIDES_STAFF.EmployeeID);
            return View(rIDES_STAFF);
        }

        // POST: Rides_Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,RideID,StartDate,EndDate")] RIDES_STAFF rIDES_STAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rIDES_STAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", rIDES_STAFF.RideID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "FirstName", rIDES_STAFF.EmployeeID);
            return View(rIDES_STAFF);
        }

        // GET: Rides_Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RIDES_STAFF rIDES_STAFF = db.RIDES_STAFF.Find(id);
            if (rIDES_STAFF == null)
            {
                return HttpNotFound();
            }
            return View(rIDES_STAFF);
        }

        // POST: Rides_Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RIDES_STAFF rIDES_STAFF = db.RIDES_STAFF.Find(id);
            db.RIDES_STAFF.Remove(rIDES_STAFF);
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
