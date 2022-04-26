using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager;

internal class UserDam : IUserDam
{
    private readonly IDbContextFactory<EjemploContext> _contextFactory;
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public UserDam(SignInManager<User> signInManager,
        UserManager<User> userManager,
        IDbContextFactory<EjemploContext> contextFactory)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _contextFactory = contextFactory;
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

    public async Task<UserIdentityResponse> CreateUserAsync(User user, string password)
    {
        var respuesta = await _userManager.CreateAsync(user, password);
        return new UserIdentityResponse
        {
            Succeed = respuesta.Succeeded,
            User = user,
        };
    }

    public async Task<UserIdentityResponse> CreateUserRoleAsync(User user, string role)
    {
        var respuesta = await _userManager.AddToRoleAsync(user, role);
        return new UserIdentityResponse
        {
            Succeed = respuesta.Succeeded
        };
    }

    public async Task<UserIdentityResponse> DeleteUserAsync(User user)
    {
        var respuesta = await _userManager.DeleteAsync(user);
        return new UserIdentityResponse
        {
            Succeed = respuesta.Succeeded
        };
    }

    public async Task<List<User>> GetListUsers()
    {
        using var context = _contextFactory.CreateDbContext();
        await Task.Delay(1000);
        return await (from user in context.User
                      select user).ToListAsync();
    }
}
