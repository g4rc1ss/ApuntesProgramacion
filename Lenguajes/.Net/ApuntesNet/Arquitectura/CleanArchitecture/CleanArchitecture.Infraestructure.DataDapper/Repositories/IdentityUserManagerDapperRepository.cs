using System.Security.Claims;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using Dapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infraestructure.DataDapper.Repositories
{
    internal class IdentityUserManagerDapperRepository : IIdentityUser
    {
        private readonly IDbConnectionFactory<EjemploDapperDatabase> _dbConnectionFactory;
        private readonly IHttpContextAccessor _httpContext;

        public IdentityUserManagerDapperRepository(IDbConnectionFactory<EjemploDapperDatabase> dbConnectionFactory, IHttpContextAccessor httpContext)
        {
            _dbConnectionFactory = dbConnectionFactory;
            _httpContext = httpContext;
        }

        public async Task<UserIdentityResponse> CreateUserAsync(UserModelEntity user, string password)
        {
            var dbConnection = _dbConnectionFactory.CreateDbConnection();
            user.PasswordHash = new PasswordHasher<UserModelEntity>().HashPassword(user, password);
            var sqlUserInsert = @$"
INSERT INTO [Users] (
    [AccessFailedCount]
    , [ConcurrencyStamp]
    , [Email]
    , [EmailConfirmed]
    , [LockoutEnabled]
    , [LockoutEnd]
    , [NormalizedEmail]
    , [NormalizedUserName]
    , [PasswordHash]
    , [PhoneNumber]
    , [PhoneNumberConfirmed]
    , [SecurityStamp]
    , [TwoFactorEnabled]
    , [UserName])
VALUES (
    @{nameof(user.AccessFailedCount)}
    , @{nameof(user.ConcurrencyStamp)}
    , @{nameof(user.Email)}
    , @{nameof(user.EmailConfirmed)}
    , @{nameof(user.LockoutEnabled)}
    , @{nameof(user.LockoutEnd)}
    , @{nameof(user.NormalizedEmail)}
    , @{nameof(user.NormalizedUserName)}
    , @{nameof(user.PasswordHash)}
    , @{nameof(user.PhoneNumber)}
    , @{nameof(user.PhoneNumberConfirmed)}
    , @{nameof(user.SecurityStamp)}
    , @{nameof(user.TwoFactorEnabled)}
    , @{nameof(user.UserName)});

SELECT [Id]
FROM [Users]
WHERE @@ROWCOUNT = 1 AND [Id] = scope_identity();
";
            var resultInsertUser = await dbConnection.QuerySingleOrDefaultAsync<UserModelEntity>(sqlUserInsert, user);
            user.Id = resultInsertUser.Id;
            return new UserIdentityResponse
            {
                Succeed = resultInsertUser.Id > 0,
            };
        }

        public async Task<UserIdentityResponse> CreateUserRoleAsync(UserModelEntity user, string role)
        {
            var dbConnection = _dbConnectionFactory.CreateDbConnection();
            var sqlRoleId = $@"
SELECT Id
from Roles r 
WHERE r.Name = @role
";
            var resultRoleId = await dbConnection.QuerySingleOrDefaultAsync<RoleModelEntity>(sqlRoleId, new { role });

            var sqlInsertUserRole = $@"
INSERT INTO [UserRoles] (
    [RoleId]
    , [UserId])
VALUES (
    @{nameof(role)}
    , @{nameof(user.Id)});
SELECT @@ROWCOUNT;
";
            var insertRole = await dbConnection.ExecuteAsync(sqlInsertUserRole, new
            {
                role = resultRoleId.Id,
                Id = user.Id
            });

            return new UserIdentityResponse
            {
                Succeed = insertRole > 0,
            };
        }

        public async Task<UserIdentityResponse> DeleteUserAsync(UserModelEntity user)
        {
            var dbConnection = _dbConnectionFactory.CreateDbConnection();

            var sqlUser = $@"
SELECT *
FROM [UserRoles]
WHERE [UserId] = @Id
";
            var userRole = await dbConnection.QuerySingleOrDefaultAsync<UserRoleModelEntity>(sqlUser, user);

            var sqlDeleteUserRoles = $@"
DELETE FROM [UserRoles]
WHERE [RoleId] = @{nameof(UserRoleModelEntity.RoleId)} AND [UserId] = @{nameof(UserRoleModelEntity.UserId)};
SELECT @@ROWCOUNT;
";
            await dbConnection.ExecuteAsync(sqlDeleteUserRoles, userRole);

            var sqlInsertUserRole = $@"
SET NOCOUNT ON;
DELETE FROM [Users]
WHERE [Id] = @{nameof(UserRoleModelEntity.UserId)};
SELECT @@ROWCOUNT;
";
            var deleteUser = await dbConnection.ExecuteAsync(sqlInsertUserRole, userRole);

            return new UserIdentityResponse
            {
                Succeed = deleteUser > 0,
            };
        }

        public async Task<UserIdentityResponse> LogInAsync(string user, string password, bool rememberMe)
        {
            var dbConnection = _dbConnectionFactory.CreateDbConnection();

            var sqlUser = $@"
SELECT *
FROM [Users] u
WHERE u.UserName = @userName

SELECT r.Id 
, r.Name 
FROM Roles r
	INNER JOIN UserRoles ur ON r.Id = ur.RoleId
	AND ur.UserId = (SELECT Id 
					FROM Users u 
					WHERE u.UserName = @userName)
";
            var obtainUserResult = await dbConnection.QueryMultipleAsync(sqlUser, new
            {
                userName = user,
            });
            var userResult = obtainUserResult.Read<UserModelEntity>().Single();
            var roleResult = obtainUserResult.Read<RoleModelEntity>().Single();

            var verifiedPassword = new PasswordHasher<UserModelEntity>().VerifyHashedPassword(userResult, userResult.PasswordHash, password);

            if (verifiedPassword != PasswordVerificationResult.Success)
            {
                return new UserIdentityResponse(false);
            }

            var identity = new ClaimsIdentity("Cookies");
            identity.AddClaim(new Claim(ClaimTypes.Role, roleResult.Name));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, userResult.Id.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Name, $"{userResult.UserName}"));

            var prop = new AuthenticationProperties { IsPersistent = false };
            await _httpContext.HttpContext.SignInAsync("Cookies", new ClaimsPrincipal(identity), prop);

            return new UserIdentityResponse(true);
        }

        public async Task<UserIdentityResponse> LogoutAsync()
        {
            await _httpContext.HttpContext.SignOutAsync();
            return new UserIdentityResponse(true);
        }
    }
}
