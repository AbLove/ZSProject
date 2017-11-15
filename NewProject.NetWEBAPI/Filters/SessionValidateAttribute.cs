using NewProject.Common;
using NewProject.Data.IService;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Security;

namespace NewProject.NetWEBAPI.Filters
{
    public class SessionValidateAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public const string SessionKeyName = "SessionKey";
        public const string LogonUserName = "LogonUser";


        public override void OnActionExecuting(HttpActionContext filterContext)
        {

            var qs = HttpUtility.ParseQueryString(filterContext.Request.RequestUri.Query);
            var prams = filterContext.ControllerContext;
            //string sessionKey = qs[SessionKeyName];
            string sessionKey = "5c8e2e9725cd7b7080d2d641031f75bd";
            if (string.IsNullOrEmpty(sessionKey))
            {
                filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.BadRequest, new HttpError("无效 Session"));
            }
            else
            {
                IAuthenticationService _authenticationService = IoC.Resolve<IAuthenticationService>();

                //验证用户sessionKey
                var userSession = _authenticationService.GetUserDevice(sessionKey:sessionKey);

                if (userSession == null)
                {
                    filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.NotFound, new HttpError("无此 sessionKey"));
                }
                else
                {
                    //todo: 加Session是否过期的判断
                    if (userSession.ExpiredTime < DateTime.Now)
                    {
                        filterContext.Response = filterContext.Request.CreateResponse(HttpStatusCode.RequestTimeout, new HttpError("sessionKey已过期"));
                    }
                    else
                    {
                        var logonUser = _authenticationService.GetUser(userSession.UserId);
                        if (logonUser != null)
                        {
                            prams.RouteData.Values[LogonUserName] = logonUser;
                            SetPrincipal(new UserPrincipal<int>(new User<int> { UserId = logonUser.Id, LoginName = logonUser.Name, DisplayName = logonUser.NickName }));
                        }
                        userSession.ActiveTime = DateTime.Now;
                        userSession.ExpiredTime = DateTime.Now.AddMinutes(60);
                        _authenticationService.UpdateUserDevice(userSession);
                    }
                }
            }
        }
        /// <summary>
        /// 通过HttpContext.User 或者 System.Threading.Thread.CurrentPrincipal可以拿到当前线程上下文的用户信息,
        /// 方便各处使用
        /// </summary>
        /// <param name="principal"></param>
        public static void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }


    }
    /// <summary>
    /// 客服端需要的用户数据对象
    /// </summary>
    public class UserIdentity<TKey> : IIdentity
    {
        public UserIdentity(User<TKey> user)
        {
            if (user != null)
            {
                IsAuthenticated = true;
                UserId = user.UserId;
                Name = user.LoginName;
                DisplayName = user.DisplayName;
                AuthenticationType = user.Roles;
            }
        }

        public string AuthenticationType
        {
            get; private set;
        }

        public TKey UserId { get; private set; }

        public bool IsAuthenticated { get; private set; }

        public string Name { get; private set; }

        public string DisplayName { get; private set; }
    }

    public class UserPrincipal<TKey> : IPrincipal
    {
        public UserPrincipal(UserIdentity<TKey> identity)
        {
            Identity = identity;
        }

        public UserPrincipal(User<TKey> user)
            : this(new UserIdentity<TKey>(user))
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public UserIdentity<TKey> Identity { get; private set; }

        IIdentity IPrincipal.Identity
        {
            get { return Identity; }
        }


        bool IPrincipal.IsInRole(string role)
        {
            throw new NotImplementedException();
        }
    }

    public class User<T>
    {
        public T UserId { get; set; }
        public string LoginName { get; set; }
        public string DisplayName { get; set; }

        public string Roles { get; set; }
    }


    public class CustomPrincipal : IPrincipal
    {
        public IIdentity Identity { get; private set; }
        public bool IsInRole(string role)
        {
            return Roles.IsUserInRole(Identity.Name, role);
        }
        public CustomPrincipal(IIdentity identity)
        {
            this.Identity = identity;
        }

        public string LoginName { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public bool? UseCustomScore { get; set; }

        public bool? UseCustomAsm { get; set; }

    }
}