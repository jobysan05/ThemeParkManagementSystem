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
    public class GuestsController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Guests
        public ActionResult Index()
        {
            return View(db.GUESTs.ToList());
        }

        // GET: Guests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST gUEST = db.GUESTs.Find(id);
            if (gUEST == null)
            {
                return HttpNotFound();
            }
            return View(gUEST);
        }

        // GET: Guests/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Guests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestID,FirstName,LastName,DateOfBirth")] GUEST gUEST)
        {
            if (ModelState.IsValid)
            {
                db.GUESTs.Add(gUEST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gUEST);
        }

        // GET: Guests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST gUEST = db.GUESTs.Find(id);
            if (gUEST == null)
            {
                return HttpNotFound();
            }
            return View(gUEST);
        }

        // POST: Guests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestID,FirstName,LastName,DateOfBirth")] GUEST gUEST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gUEST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gUEST);
        }

        // GET: Guests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST gUEST = db.GUESTs.Find(id);
            if (gUEST == null)
            {
                return HttpNotFound();
            }
            return View(gUEST);
        }

        // POST: Guests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GUEST gUEST = db.GUESTs.Find(id);
            db.GUESTs.Remove(gUEST);
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
