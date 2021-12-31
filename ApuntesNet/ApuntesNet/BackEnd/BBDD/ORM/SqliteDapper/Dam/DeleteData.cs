using System;
using System.Threading.Tasks;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam
{
    internal static class DeleteData
    {
        internal static async Task DeleteDataQueryAsync()
        {
            using var connection = DapperExecute.GetConnection();
            
            var deleteUsuario = @$"DELETE FROM {nameof(Usuario)} WHERE Id = @idUsuario";
            var nChangesUsuario = await connection.ExecuteAsync(deleteUsuario.ToString(), new
            {
                idUsuario = "IdUsuario2"
            });

            Console.WriteLine($"Borrado {nChangesUsuario} registros");
        }
    }
}
