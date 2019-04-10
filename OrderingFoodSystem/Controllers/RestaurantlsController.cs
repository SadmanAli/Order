using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OrderingFoodSystem.Models;

namespace OrderingFoodSystem.Controllers
{
    public class RestaurantlsController : Controller
    {
        private RestaurantlsDBContext db = new RestaurantlsDBContext();

        // GET: Restaurantls
        public ActionResult Index()
        {
            return View(db.Restaurantlss.ToList());
        }

        // GET: Restaurantls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantls restaurantls = db.Restaurantlss.Find(id);
            if (restaurantls == null)
            {
                return HttpNotFound();
            }
            return View(restaurantls);
        }

        // GET: Restaurantls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurantls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RestaurantID,RestaurantName,Location")] Restaurantls restaurantls)
        {
            if (ModelState.IsValid)
            {
                db.Restaurantlss.Add(restaurantls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(restaurantls);
        }

        // GET: Restaurantls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantls restaurantls = db.Restaurantlss.Find(id);
            if (restaurantls == null)
            {
                return HttpNotFound();
            }
            return View(restaurantls);
        }

        // POST: Restaurantls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RestaurantID,RestaurantName,Location")] Restaurantls restaurantls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(restaurantls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(restaurantls);
        }

        // GET: Restaurantls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Restaurantls restaurantls = db.Restaurantlss.Find(id);
            if (restaurantls == null)
            {
                return HttpNotFound();
            }
            return View(restaurantls);
        }

        // POST: Restaurantls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Restaurantls restaurantls = db.Restaurantlss.Find(id);
            db.Restaurantlss.Remove(restaurantls);
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
