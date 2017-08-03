using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConStrServer.Models.Dbo;

namespace ConStrServer.Net.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ContainerConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            //GlobalConfiguration.Configure(c => c.MapHttpAttributeRoutes());
        }
    }
}