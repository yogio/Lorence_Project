using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

//this Class Authenticates login's attempts.
namespace Lorence_Project.Models
{
    public class UserAuthentication : ActionFilterAttribute, IAuthenticationFilter
    {
        //creating local instances of the UserName and Password to check in the Users DB. 
        public string UserName { get; set; }
        public string Password { get; set; }
        //public UserKind userKind { get; set; }

        //Implementing the 2 abstract methods in the derived Classes

            //Checking if the Client tried to enter a null (nothing)
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["UserID"])))
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new ViewResult
                {
                    ViewName = "Error"
                };
            }
        }

 

    }
}