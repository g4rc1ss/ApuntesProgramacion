using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using DesktopUI.Backend.Data.DataAccessManager.BaseDam;
using DesktopUI.Backend.Data.DataAccessManager.Interfaces;
using DesktopUI.Backend.Data.Database;
using Microsoft.EntityFrameworkCore;

namespace DesktopUI.Backend.Data.DataAccessManager
{
    public class UserDam : DataAccessLayer, IUserDam
    {
        public UserDam(IDbContextFactory<ContextoSqlServer> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<List<Usuario>> GetAllUsersAsync()
        {
            using (var context = contexto.CreateDbContext())
            {
                return await (from user in context.Usuarios
                              orderby user.Id
                              select user).ToListAsync();
            }
        }

        public async Task<List<Usuario>> GetAllUsersWithEdadAsync(int edad)
        {
            using (var context = contexto.CreateDbContext())
            {
                return await (from user in context.Usuarios
                              where user.Edad == edad
                              orderby user.Id
                              select user).ToListAsync();
            }
        }

        public async Task<List<Usuario>> GetAllUsersWithDapperAsync()
        {
            var sql = @"
SELECT [u].[Id], [u].[Edad], [u].[FechaHoy], [u].[Nombre]
FROM PruebasConceptoWebApuntesNet.dbo.Usuarios AS [u]
ORDER BY [u].[Id]";
            using (var connection = contexto.CreateDbContext().Database.GetDbConnection())
            {
                return (await connection.QueryAsync<Usuario>(sql)).AsList();
            }
        }

        public async Task<List<Usuario>> GetAllUsersWithEdadWithDapperAsync(int edad)
        {
            var sql = @$"
SELECT [u].[Id], [u].[Edad], [u].[FechaHoy], [u].[Nombre]
FROM [Usuarios] AS [u]
WHERE [u].[Edad] = {edad}
ORDER BY [u].[Id]";
            using (var connection = contexto.CreateDbContext().Database.GetDbConnection())
            {
                return (await connection.QueryAsync<Usuario>(sql)).AsList();
            }
        }
    }
}
