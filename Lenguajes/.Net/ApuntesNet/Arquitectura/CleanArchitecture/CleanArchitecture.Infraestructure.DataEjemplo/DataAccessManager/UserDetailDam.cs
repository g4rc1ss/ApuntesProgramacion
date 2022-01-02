using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Dominio.Negocio.Filtros.UserDetail;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Dapper;

namespace CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager
{
    internal class UserDetailDam : IUserDetailDam
    {
        private readonly IDbConnectionFactory<EjemploContext> _factoryEjemplo;

        public UserDetailDam(IDbConnectionFactory<EjemploContext> factoryEjemplo)
        {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<UserResponse> GetUser(FiltroUser filtro)
        {
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
