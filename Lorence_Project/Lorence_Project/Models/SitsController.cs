using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Lorence_Project.Models
{
    public class SitsController : Controller
    {
        private SitContext db = new SitContext();

        // GET: Sits
        public ActionResult Index()
        {
            return View(db.SitC.ToList());
        }

        // GET: Sits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sit sit = db.SitC.Find(id);
            if (sit == null)
            {
                return HttpNotFound();
            }
            return View(sit);
        }

        // GET: Sits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SitName")] Sit sit)
        {
            if (ModelState.IsValid)
            {
                db.SitC.Add(sit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sit);
        }

        // GET: Sits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sit sit = db.SitC.Find(id);
            if (sit == null)
            {
                return HttpNotFound();
            }
            return View(sit);
        }

        // POST: Sits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SitName")] Sit sit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sit);
        }

        // GET: Sits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sit sit = db.SitC.Find(id);
            if (sit == null)
            {
                return HttpNotFound();
            }
            return View(sit);
        }

        // POST: Sits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sit sit = db.SitC.Find(id);
            db.SitC.Remove(sit);
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
