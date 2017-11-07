using System.Web;

namespace NewProject.NetWEBAPI.Utils
{
    public static class WebUtils
    {
        public static bool IsUserAdmin()
        {
            return HttpContext.Current.User.IsInRole("admin");
        }
    }
}