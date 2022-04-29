using System;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infraestructure.DataEntityFramework.Repositories
{
    internal class IdentityUserRepository : IIdentityUserRepository
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        public IdentityUserRepository(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UserIdentityResponse> LogInAsync(string user, string password, bool rememberMe)
        {
            var respuesta = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }

        public async Task<UserIdentityResponse> LogoutAsync()
        {
            var response = new UserIdentityResponse();
            try
            {
                await _signInManager.SignOutAsync();
                response.Succeed = true;
            }
            catch (Exception)
            {
                response.Succeed = false;
            }
            return response;
        }

        public async Task<UserIdentityResponse> CreateUserAsync(UserModelEntity user, string password)
        {
            var userIdentity = _mapper.Map<User>(user);
            var respuesta = await _userManager.CreateAsync(userIdentity, password);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded,
                User = user,
            };
        }

        public async Task<UserIdentityResponse> CreateUserRoleAsync(UserModelEntity user, string role)
        {
            var userIdentity = _mapper.Map<User>(user);
            var respuesta = await _userManager.AddToRoleAsync(userIdentity, role);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }

        public async Task<UserIdentityResponse> DeleteUserAsync(UserModelEntity user)
        {
            var userIdentity = _mapper.Map<User>(user);
            var respuesta = await _userManager.DeleteAsync(userIdentity);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }
    }
}
