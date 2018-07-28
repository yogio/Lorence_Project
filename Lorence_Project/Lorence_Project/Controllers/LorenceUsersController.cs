using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lorence_Project.Models;

namespace Lorence_Project.Controllers
{
    public class LorenceUsersController : Controller
    {
        private LorenceDbContext db = new LorenceDbContext();

        // GET: LorenceUsers
        public ActionResult Index()
        {
            return View(db.LorenceUsers.ToList());
        }

        // GET: LorenceUsers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LorenceUser lorenceUser = db.LorenceUsers.Find(id);
            if (lorenceUser == null)
            {
                return HttpNotFound();
            }
            return View(lorenceUser);
        }

        // GET: LorenceUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LorenceUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Arrived,Approved,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] LorenceUser lorenceUser)
        {
            if (ModelState.IsValid)
            {
                db.LorenceUsers.Add(lorenceUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lorenceUser);
        }

        // GET: LorenceUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LorenceUser lorenceUser = db.LorenceUsers.Find(id);
            if (lorenceUser == null)
            {
                return HttpNotFound();
            }
            return View(lorenceUser);
        }

        // POST: LorenceUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Arrived,Approved,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName")] LorenceUser lorenceUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lorenceUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lorenceUser);
        }

        // GET: LorenceUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LorenceUser lorenceUser = db.LorenceUsers.Find(id);
            if (lorenceUser == null)
            {
                return HttpNotFound();
            }
            return View(lorenceUser);
        }

        // POST: LorenceUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            LorenceUser lorenceUser = db.LorenceUsers.Find(id);
            db.LorenceUsers.Remove(lorenceUser);
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
