using NewProject.Data.IService;
using NewProject.Data.Model;
using NewProject.Data.Repository;
using NewProject.EntityFramework;
using NewProject.Service;
using Omu.Encrypto;
using System.Web.Http;
using Unity;

namespace NewProject.NetWEBAPI
{
    public class UnityConfig
    {
        public static void Register(HttpConfiguration config) {
            var container = new UnityContainer();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IAuthenticationService, AuthenticationService>();

            container.RegisterType<IHasher, Hasher>();

            container.RegisterType<IRepo<Users>, Repo<Users>>();
            container.RegisterType<IRepo<UserDevice>, Repo<UserDevice>>();

            container.RegisterType<ICrudService<Users>, CrudService<Users>>();

            container.RegisterType<IDbContextFactory, DbContextFactory>();

            config.DependencyResolver = new Utils.UnityResolver(container);
        }
    }
}