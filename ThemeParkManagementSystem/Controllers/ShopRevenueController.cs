using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThemeParkManagementSystem.Models;




namespace ThemeParkManagementSystem.Controllers
{
    
    public class ShopRevenueController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();
        // GET: ShopRevenue
        public ActionResult Index(DateTime? date1, DateTime? date2)
        {
            Nullable<decimal> countlist = db.shoprevenue(date1, date2).ToList<Nullable<decimal>>().FirstOrDefault();

            var count = countlist;
            ViewData["Rev"] = count;
            return View();
            
        }

        // GET: ShopRevenue/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ShopRevenue/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ShopRevenue/Create
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

        // GET: ShopRevenue/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ShopRevenue/Edit/5
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

        // GET: ShopRevenue/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShopRevenue/Delete/5
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
