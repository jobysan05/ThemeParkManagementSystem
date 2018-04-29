using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Controllers
{
    public class RevenueController : Controller
    {
        // GET: Revenue
        private tpdatabaseEntities db = new tpdatabaseEntities();
        public ActionResult Index(DateTime? date1, DateTime? date2)

        {
            
            Nullable<decimal> countlist = db.ticketrevenue(date1, date2).ToList<Nullable<decimal>>().FirstOrDefault();
            
            var count = countlist;
            ViewData["Revenue"] = count;
            return View();
        }

        // GET: Revenue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Revenue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Revenue/Create
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

        // GET: Revenue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Revenue/Edit/5
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

        // GET: Revenue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Revenue/Delete/5
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
