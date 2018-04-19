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
    public class TicketsController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(db.TICKETs.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKETs.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,TicketType,TicketPrice,datePurchased")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.TICKETs.Add(tICKET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tICKET);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKETs.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,TicketType,TicketPrice,datePurchased")] TICKET tICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tICKET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tICKET);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TICKET tICKET = db.TICKETs.Find(id);
            if (tICKET == null)
            {
                return HttpNotFound();
            }
            return View(tICKET);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TICKET tICKET = db.TICKETs.Find(id);
            db.TICKETs.Remove(tICKET);
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
