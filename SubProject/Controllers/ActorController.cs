using Microsoft.AspNetCore.Mvc;
using DataServiceLib.DataServices;
using SubProject.Attributes;

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

        [HttpGet("{id}")]
        public IActionResult GetPersonal(string id)
        {
            var data = ds.GetPersonal(id);
            return Ok(data);
        }
    }
}
