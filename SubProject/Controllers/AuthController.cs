using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SubProject.DataServices;
using SubProject.Models;
using SubProject.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserDS _dataService;

        public AuthController(IUserDS dataService)
        {
            _dataService = dataService;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(_dataService.GetUser(user.UserName) != null)
            {
                return BadRequest();

            }

            int pwdSize = 256;
            var salt = "salt12345"; //PasswordService.GenerateSalt(pwdSize);
            var pwd = PasswordService.HashPassword(user.Password, salt, pwdSize);

            _dataService.CreateUser(user.UserName, user.Name, user.Email, user.Password);

            return CreatedAtRoute(null, new { user.UserName });
        }

        [HttpPost("login")]
        public IActionResult Login(LoginDto dto)
        {
            var user = _dataService.GetUser(dto.UserName);

            if(user == null)
            {
                return BadRequest();
            }

            int pwdsize = 256;
            var salt = "salt12345";
            string secret = "secretmoviesworldcode";

            var password = PasswordService.HashPassword(user.Password, salt, pwdsize);

            if(password != user.Password)
            {
                return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(secret);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("userName", user.UserName) }),
                Expires = DateTime.Now.AddSeconds(45),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { user.UserName, token });
;        }
    }
}
