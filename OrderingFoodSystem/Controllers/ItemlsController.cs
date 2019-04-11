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
    public class ItemlsController : Controller
    {
        private ItemlsDBContext db = new ItemlsDBContext();

        // GET: Itemls
        public ActionResult Index()
        {
            return View(db.Itemlss.ToList());
        }

        // GET: Itemls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemls itemls = db.Itemlss.Find(id);
            if (itemls == null)
            {
                return HttpNotFound();
            }
            return View(itemls);
        }

        // GET: Itemls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Itemls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,Name,Price")] Itemls itemls)
        {
            if (ModelState.IsValid)
            {
                db.Itemlss.Add(itemls);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(itemls);
        }

        // GET: Itemls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemls itemls = db.Itemlss.Find(id);
            if (itemls == null)
            {
                return HttpNotFound();
            }
            return View(itemls);
        }

        // POST: Itemls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,Name,Price")] Itemls itemls)
        {
            if (ModelState.IsValid)
            {
                db.Entry(itemls).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(itemls);
        }

        // GET: Itemls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Itemls itemls = db.Itemlss.Find(id);
            if (itemls == null)
            {
                return HttpNotFound();
            }
            return View(itemls);
        }

        // POST: Itemls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Itemls itemls = db.Itemlss.Find(id);
            db.Itemlss.Remove(itemls);
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
