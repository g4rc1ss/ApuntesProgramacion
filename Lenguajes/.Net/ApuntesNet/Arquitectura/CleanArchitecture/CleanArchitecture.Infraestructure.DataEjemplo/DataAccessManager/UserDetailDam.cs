using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Infraestructure.DatabaseConfig;
using CleanArchitecture.Shared.Peticiones.Responses.User.Usuarios;
using Dapper;
using CleanArchitecture.Domain.Database.Identity;

namespace CleanArchitecture.Infraestructure.DataEjemplo.DataAccessManager
{
    internal class UserDetailDam : IUserDetailDam
    {
        private readonly IDbConnectionFactory<EjemploContext> _factoryEjemplo;

        public UserDetailDam(IDbConnectionFactory<EjemploContext> factoryEjemplo)
        {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<User> GetUser(FiltroUser filtro)
        {
            using var connection = _factoryEjemplo.CreateDbConnection();

            return (await connection.QueryAsync<User>(@$"
SELECT Id as {nameof(User.Id)}
    , NormalizedUserName as {nameof(User.NormalizedUserName)}
    , UserName as {nameof(User.UserName)}
    , Email as {nameof(User.Email)}
    , TwoFactorEnabled as {nameof(User.TwoFactorEnabled)}
FROM Users
WHERE Id = @{nameof(filtro.IdUsuario)}
", filtro)).FirstOrDefault();
        }
    }
}
