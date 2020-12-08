using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using DataServiceLib.DataServices;
using DataServiceLib.Models;
using SubProject.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using SubProject.Attributes;

namespace SubProject.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserDS _dataService;
        private readonly IConfiguration _configuration;

        public AuthController(IUserDS dataService, IConfiguration configuration)
        {
            _dataService = dataService;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            if(_dataService.GetUser(user.UserName) != null)
            {
                return BadRequest();

            }
            
            int.TryParse(_configuration.GetSection("Auth:PasswordSize").Value, out int pwdSize);

            if(pwdSize == 0)
            {
                throw new ArgumentException("No password size");
            }

            var salt = PasswordService.GenerateSalt(pwdSize);
            var pwd = PasswordService.HashPassword(user.Password, salt, pwdSize);

            _dataService.CreateUser(user.UserName, user.Name, user.Email, pwd, salt);

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

            int.TryParse(_configuration.GetSection("Auth:PasswordSize").Value, out int pwdSize);

            if (pwdSize == 0)
            {
                throw new ArgumentException("No password size");
            }

            string secret = _configuration.GetSection("Auth:Secret").Value;
            if (string.IsNullOrEmpty(secret))
            {
                throw new ArgumentException("No secret");
            }

            var password = PasswordService.HashPassword(dto.Password, user.Salt, pwdSize);
            if (password != user.Password)
            {
               return BadRequest();
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.UTF8.GetBytes(secret);
            var tokenDescription = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.Now.AddSeconds(86400),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescription);
            var token = tokenHandler.WriteToken(securityToken);

            return Ok(new { user.UserName, token });
;        }

        [HttpGet("checkifauthenticated")]
        [Authorization]
        public IActionResult checkIfAuthenticated()
        {
            return Ok(true);

        }
    }
}
