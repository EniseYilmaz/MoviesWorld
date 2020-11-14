using Microsoft.AspNetCore.Mvc;
using SubProject.Attributes;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/user")]
    [Authorization]
    public class UserController : ControllerBase
    {
        IUserDS ds;

        public UserController(IUserDS dataservice)
        {
            ds = dataservice;
        }

        [Authorization]
        [HttpGet("{userName}")]
        public IActionResult delete(string userName)
        {
            var data = ds.Delete(userName);
            return Ok(data.ToJson());
        }

        [HttpGet]
        public IActionResult GetUsers(int page = 0, int pagesize = 10)
        {
            var users = ds.GetUsers(page, pagesize);

            return Ok(users.ToJson());
        }
    }
}
