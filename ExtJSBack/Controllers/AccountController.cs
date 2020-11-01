using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ExtJSBack.DB;
using ExtJSBack.Model;
using System.Security.Claims;
using System.Collections.Generic;
using ExtJSBack.Auth;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace ExtJSBack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly DatabaseContext _databaseContext;

        public AccountController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok("Нужно залогинится");
        }

        [HttpPost("")]
        public IActionResult Token([FromForm] User form)
        {
            var identity = GetIdentity(form.Login, form.Password);
            if (identity == null)
            {
                return Unauthorized(new { errorText = "Invalid username or password." });
            }
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            // создали вернули токен
            return Ok(encodedJwt);
        }

        private ClaimsIdentity GetIdentity(string username, string password)
        {
            var user = _databaseContext.Users.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, username)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                
                return claimsIdentity;
            }

            return null;
        }
    }
}
