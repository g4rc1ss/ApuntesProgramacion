using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Infraestructure.DataEntityFramework.Contexts;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.DataEntityFramework.Repositories
{
    public class UserEfRepository : IIdentityUser
    {
        private readonly EjemploContext _context;
        private readonly IMapper _mapper;

        public UserEfRepository(EjemploContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoginIdentityResponse> LogInAsync(string user, string password, bool rememberMe)
        {
            var userResult = await _context.User.Where(x => x.UserName == user).SingleAsync();
            var roleResult = await (from users in _context.User
                                    from role in _context.Roles
                                    from userRole in _context.UserRoles
                                    where users.UserName == user && role.Id == userRole.RoleId && users.Id == userRole.UserId
                                    select role).SingleAsync();

            var verifiedPassword = new PasswordHasher<User>().VerifyHashedPassword(userResult, userResult.PasswordHash, password);

            return new LoginIdentityResponse
            {
                ValidatePassword = verifiedPassword == PasswordVerificationResult.Success,
                UserModel = _mapper.Map<UserModelEntity>(userResult),
                RoleModel = _mapper.Map<RoleModelEntity>(roleResult),
            };
        }

        public async Task<UserIdentityResponse> CreateUserAsync(UserModelEntity userModel, string password)
        {
            var user = _mapper.Map<User>(userModel);
            user.PasswordHash = new PasswordHasher<User>().HashPassword(user, password);

            await _context.Users.AddAsync(user);

            var result = await _context.SaveChangesAsync();
            userModel.Id = user.Id;

            return new UserIdentityResponse
            {
                Succeed = result > 0
            };
        }

        public async Task<UserIdentityResponse> CreateUserRoleAsync(UserModelEntity userModel, string role)
        {
            var roleId = await _context.Roles.Where(x => x.Name == role).SingleAsync();
            var userRole = new UserRole
            {
                RoleId = roleId.Id,
                UserId = userModel.Id
            };
            _context.UserRoles.Add(userRole);

            var result = await _context.SaveChangesAsync();

            return new UserIdentityResponse
            {
                Succeed = result > 0
            };
        }

        public async Task<UserIdentityResponse> DeleteUserAsync(UserModelEntity userModel)
        {
            var user = await _context.User.Where(x => x.Id == userModel.Id).SingleAsync();
            _context.Remove(user);

            var result = await _context.SaveChangesAsync();
            return new UserIdentityResponse
            {
                Succeed = result > 0
            };
        }
    }
}
