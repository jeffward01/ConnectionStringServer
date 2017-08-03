using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using ConStrServer.Business.Managers;
using ConStrServer.Models.Dto;

namespace ConStrServer.Net.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/Environment")]
    public class EnvironmentInfoController : ApiController
    {
        private readonly IEnvironmentManager _EnvironmentManager;

        public EnvironmentInfoController(IEnvironmentManager EnvironmentManager)
        {
            _EnvironmentManager = EnvironmentManager;
        }

        [HttpPost]
        [Route("CreateEnvironment")]
        public IHttpActionResult CreateEnvironment(EnvironmentInfoModel EnvironmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            EnvironmentModel.LoadBalenced = false;
            return Ok(_EnvironmentManager.CreateEnvironment(EnvironmentModel));
        }

        [HttpPost]
        [Route("EditEnvironment")]
        public IHttpActionResult EditEnvironment(EnvironmentInfoModel EnvironmentModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_EnvironmentManager.EditEnvironment(EnvironmentModel));
        }

        [HttpPost]
        [Route("DeleteEnvironment/{EnvironmentId}")]
        public IHttpActionResult DeleteEnvironment(int EnvironmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_EnvironmentManager.DeleteEnvironment(EnvironmentId));
        }

        [HttpGet]
        [Route("GetAllEnvironments")]
        public IHttpActionResult GetAllEnvironments()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_EnvironmentManager.GetAllEnvironments());
        }

        [HttpGet]
        [Route("GetEnvironmentById/{EnvironmentId}")]
        public IHttpActionResult GetEnvironmentById(int EnvironmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_EnvironmentManager.GetEnvironmentById(EnvironmentId));
        }
    }
}