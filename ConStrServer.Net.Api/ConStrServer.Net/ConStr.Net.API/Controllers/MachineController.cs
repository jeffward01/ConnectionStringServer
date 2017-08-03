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
    [RoutePrefix("api/Machine")]
    public class MachineController : ApiController
    {
        private readonly IMachineManager _MachineManager;

        public MachineController(IMachineManager MachineManager)
        {
            _MachineManager = MachineManager;
        }

        [HttpPost]
        [Route("CreateMachine")]
        public IHttpActionResult CreateMachine(MachineModel MachineModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_MachineManager.CreateMachine(MachineModel));
        }

        [HttpPost]
        [Route("EditMachine")]
        public IHttpActionResult EditMachine(MachineModel MachineModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_MachineManager.EditMachine(MachineModel));
        }

        [HttpPost]
        [Route("DeleteMachine/{MachineId}")]
        public IHttpActionResult DeleteMachine(int MachineId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_MachineManager.DeleteMachine(MachineId));
        }

        [HttpGet]
        [Route("GetAllMachines")]
        public IHttpActionResult GetAllMachines()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_MachineManager.GetAllMachines());
        }

        [HttpGet]
        [Route("GetMachineById/{MachineId}")]
        public IHttpActionResult GetMachineById(int MachineId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(_MachineManager.GetMachineById(MachineId));
        }
    }
}