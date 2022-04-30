using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.UsersDto;
using CleanArchitecture.Domain.Utilities.LoggingMediatr;
using MediatR;
using Microsoft.AspNetCore.DataProtection;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager;

internal class UserNegocio : IUserNegocio
{
    private readonly IUserRepository _userRepository;
    private readonly IIdentityUser _identityUserRepository;
    private readonly IDataProtector _protector;
    private readonly IMediator _mediator;

    public UserNegocio(IUserRepository userRepository, IMediator mediator,
        IDataProtectionProvider dataProtectionProvider, IIdentityUser identityUserRepository)
    {
        _userRepository = userRepository;
        _mediator = mediator;
        _protector = dataProtectionProvider.CreateProtector("Identity.Users");
        _identityUserRepository = identityUserRepository;
    }

    public async Task<bool> LoginAsync(string username, string password, bool rememberMe)
    {
        var resp = await _identityUserRepository.LogInAsync(username, password, rememberMe);
        if (!resp.Succeed)
        {
            await _mediator.Publish(new LoggingRequest($"Nombre de usuario {username} o contraseña incorrecta ***", LogType.Info));
        }
        return resp.Succeed;
    }

    public async Task<bool> LogoutAsync()
    {
        var resp = await _identityUserRepository.LogoutAsync();
        if (!resp.Succeed)
        {
            await _mediator.Publish(new LoggingRequest("Error al Cerrar la sesion", LogType.Info));
            return false;
        }
        return true;
    }

    public async Task<bool> CreateUserAccountAsync(CreateAccountData createAccountData)
    {
        var user = new UserModelEntity()
        {
            UserName = createAccountData?.UserName,
            NormalizedUserName = createAccountData?.NormalizedUserName,
            Email = _protector.Protect(createAccountData?.Email),
            PhoneNumber = _protector.Protect(createAccountData?.PhoneNumber),
            SecurityStamp = new Guid().ToString()
        };
        var respUser = await _identityUserRepository.CreateUserAsync(user, createAccountData?.Password);
        var respRole = await _identityUserRepository.CreateUserRoleAsync(user, "Usuario");

        if (!(respUser.Succeed && respRole.Succeed))
        {
            // Delete user if error
            await _identityUserRepository.DeleteUserAsync(user);
            await _mediator.Publish(new LoggingRequest($"usuario creado? {respUser.Succeed} \n , logger" +
                $"usuario insertado Rol? {respRole.Succeed}", LogType.Info));
            return false;
        }
        return await LoginAsync(createAccountData?.UserName, createAccountData?.Password, false);
    }

    public async Task<List<UserModelEntity>> GetListaUsuarios()
    {
        var users = await _userRepository.GetListUsers();
        await _mediator.Publish(new LoggingRequest(users, LogType.Warning));

        return users.Select(user =>
        {
            user.Email = _protector.Unprotect(user.Email);
            user.PhoneNumber = _protector.Unprotect(user.PhoneNumber);
            return user;
        }).ToList();
    }
}
