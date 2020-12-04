using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Tracker.Services.Models;

namespace Tracker.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IConfiguration config;

        public AuthController(IConfiguration config)
        {
            this.config = config;
        }

        /// <summary>
        /// This API let you get access token.
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>
        [HttpPost("login")]
        public IActionResult CreateDocument([FromBody] LoginDto loginDto)
        {
            if(loginDto.Username == "user" && loginDto.Password == "password")
            {
                return Ok(GenerateJSONWebToken());
            }

            return BadRequest();

        }

        private string GenerateJSONWebToken()    
        {    
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));    
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);    
    
            var token = new JwtSecurityToken(config["Jwt:Issuer"],    
              config["Jwt:Issuer"],    
              null,    
              expires: DateTime.Now.AddMinutes(1),    
              signingCredentials: credentials);    
    
            return new JwtSecurityTokenHandler().WriteToken(token);    
        }    
    }
}
