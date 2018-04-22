using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Views
{
    public class Guest_ShopsController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Guest_Shops
        public ActionResult Index()
        {
            var gUEST_SHOPS = db.GUEST_SHOPS.Include(g => g.GUEST).Include(g => g.INVENTORY);
            return View(gUEST_SHOPS.ToList());
        }

        // GET: Guest_Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_SHOPS gUEST_SHOPS = db.GUEST_SHOPS.Find(id);
            if (gUEST_SHOPS == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_SHOPS);
        }

        // GET: Guest_Shops/Create
        public ActionResult Create()
        {
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName");
            ViewBag.ProductID = new SelectList(db.INVENTORies, "ProductID", "ProductName");
            return View();
        }

        // POST: Guest_Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GuestID,ProductID,TransactionID,Quantity,TransactionDate")] GUEST_SHOPS gUEST_SHOPS)
        {
            if (ModelState.IsValid)
            {
                db.GUEST_SHOPS.Add(gUEST_SHOPS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_SHOPS.GuestID);
            ViewBag.ProductID = new SelectList(db.INVENTORies, "ProductID", "ProductName", gUEST_SHOPS.ProductID);
            return View(gUEST_SHOPS);
        }

        // GET: Guest_Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_SHOPS gUEST_SHOPS = db.GUEST_SHOPS.Find(id);
            if (gUEST_SHOPS == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_SHOPS.GuestID);
            ViewBag.ProductID = new SelectList(db.INVENTORies, "ProductID", "ProductName", gUEST_SHOPS.ProductID);
            return View(gUEST_SHOPS);
        }

        // POST: Guest_Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GuestID,ProductID,TransactionID,Quantity,TransactionDate")] GUEST_SHOPS gUEST_SHOPS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gUEST_SHOPS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_SHOPS.GuestID);
            ViewBag.ProductID = new SelectList(db.INVENTORies, "ProductID", "ProductName", gUEST_SHOPS.ProductID);
            return View(gUEST_SHOPS);
        }

        // GET: Guest_Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_SHOPS gUEST_SHOPS = db.GUEST_SHOPS.Find(id);
            if (gUEST_SHOPS == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_SHOPS);
        }

        // POST: Guest_Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GUEST_SHOPS gUEST_SHOPS = db.GUEST_SHOPS.Find(id);
            db.GUEST_SHOPS.Remove(gUEST_SHOPS);
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
