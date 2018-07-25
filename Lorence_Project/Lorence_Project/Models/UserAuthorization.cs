using Lorence_Project.DAL;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;



//This Class is used to verify Authorization to pages for users, depanding on their "UserKind".
namespace Lorence_Project.Models
{

    public class UserAuthorization : AuthorizeAttribute
    {
        //a READ-ONLY array of UserKind's to check all the allowed autorizations for the current page.
        private readonly UserKind[] allowedroles;
        public UserAuthorization()
        {
            int i = 0;
            allowedroles = new UserKind[Enum.GetNames(typeof(UserKind)).Length];
            foreach (UserKind v in Enum.GetValues(typeof(UserKind)).Cast<UserKind>().ToList())
            {
                allowedroles[i++] = v;
            }
        }
        //splitting the array of UserKind's to an interatable
        public UserAuthorization(params UserKind[] roles)
        {
            allowedroles = roles;
        }
        //Comparing each UserKind that the page \ method is allowed to respond.
        //if the current client's session (after a login) has an allowed UserKind, we allow the operation
        //by returning true, otherwise return false;
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //bool authorize = false;
            foreach (var role in allowedroles)
            {
                if (HttpContext.Current.Session.Count != 0
                    && HttpContext.Current.Session["UserKind"].ToString() == role.ToString())
                {
                    //return true if Entity has current user with a specific role
                    return true;
                }
            }
            return false;
        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new HttpUnauthorizedResult();
        }
    }
}
