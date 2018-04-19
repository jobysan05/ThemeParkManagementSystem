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
    public class Shop_StaffController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Shop_Staff
        public ActionResult Index()
        {
            var sHOP_STAFF = db.SHOP_STAFF.Include(s => s.SHOP).Include(s => s.STAFF);
            return View(sHOP_STAFF.ToList());
        }

        // GET: Shop_Staff/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP_STAFF sHOP_STAFF = db.SHOP_STAFF.Find(id);
            if (sHOP_STAFF == null)
            {
                return HttpNotFound();
            }
            return View(sHOP_STAFF);
        }

        // GET: Shop_Staff/Create
        public ActionResult Create()
        {
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName");
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "EmployeeType");
            return View();
        }

        // POST: Shop_Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,ShopID,StartDate,EndDate")] SHOP_STAFF sHOP_STAFF)
        {
            if (ModelState.IsValid)
            {
                db.SHOP_STAFF.Add(sHOP_STAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", sHOP_STAFF.ShopID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "EmployeeType", sHOP_STAFF.EmployeeID);
            return View(sHOP_STAFF);
        }

        // GET: Shop_Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP_STAFF sHOP_STAFF = db.SHOP_STAFF.Find(id);
            if (sHOP_STAFF == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", sHOP_STAFF.ShopID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "EmployeeType", sHOP_STAFF.EmployeeID);
            return View(sHOP_STAFF);
        }

        // POST: Shop_Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,ShopID,StartDate,EndDate")] SHOP_STAFF sHOP_STAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOP_STAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", sHOP_STAFF.ShopID);
            ViewBag.EmployeeID = new SelectList(db.STAFFs, "EmployeeID", "EmployeeType", sHOP_STAFF.EmployeeID);
            return View(sHOP_STAFF);
        }

        // GET: Shop_Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP_STAFF sHOP_STAFF = db.SHOP_STAFF.Find(id);
            if (sHOP_STAFF == null)
            {
                return HttpNotFound();
            }
            return View(sHOP_STAFF);
        }

        // POST: Shop_Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOP_STAFF sHOP_STAFF = db.SHOP_STAFF.Find(id);
            db.SHOP_STAFF.Remove(sHOP_STAFF);
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
