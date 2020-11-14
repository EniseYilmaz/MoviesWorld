using Microsoft.AspNetCore.Mvc;
using SubProject.Attributes;
using DataServiceLib.DataServices;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib.Models;
using SubProject.Dto;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/users")]
    [Authorization]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserDS ds;

        public UserController(IUserDS dataservice, IMapper mapper)
        {
            ds = dataservice;
            _mapper = mapper;
        }

        [Authorization]
        [HttpDelete("{userName}")]
        public IActionResult delete(string userName)
        {
            var data = ds.Delete(userName);
            return Ok(data.ToJson());
        }

        [HttpGet]
        public IActionResult GetUsers(int page = 0, int pagesize = 10)
        {
            var users = (IList<User>)ds.GetUsers(page, pagesize);
            var dto = _mapper.Map<IList<UserDto>>(users);
            return Ok(dto.ToJson());
        }

        [HttpGet("{userName}")]
        public IActionResult GetUser(string userName)
        {
            var user = (User)ds.GetUser(userName);
            var dto = _mapper.Map<UserDto>(user);
            return Ok(dto.ToJson());
        }
    }
}
