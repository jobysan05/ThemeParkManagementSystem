using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        private tpdatabaseEntities db = new tpdatabaseEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TicketRevenue(DateTime? date1, DateTime? date2)
        {
            decimal? countlist = db.revenue(date1, date2).ToList().FirstOrDefault();
            var count = countlist.Value;
            ViewData["TicketRevenue"] = count;
            return View();
        }

        public ActionResult RidePopularity(DateTime? date1, DateTime? date2, int? id)
        {
            int? countList = db.RideCount(date1, date2, id).ToList().FirstOrDefault();
            var rideCount = countList.Value;
            ViewData["RidePopularity"] = rideCount;
            return View();
        }

        // GET: Reports/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: s/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: s/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: s/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: s/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: s/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: s/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
