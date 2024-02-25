﻿using System.Data;


using Dapper;


using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository.SelectExtensionMethods;

internal static class SelectDataMultipleQuery
{
    internal static async Task SelectDataMultipleQueryAsync(this SelectData select)
    {
        var sqlMultipleUserPueblo = $@"
SELECT Id as {nameof(Usuario.IdUsuario)}
    ,Nombre as {nameof(Usuario.NombreUsuario)}
FROM Usuario
ORDER BY Id;

SELECT Id as {nameof(Pueblo.IdPueblo)}
    ,Nombre as {nameof(Pueblo.NombrePueblo)}
FROM Pueblo
ORDER BY Id;
";
        var queryMultiple = await select.dbConnection.QueryMultipleAsync(sqlMultipleUserPueblo);

        var users = await queryMultiple.ReadAsync<Usuario>();
        var villages = await queryMultiple.ReadAsync<Pueblo>();

        users.Select((x) =>
        {
            Console.WriteLine(x.IdUsuario);
            return x;
        }).ToList();

        villages.Select((x) =>
        {
            Console.WriteLine(x.IdPueblo);
            return x;
        }).ToList();
    }
}
