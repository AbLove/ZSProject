using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using NewProject.EntityFramework;
using NewProject.Service;
using System.Web.Http;
using Unity;

namespace NewProject.NetWEBAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            var container = new UnityContainer();
            //container.RegisterType<IUserService, UserService>();
            container.RegisterType<IRepo<DelEntity>, Repo<DelEntity>>();
            container.RegisterType<ITestService<Users>, TestService<Users>>();
            container.RegisterType<ITestService<base_school>, TestService<base_school>>();
            config.DependencyResolver = new Utils.UnityResolver(container);
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
