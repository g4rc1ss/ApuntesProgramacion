using System;
using System.Threading.Tasks;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam
{
    internal class UpdateData
    {
        internal static async Task UpdateDataQueryAsync()
        {
            using var connection = DapperExecute.GetConnection();

            var updatePueblo = @$"
UPDATE {nameof(Pueblo)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idPueblo;

UPDATE {nameof(Usuario)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idUsuario";
            var nChanges = await connection.ExecuteAsync(updatePueblo, new
            {
                idPueblo = "IdPueblo1",
                idUsuario = "IdUsuario1",
            });

            Console.WriteLine($"Actualizado {nChanges} registros");
        }
    }
}
