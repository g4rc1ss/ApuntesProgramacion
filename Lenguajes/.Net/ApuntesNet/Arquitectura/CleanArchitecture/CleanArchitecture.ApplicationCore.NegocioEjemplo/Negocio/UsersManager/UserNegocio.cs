﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Domain.Utilities.LoggingMediatr;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager;

internal class UserNegocio : IUserNegocio
{
    private readonly ILogger<UserNegocio> logger;
    private readonly IUserDam userDam;
    private readonly IMediator _mediator;

    public UserNegocio(ILogger<UserNegocio> logger, IUserDam userDam, IMediator mediator)
    {
        this.logger = logger;
        this.userDam = userDam;
        _mediator = mediator;
    }

    public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
    {
        var resp = await userDam.LogInAsync(username, password, rememberMe);
        if (!resp)
        {
            logger.LogInformation($"Nombre de usuario {username} o contraseña incorrecta ***", nameof(LoginAsync));
        }
        return resp;
    }

    public async Task<bool> LogoutAsync()
    {
        var resp = await userDam.LogoutAsync();
        if (!resp)
        {
            logger.LogInformation("Error al Cerrar la sesion", nameof(LogoutAsync));
            return false;
        }
        return true;
    }

    public async Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData)
    {
        var user = new UserData()
        {
            UserName = createAccountData?.UserName,
            NormalizedUserName = createAccountData?.NormalizedUserName,
            Email = createAccountData?.Email,
            PhoneNumber = createAccountData?.PhoneNumber,
            SecurityStamp = new Guid().ToString()
        };
        var respUser = await userDam.CreateUserAsync(user, createAccountData?.Password);
        var respRole = await userDam.CreateUserRoleAsync(user, "Usuario");

        if (!(respUser && respRole))
        {
            var deleteToRevertOperation = await userDam.DeleteUserAsync(user);
            logger.LogInformation($"usuario creado? {respUser} \n , logger" +
                $"usuario insertado Rol? {respRole}", nameof(CreateUserAccountAsync));
            return false;
        }
        return await LoginAsync(createAccountData?.UserName, createAccountData?.Password, false);
    }

    public async Task<List<User>> GetListaUsuarios()
    {
        var users = await userDam.GetListUsers();
        await _mediator.Publish(new LoggingRequest(users, LogType.Warning));
        return users;
    }
}
