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
    public class StaffLookupController : Controller
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

        // GET: StaffLookup
        public ActionResult Index()
        {
            isAdmin();
            return View(db.STAFFLOOKUPs.ToList());
        }

        // GET: StaffLookup/Details/5
        public ActionResult Details(int? id)
        {
            isAdmin();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFFLOOKUP sTAFFLOOKUP = db.STAFFLOOKUPs.Find(id);
            if (sTAFFLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sTAFFLOOKUP);
        }

        // GET: StaffLookup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffLookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeType")] STAFFLOOKUP sTAFFLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.STAFFLOOKUPs.Add(sTAFFLOOKUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTAFFLOOKUP);
        }

        // GET: StaffLookup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFFLOOKUP sTAFFLOOKUP = db.STAFFLOOKUPs.Find(id);
            if (sTAFFLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sTAFFLOOKUP);
        }

        // POST: StaffLookup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeType")] STAFFLOOKUP sTAFFLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTAFFLOOKUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTAFFLOOKUP);
        }

        // GET: StaffLookup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFFLOOKUP sTAFFLOOKUP = db.STAFFLOOKUPs.Find(id);
            if (sTAFFLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(sTAFFLOOKUP);
        }

        // POST: StaffLookup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STAFFLOOKUP sTAFFLOOKUP = db.STAFFLOOKUPs.Find(id);
            db.STAFFLOOKUPs.Remove(sTAFFLOOKUP);
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
