﻿using System.Threading.Tasks;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data
{
    public interface IIdentityUser
    {
        Task<UserIdentityResponse> LogInAsync(string user, string password, bool rememberMe);
        Task<UserIdentityResponse> LogoutAsync();
        Task<UserIdentityResponse> CreateUserAsync(UserModelEntity user, string password);
        Task<UserIdentityResponse> CreateUserRoleAsync(UserModelEntity user, string role);
        Task<UserIdentityResponse> DeleteUserAsync(UserModelEntity user);
    }
}
