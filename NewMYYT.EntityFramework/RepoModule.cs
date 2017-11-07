using Autofac;
using NewMYYT.Core.Model;
using NewMYYT.Core.Repository;

namespace NewMYYT.EntityFramework
{
    public class RepoModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<Repo<DelEntity>>().As<IRepo<DelEntity>>();
            //builder.RegisterType<UniRepo>().As<IUniRepo>();
            //builder.RegisterType<DelRepo<DelEntity>>().As<IDelRepo<DelEntity>>();

            builder.RegisterAssemblyTypes(this.ThisAssembly)
                .Where(t => t.Name.EndsWith("Repo"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
}
