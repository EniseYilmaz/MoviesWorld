using Microsoft.AspNetCore.Mvc;
using SubProject.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace SubProject.Controllers
{
   
    [ApiController]
    [Route("api/usermanager")]
    public class UserManagerController : ControllerBase
    {
        IUserManagerDS ds;
        public UserManagerController(IUserManagerDS dataservice)
        {
            ds = dataservice;
        }

        [HttpGet("createuser")]
        public IActionResult CreateAUser(string username, string name, string email, string password)
        {
        
            var comfirmed = ds.CreateUser(username, name, email,password);
            return Ok(comfirmed);
        }

        [HttpGet("deleteuser")]
        public IActionResult DeleteAUser(string username, string email)
        {
            var comfirmed = ds.DeleteUser(username,email);
            return Ok(comfirmed);
        }
       
        [HttpGet("getallusers")]
        public IActionResult DisplayAllUsers(int page = 0, int pagesize = 10)
        {
            var Users = ds.GetAllUsers(page, pagesize);
            return Ok(Users.ToJson());
        }

        


    }
}
