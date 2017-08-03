using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ConStrServer.Business.Managers;
using ConStrServer.Models.Dto;

namespace TestAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectManager _projectManager;

        public ProjectController(IProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpGet]
        public IHttpActionResult default3432()
        {
            return Ok("2423432");

        }

        [HttpGet]
        [Route("Test")]
        public IHttpActionResult Test()
        {
            return Ok("YEs");

        }

        [HttpPost]
        [Route("CreateProject")]
        public IHttpActionResult CreateProject(ProjectModel projectModel)
        {
           // if (!ModelState.IsValid)
           // {
           //     var errorList = ModelState.ToDictionary(kvp => kvp.Key.Replace("model.", ""), kvp => kvp.Value.Errors[0].ErrorMessage);
           //
           //     return BadRequest(errorList.ToString());
           // }

            return Ok(_projectManager.CreateProject(projectModel));
        }

        [HttpPost]
        [Route("EditProject")]
        public IHttpActionResult EditProject(ProjectModel projectModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_projectManager.EditProject(projectModel));
        }

        [HttpPost]
        [Route("DeleteProject/{projectId}")]
        public IHttpActionResult DeleteProject(int projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_projectManager.DeleteProject(projectId));
        }

        [HttpGet]
        [Route("GetAllProjects")]
        public IHttpActionResult GetAllProjects()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_projectManager.GetAllProjects());
        }

        [HttpGet]
        [Route("GetProjectById/{projectId}")]
        public IHttpActionResult GetProjectById(int projectId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_projectManager.GetProjectById(projectId));
        }
    }
}