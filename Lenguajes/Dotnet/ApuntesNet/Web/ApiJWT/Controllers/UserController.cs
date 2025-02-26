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

namespace ApiJWT.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController(IOptions<JwtConfig> jwtConfig) : Controller
{
    private readonly JwtConfig _jwtConfig = jwtConfig.Value;

    [AllowAnonymous]
    [HttpPost("Login")]
    public IActionResult Login(LoginRequest loginRequest)
    {
        bool comprobamosLaPasswordEnBaseDeDatos = true;

        if (comprobamosLaPasswordEnBaseDeDatos)
        {
            List<Claim>? authClaims =
            [
                new(ClaimTypes.Name, loginRequest.UserName),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            ];

            //foreach (var userRole in userRoles)
            //{
            //    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            //}

            SymmetricSecurityKey? authSigningKey = new(Encoding.UTF8.GetBytes(_jwtConfig.SignInKey));

            JwtSecurityToken? token = new(
                issuer: _jwtConfig.Issuer,
                audience: _jwtConfig.Audience,
                expires: DateTime.Now.AddMinutes(10),
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
        List<UserResponse>? usuarios =
        [
            new() { Id = 0, UserName = "usuario1" },
            new() { Id = 1, UserName = "usuario2", }
        ];
        JsonResult? obtenerJson = Json(usuarios);
        return await Task.FromResult(obtenerJson);
    }
}