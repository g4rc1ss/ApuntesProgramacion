using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Dominio.EntidadesDatabase.Identity;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApplicationCore.DataEjemplo.DataAccessManager;

public class UserDam : IUserDam
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

    public async Task<SignInResult> LogInAsync(string user, string password, bool rememberMe)
    {
        return await _signInManager.PasswordSignInAsync(user, password, rememberMe, false);
    }

    public async Task<bool> LogoutAsync()
    {
        try
        {
            await _signInManager.SignOutAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public async Task<IdentityResult> CreateUserAsync(User user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<IdentityResult> CreateUserRoleAsync(User user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<IdentityResult> DeleteUserAsync(User user)
    {
        return await _userManager.DeleteAsync(user);
    }

    public async Task<List<UserResponse>> GetListUsers()
    {
        using var context = _contextFactory.CreateDbContext();
        return await (from user in context.User
                      select new UserResponse
                      {
                          Id = user.Id,
                          NombreUsuario = user.UserName,
                          Nombre = user.NormalizedUserName,
                          Email = user.Email,
                          TieneDobleFactor = user.TwoFactorEnabled
                      }).ToListAsync();
    }
}
