using NewProject.NetWEBAPI.Filters;
using System.Threading;
using System.Web;
using System.Web.Http;

namespace NewProject.NetWEBAPI.Controllers.API
{
    [SessionValidate]
    [WebApiExceptionFilter]
    public class BaseApiController : ApiController
    {
        public static bool IsUserAdmin()
        {
            return HttpContext.Current.User.IsInRole("admin");
        }

        public UserIdentity<int> CurrentUser
        {
            //(User.Identity as UserPrincipal<int>).Identity
            get { return (Thread.CurrentPrincipal as UserPrincipal<int>).Identity; }
            private set { }
        }
    }
}
