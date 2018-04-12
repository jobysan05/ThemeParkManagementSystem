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
    public class MaintenenceController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Maintenence
        public ActionResult Index()
        {
            var mAINTENENCEs = db.MAINTENENCEs.Include(m => m.RIDE);
            return View(mAINTENENCEs.ToList());
        }

        // GET: Maintenence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENENCE mAINTENENCE = db.MAINTENENCEs.Find(id);
            if (mAINTENENCE == null)
            {
                return HttpNotFound();
            }
            return View(mAINTENENCE);
        }

        // GET: Maintenence/Create
        public ActionResult Create()
        {
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName");
            return View();
        }

        // POST: Maintenence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,RideID,StartTime,EndTime,Summary")] MAINTENENCE mAINTENENCE)
        {
            if (ModelState.IsValid)
            {
                db.MAINTENENCEs.Add(mAINTENENCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENENCE.RideID);
            return View(mAINTENENCE);
        }

        // GET: Maintenence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENENCE mAINTENENCE = db.MAINTENENCEs.Find(id);
            if (mAINTENENCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENENCE.RideID);
            return View(mAINTENENCE);
        }

        // POST: Maintenence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,RideID,StartTime,EndTime,Summary")] MAINTENENCE mAINTENENCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAINTENENCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENENCE.RideID);
            return View(mAINTENENCE);
        }

        // GET: Maintenence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENENCE mAINTENENCE = db.MAINTENENCEs.Find(id);
            if (mAINTENENCE == null)
            {
                return HttpNotFound();
            }
            return View(mAINTENENCE);
        }

        // POST: Maintenence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MAINTENENCE mAINTENENCE = db.MAINTENENCEs.Find(id);
            db.MAINTENENCEs.Remove(mAINTENENCE);
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
