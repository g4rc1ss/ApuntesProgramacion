﻿using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Negocio.UsersManager;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;

namespace CleanArchitecture.ApplicationCore.NegocioEjemplo.Negocio.UsersManager {
    public class UserDetailNegocio : IUserDetailNegocio {
        private readonly IUserDetailDam _userDetailDam;

        public UserDetailNegocio(IUserDetailDam userDetailDam) {
            _userDetailDam = userDetailDam;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro) {
            return await _userDetailDam.GetUser(filtro);
        }
    }
}
