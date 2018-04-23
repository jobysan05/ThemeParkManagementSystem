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
    public class ShopLookupController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: ShopLookup
        public ActionResult Index()
        {
            return View(db.SHOPLOOKUPs.ToList());
        }

        // GET: ShopLookup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPLOOKUP sHOPLOOKUP = db.SHOPLOOKUPs.Find(id);
            if (sHOPLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sHOPLOOKUP);
        }

        // GET: ShopLookup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopLookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ShopType")] SHOPLOOKUP sHOPLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.SHOPLOOKUPs.Add(sHOPLOOKUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHOPLOOKUP);
        }

        // GET: ShopLookup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPLOOKUP sHOPLOOKUP = db.SHOPLOOKUPs.Find(id);
            if (sHOPLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sHOPLOOKUP);
        }

        // POST: ShopLookup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ShopType")] SHOPLOOKUP sHOPLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOPLOOKUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHOPLOOKUP);
        }

        // GET: ShopLookup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOPLOOKUP sHOPLOOKUP = db.SHOPLOOKUPs.Find(id);
            if (sHOPLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sHOPLOOKUP);
        }

        // POST: ShopLookup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOPLOOKUP sHOPLOOKUP = db.SHOPLOOKUPs.Find(id);
            db.SHOPLOOKUPs.Remove(sHOPLOOKUP);
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
