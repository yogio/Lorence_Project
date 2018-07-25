using System;
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

        //When needed, we get from the client an HttpGet request of Authentication.
        //in this stage, we send the client a view() of the Login screen.
        [HttpGet]
        public ActionResult Login()
        {
            UserAuthentication model = new UserAuthentication();
            return View(model);
        }
        //After getting the information needed for Authentication (UserName and Password)
        //we check if it's a valid entity, if not then we send the 
        [HttpPost]
        public ActionResult Login(UserAuthentication model)
        {
            User userCheck = null;

            if (!ModelState.IsValid)
                return View(model);

            if (IsUserExist(model) != false && IsPasswordCorrect(model))
            {
                //creating a user session
                //Session["UserID"] = Guid.NewGuid();
                userCheck = GetUser(model);
                Session["UserName"] = userCheck.UserName;
                Session["UserKind"] = userCheck.userKind;
                Session["Password"] = userCheck.Password;
                //HttpContext.a
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid Login Attempt.");
            return View(model);

        }

        private bool IsPasswordCorrect(UserAuthentication model)
        {
            return GetUser(model).Password == model.Password;
        }

        private User GetUser(UserAuthentication model)
        {
            return db.Users.First(c => c.UserName == model.UserName);
        }

        private bool IsUserExist(UserAuthentication model)
        {
            return db.Users.Any(c => c.UserName == model.UserName);
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
 
    }
}
