using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ConStrServer.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
  //  [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
    }
}