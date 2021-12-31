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
            
            var updatePueblo = @$"UPDATE {nameof(Pueblo)}
                                          SET Id = '{Guid.NewGuid()}'
                                          WHERE Id = @idPueblo";
            var nChangesPueblo = await connection.ExecuteAsync(updatePueblo, new
            {
                idPueblo = "IdPueblo1",
            });

            var updateUsuario = @$"UPDATE {nameof(Usuario)}
                                          SET Id = '{Guid.NewGuid()}'
                                          WHERE Id = @idUsuario";
            var nChangesUsuario = await connection.ExecuteAsync(updateUsuario.ToString(), new
            {
                idUsuario = "IdUsuario1",
            });

            Console.WriteLine($"Actualizado {nChangesPueblo + nChangesUsuario} registros");
        }
    }
}
