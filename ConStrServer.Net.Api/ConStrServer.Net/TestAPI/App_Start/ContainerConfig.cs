using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ConStrServer.Business.Managers;
using ConStrServer.Data.Repositories;

namespace TestAPI
{
    public class ContainerConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(ContainerConfig).Assembly).InstancePerLifetimeScope();
            //This registers 'A'
            builder.RegisterAssemblyModules(typeof(ContainerConfig).Assembly);

            var container = builder.Build();

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }

    //This is 'A'
    public class RegisterServices : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Add Interfaces here

            //____DbContext____
            //   builder.RegisterType<ConStrContext>().As<IConStrContext>().InstancePerLifetimeScope();

            //___Managers____

            builder.RegisterType<ProjectManager>().As<IProjectManager>();
            builder.RegisterType<EnvironmentManager>().As<IEnvironmentManager>();
            builder.RegisterType<ConnectionStringManger>().As<IConnectionStringManger>();
            builder.RegisterType<MachineManager>().As<IMachineManager>();



            //___Providers____
            // builder.RegisterType<HttpProvider>().As<IHttpProvider>();
            // builder.RegisterType<GithubProvider>().As<IGithubProvider>();



            //____Services____


            //____Repositories____
            builder.RegisterType<AuthRepository>().As<IAuthRepository>();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>();
            builder.RegisterType<ConnectionStringRepository>().As<IConnectionStringRepository>();
            builder.RegisterType<MachineRepository>().As<IMachineRepository>();
            builder.RegisterType<EnvironmentInfoRepository>().As<IEnvironmentInfoRepository>();




            //Lookup Tables

            base.Load(builder);
        }
    }
}