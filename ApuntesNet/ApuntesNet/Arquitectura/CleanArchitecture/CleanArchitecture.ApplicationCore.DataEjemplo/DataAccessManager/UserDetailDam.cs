using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.ApplicationCore.Shared.Peticiones.Responses.User.Usuarios;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Infraestructure.DatabaseConfig.DbConnectionExtension;
using Dapper;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.ApplicationCore.DataEjemplo.DataAccessManager {
    public class UserDetailDam : IUserDetailDam {
        private readonly IDbConnectionFactory _factoryEjemplo;

        public UserDetailDam(IDbConnectionFactory factoryEjemplo) {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro) {
            using var connection = _factoryEjemplo.CreateDbConnection();

            return (await connection.QueryAsync<UserResponse>(@$"
SELECT Id as {nameof(UserResponse.Id)}
    , NormalizedUserName as {nameof(UserResponse.Nombre)}
    , UserName as {nameof(UserResponse.Nombre)}
    , Email as {nameof(UserResponse.Email)}
    , TwoFactorEnabled as {nameof(UserResponse.TieneDobleFactor)}
FROM Users
WHERE Id = @{nameof(filtro.IdUsuario)}
", filtro)).FirstOrDefault();
        }
    }
}
