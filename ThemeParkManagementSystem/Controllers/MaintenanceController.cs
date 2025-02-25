﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class MaintenanceController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        private void isAdmin()
        {
            try
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    ViewData["userRole"] = true;
                }
                else
                {
                    ViewData["userRole"] = false;
                }
            }
            catch (Exception e)
            {
                ViewData["userRole"] = false;
            }
        }

        public ActionResult CompleteMaintenance(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            MAINTENANCE mAINTENANCE = db.MAINTENANCEs.Find(id);
            if (mAINTENANCE == null)
            {
                return HttpNotFound();
            }
            mAINTENANCE.EndTime = DateTime.Now;
            RIDE rIDE = db.RIDES.Find(mAINTENANCE.RideID);
            rIDE.IsOpen = true;
            db.SaveChanges();
            string url = this.Request.UrlReferrer.AbsolutePath;
            return Redirect(url);
        }

        // GET: Maintenance
        public ActionResult Index()
        {
            isAdmin();
            var mAINTENANCEs = db.MAINTENANCEs.Include(m => m.RIDE);
            return View(mAINTENANCEs.ToList());
        }

        // GET: Maintenance/Details/5
        public ActionResult Details(int? id)
        {
            isAdmin();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENANCE mAINTENANCE = db.MAINTENANCEs.Find(id);
            if (mAINTENANCE == null)
            {
                return HttpNotFound();
            }
            return View(mAINTENANCE);
        }

        // GET: Maintenance/Create
        public ActionResult Create()
        {
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName");
            return View();
        }

        // POST: Maintenance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CaseID,RideID,StartTime,EndTime,Summary")] MAINTENANCE mAINTENANCE)
        {
            if (ModelState.IsValid)
            {
                db.MAINTENANCEs.Add(mAINTENANCE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENANCE.RideID);
            return View(mAINTENANCE);
        }

        // GET: Maintenance/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENANCE mAINTENANCE = db.MAINTENANCEs.Find(id);
            if (mAINTENANCE == null)
            {
                return HttpNotFound();
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENANCE.RideID);
            return View(mAINTENANCE);
        }

        // POST: Maintenance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CaseID,RideID,StartTime,EndTime,Summary")] MAINTENANCE mAINTENANCE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mAINTENANCE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RideID = new SelectList(db.RIDES, "RideID", "RideName", mAINTENANCE.RideID);
            return View(mAINTENANCE);
        }

        // GET: Maintenance/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MAINTENANCE mAINTENANCE = db.MAINTENANCEs.Find(id);
            if (mAINTENANCE == null)
            {
                return HttpNotFound();
            }
            return View(mAINTENANCE);
        }

        // POST: Maintenance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MAINTENANCE mAINTENANCE = db.MAINTENANCEs.Find(id);
            db.MAINTENANCEs.Remove(mAINTENANCE);
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
