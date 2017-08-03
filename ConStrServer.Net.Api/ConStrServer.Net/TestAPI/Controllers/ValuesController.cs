using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConStrServer.Business.Managers;
using ConStrServer.Models.Dto;

namespace TestAPI.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {

        private readonly IProjectManager _projectManager;

        public ValuesController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        //  [HttpGet]
        //  public IHttpActionResult default3432()
        //  {
        //      return Ok("2423432");
        //
        //  }

        [Route("Test")]
        [HttpGet]
        public IHttpActionResult Test()
        {
            return Ok("YEs");

        }

        [HttpPost]
        [Route("CreateProject")]
        public IHttpActionResult CreateProject(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_projectManager.CreateProject(projectModel));
        }
    //    // GET api/values
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

     //   // GET api/values/5
     //   public string Get(int id)
     //   {
     //       return "value";
     //   }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
