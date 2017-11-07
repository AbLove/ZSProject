using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NewMYYT.Core.Model;
using NewMYYT.Core.Repository;
using NewMYYT.Core.Service;
using NewMYYT.EntityFramework;
using NewMYYT.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NewMYYT.CoreWebApi
{

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IContainer ApplicationContainer { get; private set; }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //添加ef的依赖  
            //var connection = "server=(localdb);uid=sa;pwd=123;database=prodinner";
            services.AddEntityFrameworkMySql().AddDbContext<Db>(options => options.UseFarmDatabase(Configuration));
            services.AddApplicationInsightsTelemetry(Configuration);
            services.AddCors();
            //添加过滤器和日志服务
            //services.AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
            //    .AddJsonOptions(options => options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss");
            services.AddMvc();

            services.AddTransient(typeof(ITestService), typeof(TestService));
            //services.AddTransient(typeof(ITestUserService<string>), typeof(TestUserService<string>));

            //// Add Autofac
            //var builder = new ContainerBuilder();
            ////builder.RegisterType<DelRepo<DelEntity>>().As<IDelRepo<DelEntity>>();
            ////builder.RegisterType<Repo<DelEntity>>().As<IRepo<DelEntity>>();
            ////builder.RegisterType<CrudService<DelEntity>>().As<ICrudService<DelEntity>>();
            //builder.RegisterModule<ServiceModule>();
            //builder.RegisterModule<RepoModule>();
            //builder.Populate(services);
            //this.ApplicationContainer = builder.Build();
            //return new AutofacServiceProvider(this.ApplicationContainer);

            //集中注册服务
            //foreach (var item in GetClassName("NewMYYT.Service"))
            //{
            //    foreach (var typeArray in item.Value)
            //    {
            //        services.AddTransient(typeArray, item.Key);
            //    }
            //}
            //foreach (var item in GetClassName("NewMYYT.EntityFramework"))
            //{
            //    foreach (var typeArray in item.Value)
            //    {
            //        services.AddScoped(typeArray, item.Key);
            //    }
            //}
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            //自定义路由
            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Users}/{action=Index}/{id?}");
            //});
        }
        /// <summary>  
        /// 获取程序集中的实现类对应的多个接口
        /// </summary>  
        /// <param name="assemblyName">程序集</param>
        public Dictionary<Type, Type[]> GetClassName(string assemblyName)
        {
            if (!String.IsNullOrEmpty(assemblyName))
            {
                Assembly assembly = Assembly.Load(assemblyName);
                List<Type> ts = assembly.GetTypes().ToList();

                var result = new Dictionary<Type, Type[]>();
                foreach (var item in ts.Where(s => !s.IsInterface))
                {
                    var interfaceType = item.GetInterfaces();
                    result.Add(item, interfaceType);
                }
                return result;
            }
            return new Dictionary<Type, Type[]>();
        }

    }
}
