using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lorence_Project.DAL;
using Lorence_Project.Models;

namespace Lorence_Project.Controllers
{
    public class OrderSitsController : Controller
    {
        private LorenceDbContext db = new LorenceDbContext();

        // GET: OrderSits
        public ActionResult Index()
        {
            return View(db.OrderSits.ToList());
        }

        // GET: OrderSits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSit orderSit = db.OrderSits.Find(id);
            if (orderSit == null)
            {
                return HttpNotFound();
            }
            return View(orderSit);
        }

        // GET: OrderSits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderSits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrderSitID,SitName,date,UserID,arrived,confirmedByAdmin")] OrderSit orderSit)
        {
            if (ModelState.IsValid)
            {
                db.OrderSits.Add(orderSit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(orderSit);
        }

        // GET: OrderSits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSit orderSit = db.OrderSits.Find(id);
            if (orderSit == null)
            {
                return HttpNotFound();
            }
            return View(orderSit);
        }

        // POST: OrderSits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrderSitID,SitName,date,UserID,arrived,confirmedByAdmin")] OrderSit orderSit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderSit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(orderSit);
        }

        // GET: OrderSits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderSit orderSit = db.OrderSits.Find(id);
            if (orderSit == null)
            {
                return HttpNotFound();
            }
            return View(orderSit);
        }

        // POST: OrderSits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderSit orderSit = db.OrderSits.Find(id);
            db.OrderSits.Remove(orderSit);
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
