using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace ConStrServer.Net.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            ContainerConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}