using System;
using System.Threading.Tasks;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam
{
    internal class SelectData
    {
        internal static async Task SelectDataQueryAsync()
        {
            using var connection = DapperExecute.GetConnection();

            #region QueryFirst

            var sqlUsuario = @$"SELECT Id as {nameof(Usuario.IdUsuario)},
                                    Nombre as {nameof(Usuario.NombreUsuario)}
                                    FROM {nameof(Usuario)} WHERE Id = @IdUsuario";
            var respuestaUsuario = await connection.QueryFirstOrDefaultAsync<Usuario>(sqlUsuario, new
            {
                IdUsuario = "IdUsuario3"
            });
            #endregion

            #region Query normal

            var sqlPueblo = @$"SELECT Id as {nameof(Pueblo.IdPueblo)},
                                    Nombre as {nameof(Pueblo.NombrePueblo)}
                                    FROM {nameof(Pueblo)}";
            var respuestaPueblo = await connection.QueryAsync<Pueblo>(sqlPueblo);
            #endregion

            #region Query with Join

            var sqlUsuarioJoin = @$"
SELECT user.Id as {nameof(Usuario.IdUsuario)}
    ,user.Nombre as {nameof(Usuario.NombreUsuario)}
    ,village.Id as {nameof(Pueblo.IdPueblo)}
    ,village.Nombre as {nameof(Pueblo.NombrePueblo)}
FROM {nameof(Usuario)} as user
INNER JOIN {nameof(Pueblo)} as village ON user.IdPueblo = village.Id
WHERE user.Id = @idUsuario";
            var respuestaJoin = await connection.QueryAsync<Usuario, Pueblo, Usuario>(sqlPueblo, (user, pueblo) =>
            {
                user.FKPueblo = pueblo;
                return user;
            },
            new
            {
                idUsuario = "IdUsuario3"
            },
            splitOn: $"{nameof(Pueblo.IdPueblo)}");

            foreach (var user in respuestaJoin)
            {
                Console.WriteLine($"Usuario - {user.IdUsuario}_{user.NombreUsuario}");
                Console.WriteLine($"Pueblo - {user.FKPueblo.IdPueblo}_{user.FKPueblo.NombrePueblo}");
            }
            #endregion

            #region Query Multiple

            #endregion

        }
    }
}
