using System.Web;
using System.Web.Mvc;



//This Class is used to verify Authorization to pages for users, depanding on their "UserKind".
namespace Lorence_Project.Helpers
{
    public static class GetUserRoles
    {
        public static string GetUserRole(this HtmlHelper html)
        {
            if (HttpContext.Current.Session.Keys.Count == 0)
                return "";
            return HttpContext.Current.Session["UserKind"].ToString();
        }
    }
}
