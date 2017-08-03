using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ConStrServer.Business.Managers;
using ConStrServer.Models.Dto;

namespace ConStrServer.Net.API.Controllers
{
    public class ConnectionStringController : ApiController
    {
        private readonly IConnectionStringManger _ConnectionStringManager;

        public ConnectionStringController(IConnectionStringManger ConnectionStringManager)
        {
            _ConnectionStringManager = ConnectionStringManager;
        }

        [HttpPost]
        [Route("CreateConnectionString")]
        public IHttpActionResult CreateConnectionString(ConnectionStringModel ConnectionStringModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_ConnectionStringManager.CreateConnectionString(ConnectionStringModel));
        }

        [HttpPost]
        [Route("EditConnectionString")]
        public IHttpActionResult EditConnectionString(ConnectionStringModel ConnectionStringModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_ConnectionStringManager.EditConnectionString(ConnectionStringModel));
        }

        [HttpPost]
        [Route("DeleteConnectionString/{ConnectionStringId}")]
        public IHttpActionResult DeleteConnectionString(int ConnectionStringId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_ConnectionStringManager.DeleteConnectionString(ConnectionStringId));
        }

        [HttpGet]
        [Route("GetAllConnectionStrings")]
        public IHttpActionResult GetAllConnectionStrings()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_ConnectionStringManager.GetAllConnectionStrings());
        }

        [HttpGet]
        [Route("GetConnectionStringById/{ConnectionStringId}")]
        public IHttpActionResult GetConnectionStringById(int ConnectionStringId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_ConnectionStringManager.GetConnectionStringById(ConnectionStringId));
        }
    }
}