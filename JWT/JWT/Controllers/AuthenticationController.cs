using JWT.Data;
using JWT.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public readonly AppDbContext _context;

        public AuthenticationController(IConfiguration configuration, AppDbContext context)
        {
            Configuration = configuration;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateToken(User user)
        {
            if(user != null && user.UserName != null && user.Password != null)
            {
                var userData = await GetUserInfo(user.UserName, user.Password);
                var jwt = Configuration.GetSection("Jwt").Get<Jwt>();
                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("UserName", user.UserName),
                    new Claim("Password", user.Password)
                };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    jwt.Issuer,
                    jwt.Audience,
                    claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signIn
                    );
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            else
            {
                return BadRequest("Eror");
            }
        }
        [HttpGet]
        public async Task<User> GetUserInfo(string username, string password)
        {

            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == username && x.Password == password);
        }
    }
}
