using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiJWT.Configuration;
using ApiJWT.Shared.DTO.Request;
using ApiJWT.Shared.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ApiJWT.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly JwtConfig _jwtConfig;

        public UserController(IOptions<JwtConfig> jwtConfig)
        {
            _jwtConfig = jwtConfig.Value;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequest loginRequest)
        {
            var comprobamosLaPasswordEnBaseDeDatos = true;

            if (comprobamosLaPasswordEnBaseDeDatos)
            {
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, loginRequest.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                //foreach (var userRole in userRoles)
                //{
                //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                //}

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SignInKey));

                var token = new JwtSecurityToken(
                    issuer: _jwtConfig.Issuer,
                    audience: _jwtConfig.Audience,
                    expires: DateTime.Now.AddSeconds(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );

                return Json(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    loginRequest.UserName,
                    expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var usuarios = new List<UserResponse>
            {
                new UserResponse
                {
                    Id = 0,
                    UserName = "usuario1"
                },
                new UserResponse
                {
                    Id = 1,
                    UserName = "usuario2",
                }
            };
            var obtenerJson = Json(usuarios);
            return await Task.FromResult(obtenerJson);
        }
    }
}
