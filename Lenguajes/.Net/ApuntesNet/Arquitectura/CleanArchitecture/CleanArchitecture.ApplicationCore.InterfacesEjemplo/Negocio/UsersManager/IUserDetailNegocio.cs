﻿using System.Threading.Tasks;
using CleanArchitecture.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager
{
    public interface IUserDetailNegocio
    {
        Task<UserResponse> GetUser(FiltroUser filtro);
    }
}