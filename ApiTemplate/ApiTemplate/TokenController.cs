using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiTemplate
{
    [Route("/token")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenController(IConfiguration config)
        {
            _config = config;
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecureKey"]));
        }

        [HttpPost]
        public IActionResult Create(string username, string password)
        {
            if (IsValidUsernameAndPassword(username, password))
            {
                return new ObjectResult(GenerateToken(username));
            }
            return BadRequest();
        }

        private bool IsValidUsernameAndPassword(string username, string password)
        {
            //TODO: Implement authentication method
            return !string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password);
        }

        private string GenerateToken(string username)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, "John"),
                new Claim(ClaimTypes.Role, "User"),
                new Claim(JwtRegisteredClaimNames.Email, "john@test.com")
            };
            
            var token = new JwtSecurityToken(
                issuer: "TestApi",
                audience: "TestApp",
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(_key, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
