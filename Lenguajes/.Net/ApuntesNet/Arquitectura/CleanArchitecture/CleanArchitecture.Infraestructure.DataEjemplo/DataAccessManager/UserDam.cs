﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Domain.Database.Entities.Identity;
using CleanArchitecture.ApplicationCore.Domain.Negocio.UsersDto;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DataEjemplo.Mappers.UserMapper;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
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

    public async Task<bool> LogInAsync(string user, string password, bool rememberMe)
    {
        return (await _signInManager.PasswordSignInAsync(user, password, rememberMe, false)).Succeeded;
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

    public async Task<bool> CreateUserAsync(UserData userData, string password)
    {
        var user = UserDamMapper.GetUserFromUserData(userData);
        return (await _userManager.CreateAsync(user, password)).Succeeded;
    }

    public async Task<bool> CreateUserRoleAsync(UserData userData, string role)
    {
        var user = UserDamMapper.GetUserFromUserData(userData);
        return (await _userManager.AddToRoleAsync(user, role)).Succeeded;
    }

    public async Task<bool> DeleteUserAsync(UserData userData)
    {
        var user = UserDamMapper.GetUserFromUserData(userData);
        return (await _userManager.DeleteAsync(user)).Succeeded;
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
