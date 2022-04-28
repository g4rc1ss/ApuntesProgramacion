using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.Identity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using Dapper;

namespace CleanArchitecture.Infraestructure.DataDapper.Repositories
{
    internal class UserDetailDam : IUserDetailDam
    {
        private readonly IDbConnectionFactory<EjemploDapperDatabase> _factoryEjemplo;

        public UserDetailDam(IDbConnectionFactory<EjemploDapperDatabase> factoryEjemplo)
        {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<User> GetUser(FiltroUser filtro)
        {
            using var connection = _factoryEjemplo.CreateDbConnection();

            return await connection.QuerySingleOrDefaultAsync<User>(@$"
SELECT Id as {nameof(User.Id)}
    , NormalizedUserName as {nameof(User.NormalizedUserName)}
    , UserName as {nameof(User.UserName)}
    , Email as {nameof(User.Email)}
    , TwoFactorEnabled as {nameof(User.TwoFactorEnabled)}
    , PhoneNumber as {nameof(User.PhoneNumber)}
FROM Users
WHERE Id = @{nameof(filtro.IdUsuario)}
", filtro);
        }
    }
}
