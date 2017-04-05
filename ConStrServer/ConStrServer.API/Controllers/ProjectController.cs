using ConStrServer.Business.Managers;
using ConStrServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ConStrServer.API.Controllers
{
    [Route("api/Projects")]
    public class ProjectController : Controller
    {
        private readonly IProjectManager _projectManagers;

        private ProjectController(IProjectManager projectManager)
        {
            _projectManagers = projectManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public IActionResult GetAllProjects()
        {
            return Ok(_projectManagers.GetAllProjects());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IActionResult CreateProject([FromBody]Project project)
        {
            return Ok(_projectManagers.CreateProject(project));
        }

        // POST api/values/5
        [HttpPost]
        public IActionResult EditProject([FromBody]Project project)
        {
            return Ok(_projectManagers.EditProject(project));
        }

        // Delete api/values/5
        [HttpPost("{id}")]
        public IActionResult DeleteProject(int id)
        {
            return Ok(_projectManagers.DeleteProject(id));
        }
    }
}