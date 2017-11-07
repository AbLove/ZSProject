using NewProject.Common;
using NewProject.Data.IService;
using NewProject.Service;
using Omu.Encrypto;

namespace NewProject.NetWEBAPI
{
    public class WindsorConfig
    {
        public static void Configure()
        {
            WindsorRegistrar.Register(typeof(IHasher), typeof(Hasher));
            WindsorRegistrar.Register(typeof(IUserService), typeof(UserService));

            WindsorRegistrar.RegisterAllFromAssemblies("NewProject.EntityFramework");
            WindsorRegistrar.RegisterAllFromAssemblies("NewProject.Service");
            WindsorRegistrar.RegisterAllFromAssemblies("NewProject.NetWEBAPI");
        }
    }
}