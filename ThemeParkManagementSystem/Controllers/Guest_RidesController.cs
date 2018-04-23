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
    public class Guest_RidesController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Guest_Rides
        public ActionResult Index()
        {
            var gUEST_RIDES = db.GUEST_RIDES.Include(g => g.GUEST).Include(g => g.RIDE);
            return View(gUEST_RIDES.ToList());
        }

        // GET: Guest_Rides/Details/5
        public ActionResult Details(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_RIDES gUEST_RIDES = db.GUEST_RIDES.Find(id);
            if (gUEST_RIDES == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_RIDES);
        }

        // GET: Guest_Rides/Create
        public ActionResult Create()
        {
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName");
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName");
            return View();
        }

        // POST: Guest_Rides/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RideDate,GuestID,RideID")] GUEST_RIDES gUEST_RIDES)
        {
            if (ModelState.IsValid)
            {
                db.GUEST_RIDES.Add(gUEST_RIDES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_RIDES.GuestID);
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", gUEST_RIDES.RideID);
            return View(gUEST_RIDES);
        }

        // GET: Guest_Rides/Edit/5
        public ActionResult Edit(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_RIDES gUEST_RIDES = db.GUEST_RIDES.Find(id);
            if (gUEST_RIDES == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_RIDES.GuestID);
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", gUEST_RIDES.RideID);
            return View(gUEST_RIDES);
        }

        // POST: Guest_Rides/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RideDate,GuestID,RideID")] GUEST_RIDES gUEST_RIDES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gUEST_RIDES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_RIDES.GuestID);
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", gUEST_RIDES.RideID);
            return View(gUEST_RIDES);
        }

        // GET: Guest_Rides/Delete/5
        public ActionResult Delete(DateTime id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_RIDES gUEST_RIDES = db.GUEST_RIDES.Find(id);
            if (gUEST_RIDES == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_RIDES);
        }

        // POST: Guest_Rides/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(DateTime id)
        {
            GUEST_RIDES gUEST_RIDES = db.GUEST_RIDES.Find(id);
            db.GUEST_RIDES.Remove(gUEST_RIDES);
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
