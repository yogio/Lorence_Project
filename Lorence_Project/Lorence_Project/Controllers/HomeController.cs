using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lorence_Project.Controllers
{
    [Authorize(Roles = "UserAuthentication")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}