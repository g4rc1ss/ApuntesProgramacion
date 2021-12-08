using System;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam {
    internal static class DeleteData {
        internal static void DeleteDataQuery() {
            using (var connection = DapperExecute.GetConnection()) {
                var deleteUsuario = @$"DELETE FROM {nameof(Usuario)} WHERE Id = 'IdUsuario2'";
                var nChangesUsuario = connection.Execute(deleteUsuario.ToString());

                Console.WriteLine($"Borrado {nChangesUsuario} registros");
            }
        }
    }
}
