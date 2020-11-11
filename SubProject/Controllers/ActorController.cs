using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/actors")]
    public class ActorController : ControllerBase
    {
        IActorDS ds;

        public ActorController(IActorDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet("popular")]
        public IActionResult GetPopularActors()
        {
            var data = ds.GetPopularActors();
            return Ok(data);
        }
    }
}
