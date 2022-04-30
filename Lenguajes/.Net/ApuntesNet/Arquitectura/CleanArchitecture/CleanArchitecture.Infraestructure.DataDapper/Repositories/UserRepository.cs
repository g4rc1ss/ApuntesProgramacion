using CleanArchitecture.ApplicationCore.InterfacesEjemplo;
using CleanArchitecture.ApplicationCore.InterfacesEjemplo.Data;
using CleanArchitecture.Domain.Database.ModelEntity;
using CleanArchitecture.Infraestructure.DataDapper.Contexts;
using Dapper;

namespace CleanArchitecture.Infraestructure.DataDapper.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory<EjemploDapperDatabase> _connectionFactory;

        public UserRepository(IDbConnectionFactory<EjemploDapperDatabase> connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public Task<IEnumerable<UserModelEntity>> GetListUsers()
        {
            var sql = @"
SELECT [u].[Id]
    , [u].[AccessFailedCount]
    , [u].[ConcurrencyStamp]
    , [u].[Email]
    , [u].[EmailConfirmed]
    , [u].[LockoutEnabled]
    , [u].[LockoutEnd]
    , [u].[NormalizedEmail]
    , [u].[NormalizedUserName]
    , [u].[PasswordHash]
    , [u].[PhoneNumber]
    , [u].[PhoneNumberConfirmed]
    , [u].[SecurityStamp]
    , [u].[TwoFactorEnabled]
    , [u].[UserName]
FROM [Users] AS [u]
";
            return _connectionFactory.CreateDbConnection()
                .QueryAsync<UserModelEntity>(sql);
        }
    }
}
