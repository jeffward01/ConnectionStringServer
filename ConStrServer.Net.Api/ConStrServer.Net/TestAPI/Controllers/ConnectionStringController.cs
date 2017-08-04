using ConStrServer.Business.Managers;
using ConStrServer.Business.ObjUtils;
using ConStrServer.Models.Dto;
using System.Web.Http;
using System.Web.Http.Cors;

namespace TestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/ConnectionString")]
    public class ConnectionStringController : ApiController
    {
        private readonly IProjectManager _projectManager;

        public ConnectionStringController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpGet]
        [Route(Name = "GetConnectionString")]
        public IHttpActionResult GetConnectionString(MainRequestObjectModel mainRequestObjectModel)
        {
            return Ok(_projectManager.GetConnectionString(MainObjectUtil.CastToDbo(mainRequestObjectModel)));
        }
    }
}