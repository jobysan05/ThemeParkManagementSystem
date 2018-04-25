using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Controllers
{
    public class sController : Controller
    {
        // GET: s
        private tpdatabaseEntities db = new tpdatabaseEntities();
        public ActionResult Index()
        {
            
            Nullable<int> countList = db.RideCount(new DateTime(2017, 1, 1), new DateTime(2018, 12, 31), 7).ToList<Nullable<int>>().FirstOrDefault();
            var rideCount = countList.Value;                
            ViewData["RideCount"] = rideCount;
            return View();
        }

        // GET: s/Details/5
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
