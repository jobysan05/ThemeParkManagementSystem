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
        public ActionResult Index(DateTime? date1, DateTime? date2, int? id)
        {
            
            if (id == null)
            {
                Nullable<int> popularRideID = db.topRides(date1, date2).ToList<Nullable<int>>().FirstOrDefault();

                var popularID = popularRideID;

                DateTime? d1 = date1;
                DateTime? d2 = date2;
                Nullable<int> numOfGuest = db.Guestcount(d1, d2, popularID).ToList<Nullable<int>>().FirstOrDefault();
                var guestCount = numOfGuest.Value;

                var result = "The ID for the most popular ride is  " + popularID + " and it had " + numOfGuest + " guests";

                ViewData["Result"] = result;
                
                return View();

            }
            else
            {
                Nullable<int> countList = db.RideCount(date1, date2, id).ToList<Nullable<int>>().FirstOrDefault();
                var rideCount = countList.Value;

                var resultt = "Ride " + id + " had  " + rideCount + " guests between the choosen dates";
                ViewData["Result"] = resultt;
            }
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
