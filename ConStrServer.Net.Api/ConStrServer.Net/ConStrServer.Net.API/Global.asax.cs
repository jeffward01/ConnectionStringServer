using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ConStrServer.Models.Dbo;
using ConStrServer.Net.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http.Cors;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Routing;
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