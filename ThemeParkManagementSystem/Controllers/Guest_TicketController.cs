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
    public class Guest_TicketController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Guest_Ticket
        public ActionResult Index()
        {
            var gUEST_TICKET = db.GUEST_TICKET.Include(g => g.GUEST).Include(g => g.TICKET);
            return View(gUEST_TICKET.ToList());
        }

        // GET: Guest_Ticket/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_TICKET gUEST_TICKET = db.GUEST_TICKET.Find(id);
            if (gUEST_TICKET == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_TICKET);
        }

        // GET: Guest_Ticket/Create
        public ActionResult Create()
        {
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName");
            ViewBag.TicketID = new SelectList(db.TICKETs, "TicketID", "TicketID");
            return View();
        }

        // POST: Guest_Ticket/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,GuestID,DatePurchased")] GUEST_TICKET gUEST_TICKET)
        {
            if (ModelState.IsValid)
            {
                db.GUEST_TICKET.Add(gUEST_TICKET);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_TICKET.GuestID);
            ViewBag.TicketID = new SelectList(db.TICKETs, "TicketID", "TicketID", gUEST_TICKET.TicketID);
            return View(gUEST_TICKET);
        }

        // GET: Guest_Ticket/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_TICKET gUEST_TICKET = db.GUEST_TICKET.Find(id);
            if (gUEST_TICKET == null)
            {
                return HttpNotFound();
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_TICKET.GuestID);
            ViewBag.TicketID = new SelectList(db.TICKETs, "TicketID", "TicketID", gUEST_TICKET.TicketID);
            return View(gUEST_TICKET);
        }

        // POST: Guest_Ticket/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,GuestID,DatePurchased")] GUEST_TICKET gUEST_TICKET)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gUEST_TICKET).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GuestID = new SelectList(db.GUESTs, "GuestID", "FirstName", gUEST_TICKET.GuestID);
            ViewBag.TicketID = new SelectList(db.TICKETs, "TicketID", "TicketID", gUEST_TICKET.TicketID);
            return View(gUEST_TICKET);
        }

        // GET: Guest_Ticket/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GUEST_TICKET gUEST_TICKET = db.GUEST_TICKET.Find(id);
            if (gUEST_TICKET == null)
            {
                return HttpNotFound();
            }
            return View(gUEST_TICKET);
        }

        // POST: Guest_Ticket/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GUEST_TICKET gUEST_TICKET = db.GUEST_TICKET.Find(id);
            db.GUEST_TICKET.Remove(gUEST_TICKET);
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
