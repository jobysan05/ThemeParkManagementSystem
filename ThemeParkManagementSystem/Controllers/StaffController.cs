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
    public class StaffController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Staff
        public ActionResult Index(string search, int ?id)
        {
            var viewModel = new StaffIndexData();
            viewModel.Staff = db.STAFFs
                .Include(i => i.RIDES_STAFF);

            if (id != null)
            {
                ViewBag.EmployeeID = id.Value;
                viewModel.RidesStaff = viewModel.Staff.Where(
                    i => i.EmployeeID == id.Value).Single().RIDES_STAFF;
            }

            var vModel = new StaffIndexData();
            if(!String.IsNullOrEmpty(search))
               {
                vModel.Staff = db.STAFFs
                .Where(c => c.LastName.Contains(search));
                return View(vModel);
            }
            else
            {
                return View(viewModel);
            }
        }

        // GET: Staff/Details/5
        public ActionResult Details(int? id)
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
