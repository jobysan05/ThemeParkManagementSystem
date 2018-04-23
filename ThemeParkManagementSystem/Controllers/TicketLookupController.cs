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
    public class TicketLookupController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: TicketLookup
        public ActionResult Index()
        {
            return View(db.TICKETLOOKUPs.ToList());
        }

        // GET: TicketLookup/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETLOOKUP tICKETLOOKUP = db.TICKETLOOKUPs.Find(id);
            if (tICKETLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(tICKETLOOKUP);
        }

        // GET: TicketLookup/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TicketLookup/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TicketType,TicketPrice")] TICKETLOOKUP tICKETLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.TICKETLOOKUPs.Add(tICKETLOOKUP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tICKETLOOKUP);
        }

        // GET: TicketLookup/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETLOOKUP tICKETLOOKUP = db.TICKETLOOKUPs.Find(id);
            if (tICKETLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(tICKETLOOKUP);
        }

        // POST: TicketLookup/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TicketType,TicketPrice")] TICKETLOOKUP tICKETLOOKUP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKETLOOKUP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tICKETLOOKUP);
        }

        // GET: TicketLookup/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKETLOOKUP tICKETLOOKUP = db.TICKETLOOKUPs.Find(id);
            if (tICKETLOOKUP == null)
            {
                return HttpNotFound();
            }
            return View(tICKETLOOKUP);
        }

        // POST: TicketLookup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKETLOOKUP tICKETLOOKUP = db.TICKETLOOKUPs.Find(id);
            db.TICKETLOOKUPs.Remove(tICKETLOOKUP);
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
