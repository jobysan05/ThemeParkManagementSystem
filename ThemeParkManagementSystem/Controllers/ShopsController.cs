using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using ThemeParkManagementSystem.Models;

namespace ThemeParkManagementSystem.Controllers
{
    public class ShopsController : Controller
    {
        private tpdatabaseEntities db = new tpdatabaseEntities();

        // GET: Shops
        public ActionResult Index(string searchBy, string search, int? page, string sortBy, int? id)
        {
            var viewModel = new ShopIndexData();
            viewModel.Shops = db.SHOPS
                .Include(i => i.INVENTORies);

            if (id != null)
            {
                ViewBag.ShopID = id.Value;
                viewModel.Inventory = viewModel.Shops.Where(
                    i => i.ShopID == id.Value).Single().INVENTORies;
            }

            var vModel = new ShopIndexData();
            if(!String.IsNullOrEmpty(search))
            {
                vModel.Shops = db.SHOPS
                    .Where(c => c.ShopName.Contains(search));
                return View(vModel);
            }
            else
            {
                return View(viewModel);
            }

            //ViewBag.SortNameParameter = string.IsNullOrEmpty(sortBy) ? "ShopName desc" : "";

            //var shops = from x in db.SHOPS.AsQueryable()
            //            select x;

            //using (var context = new tpdatabaseEntities())
            //{
            //    var shops1 = context.SHOPS
            //        .Include(b => b.INVENTORies)
            //        .ToList();
            //}

            //switch (sortBy)
            //{
            //    case "ShopName desc":
            //        shops = shops.OrderByDescending(x => x.ShopName);
            //        break;
            //    default:
            //        shops = shops.OrderBy(x => x.ShopName);
            //        break;
            //}

            //if (searchBy == "Name")
            //{
            //    return View(db.SHOPS.Where(x => x.ShopName.StartsWith(search) || search == null).ToList().ToPagedList(page ?? 1, 5));
            //}
            //else
            //{
            //    return View(shops.ToList().ToPagedList(page ?? 1, 5));
            //}
        }

        // GET: Shops/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPS.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            return View(sHOP);
        }

        // GET: Shops/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Shops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShopID,ShopName,ShopType")] SHOP sHOP)
        {
            if (ModelState.IsValid)
            {
                db.SHOPS.Add(sHOP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sHOP);
        }

        // GET: Shops/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPS.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            return View(sHOP);
        }

        // POST: Shops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShopID,ShopName,ShopType")] SHOP sHOP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sHOP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sHOP);
        }

        // GET: Shops/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SHOP sHOP = db.SHOPS.Find(id);
            if (sHOP == null)
            {
                return HttpNotFound();
            }
            return View(sHOP);
        }

        // POST: Shops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SHOP sHOP = db.SHOPS.Find(id);
            db.SHOPS.Remove(sHOP);
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
