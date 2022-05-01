using System;
using System.Threading.Tasks;
using AutoMapper;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Infraestructure.DataEntityFramework.Entities;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Infraestructure.DataEntityFramework.Repositories.IdentityFramework
{
    public class IdentityFrameworkRepository : IIdentityUser
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;

        private User _userIdentity;

        public IdentityFrameworkRepository(SignInManager<User> signInManager, UserManager<User> userManager, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<LoginIdentityResponse> LogInAsync(string user, string password, bool rememberMe)
        {
            var respuesta = await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
            return new LoginIdentityResponse
            {
                ValidatePassword = respuesta.Succeeded
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
            _userIdentity = _mapper.Map<User>(user);
            var respuesta = await _userManager.CreateAsync(_userIdentity, password);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }

        public async Task<UserIdentityResponse> CreateUserRoleAsync(UserModelEntity user, string role)
        {
            if (_userIdentity is null)
            {
                _userIdentity = _mapper.Map<User>(user);
            }

            var respuesta = await _userManager.AddToRoleAsync(_userIdentity, role);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }

        public async Task<UserIdentityResponse> DeleteUserAsync(UserModelEntity user)
        {
            if (_userIdentity is null)
            {
                _userIdentity = _mapper.Map<User>(user);
            }

            var respuesta = await _userManager.DeleteAsync(_userIdentity);
            return new UserIdentityResponse
            {
                Succeed = respuesta.Succeeded
            };
        }
    }
}
