using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Domain.Negocio.Filtros.UserDetail;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using Dapper;

namespace CleanArchitecture.Infraestructure.DataDapper.Repositories
{
    internal class UserDetailRepository : IUserDetailRepository
    {
        private readonly IDbConnectionFactory<EjemploDapperDatabase> _factoryEjemplo;

        public UserDetailRepository(IDbConnectionFactory<EjemploDapperDatabase> factoryEjemplo)
        {
            _factoryEjemplo = factoryEjemplo;
        }

        public async Task<UserModelEntity> GetUser(FiltroUser filtro)
        {
            using var connection = _factoryEjemplo.CreateDbConnection();

            return await connection.QuerySingleOrDefaultAsync<UserModelEntity>(@$"
SELECT Id as {nameof(UserModelEntity.Id)}
    , NormalizedUserName as {nameof(UserModelEntity.NormalizedUserName)}
    , UserName as {nameof(UserModelEntity.UserName)}
    , Email as {nameof(UserModelEntity.Email)}
    , TwoFactorEnabled as {nameof(UserModelEntity.TwoFactorEnabled)}
    , PhoneNumber as {nameof(UserModelEntity.PhoneNumber)}
FROM Users
WHERE Id = @{nameof(filtro.IdUsuario)}
", filtro);
        }
    }
}
