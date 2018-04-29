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
using PagedList;

namespace ThemeParkManagementSystem.Controllers
{
    public class StaffController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        private void GetTypeNames()
        {
            for (int i = 0; i < 10; i++)
            {
                string empName = db.GetEmpTypes(i).FirstOrDefault();
                ViewData[i.ToString()] = empName;
            }
        }

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

        // GET: Staff
        public ActionResult Index(string searchBy, string search, int? page, string sortBy)
        {
            isAdmin();
            GetTypeNames();

            var staffs = from x in db.STAFFs.AsQueryable()
                         select x;
            if (searchBy == "FirstName")
            {
                return View(db.STAFFs.Where(x => x.FirstName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else if (searchBy == "LastName")
            {
                return View(db.STAFFs.Where(x => x.LastName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            }
            else
            {
                return View(staffs.ToList().ToPagedList(page ?? 1, 5));
            }
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
        {
            isAdmin();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // GET: Staff/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Staff/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,EmployeeType,FirstName,LastName")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.STAFFs.Add(sTAFF);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sTAFF);
        }

        // GET: Staff/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: Staff/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,EmployeeType,FirstName,LastName")] STAFF sTAFF)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTAFF).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sTAFF);
        }

        // GET: Staff/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STAFF sTAFF = db.STAFFs.Find(id);
            if (sTAFF == null)
            {
                return HttpNotFound();
            }
            return View(sTAFF);
        }

        // POST: Staff/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STAFF sTAFF = db.STAFFs.Find(id);
            db.STAFFs.Remove(sTAFF);
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
