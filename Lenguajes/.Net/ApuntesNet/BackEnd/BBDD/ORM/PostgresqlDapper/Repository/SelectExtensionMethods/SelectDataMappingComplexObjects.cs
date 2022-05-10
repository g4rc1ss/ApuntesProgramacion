using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository.SelectExtensionMethods
{
    internal static class SelectDataMappingComplexObjects
    {
        internal static async Task SelectDataMappingComplexObjectsAsync(this SelectData select)
        {
            var sqlUsuarioJoin = @$"
SELECT u.Id as {nameof(Usuario.IdUsuario)}
    ,u.Nombre as {nameof(Usuario.NombreUsuario)}
    ,village.Id as {nameof(Pueblo.IdPueblo)}
    ,village.Nombre as {nameof(Pueblo.NombrePueblo)}
FROM {nameof(Usuario)} u
INNER JOIN {nameof(Pueblo)} village ON u.IdPueblo = village.Id
WHERE u.id = @IdUsuario
";

            var parameters = new
            {
                IdUsuario = 1
            };

            var respuestaJoin = await select._dbConnection.QueryAsync<Usuario, Pueblo, Usuario>(sqlUsuarioJoin, (user, pueblo) =>
            {
                user.FKPueblo = pueblo;
                return user;
            }, parameters, splitOn: $"{nameof(Pueblo.IdPueblo)}");


            foreach (var user in respuestaJoin)
            {
                Console.WriteLine($"Usuario - {user.IdUsuario}_{user.NombreUsuario}");
                Console.WriteLine($"Pueblo - {user.FKPueblo.IdPueblo}_{user.FKPueblo.NombrePueblo}");
            }
        }
    }
}
