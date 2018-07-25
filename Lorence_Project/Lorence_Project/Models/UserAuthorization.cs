using Lorence_Project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lorence_Project.Models
{
    public class UserAuthorization : AuthorizeAttribute
    {
        //private LorenceDbContext db = new LorenceDbContext();

       // public UserKind userKind = new UserKind();

        private readonly UserKind[] allowedroles;

        public UserAuthorization(params UserKind[] roles)
        {
            allowedroles = roles;
        }
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //var userKind = db.Users.Single(c => c.UserName.ToString() == HttpContext.Current.Session["UserName"].ToString()).userKind;
            bool authorize = false;
            foreach (var role in allowedroles)
            {
                if (HttpContext.Current.Session.Count != 0
                    && HttpContext.Current.Session["UserKind"].ToString() == role.ToString())
                {
                    //return true if Entity has current user(active) with specific role
                    authorize = true; 
                }
            }
            return authorize;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}