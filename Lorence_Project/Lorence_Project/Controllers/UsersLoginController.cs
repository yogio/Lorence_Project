﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Lorence_Project.DAL;
using Lorence_Project.Models;

namespace Lorence_Project.Controllers
{
    public class UsersLoginController : Controller
    {
        private LorenceDbContext db = new LorenceDbContext();


        [HttpGet]
        public ActionResult Login()
        {
            UserAuthentication model = new UserAuthentication();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(UserAuthentication model)
        {
            User userCheck = null;
            if (!ModelState.IsValid)
                return View(model);
            if (db.Users.Any(c => c.UserName == model.UserName))
                userCheck = db.Users.First(c => c.UserName == model.UserName);
            
            if (userCheck != null
                && (userCheck.Password == model.Password)
                 && (userCheck.userKind == UserKind.Administrator))
            {
                    //creating a user session
                    Session["UserID"] = Guid.NewGuid();
                    return RedirectToAction("Index", "Home");   
            }
            
            ModelState.AddModelError("", "Invalid Login Attempt.");
            return View(model);
            
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            // it will clear the session at the end of request
            Session.Abandon(); 
            return RedirectToAction("index", "Home");
        }

        // GET: UsersLogin
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: UsersLogin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: UsersLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersLogin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,Password,userKind")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: UsersLogin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersLogin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,Password,userKind")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: UsersLogin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: UsersLogin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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