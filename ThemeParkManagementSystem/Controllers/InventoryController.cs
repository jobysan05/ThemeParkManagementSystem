using Microsoft.AspNet.Identity;
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
    public class InventoryController : Controller
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

        // GET: Inventory
        public ActionResult Index()
        {
            isAdmin();
            var iNVENTORies = db.INVENTORies.Include(i => i.SHOP);
            return View(iNVENTORies.ToList());
        }

        // GET: Inventory/Details/5
        public ActionResult Details(int? id)
        {
            isAdmin();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // GET: Inventory/Create
        public ActionResult Create()
        {
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName");
            return View();
        }

        // POST: Inventory/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductID,ProductName,ProductPrice,ProductStock,ShopID")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.INVENTORies.Add(iNVENTORY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", iNVENTORY.ShopID);
            return View(iNVENTORY);
        }

        // GET: Inventory/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", iNVENTORY.ShopID);
            return View(iNVENTORY);
        }

        // POST: Inventory/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductID,ProductName,ProductPrice,ProductStock,ShopID")] INVENTORY iNVENTORY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(iNVENTORY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShopID = new SelectList(db.SHOPS, "ShopID", "ShopName", iNVENTORY.ShopID);
            return View(iNVENTORY);
        }

        // GET: Inventory/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            if (iNVENTORY == null)
            {
                return HttpNotFound();
            }
            return View(iNVENTORY);
        }

        // POST: Inventory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            INVENTORY iNVENTORY = db.INVENTORies.Find(id);
            db.INVENTORies.Remove(iNVENTORY);
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
