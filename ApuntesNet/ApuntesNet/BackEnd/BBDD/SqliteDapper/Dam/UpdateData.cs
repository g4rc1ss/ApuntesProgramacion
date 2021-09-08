using System;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam {
    internal class UpdateData {
        internal static void UpdateDataQuery() {
            using (var connection = DapperExecute.GetConnection()) {
                var updatePueblo = @$"UPDATE {nameof(Pueblo)}
                                          SET Id = '{Guid.NewGuid()}'
                                          WHERE Id = 'IdPueblo1'";
                var nChangesPueblo = connection.Execute(updatePueblo);

                var updateUsuario = @$"UPDATE {nameof(Usuario)}
                                          SET Id = '{Guid.NewGuid()}'
                                          WHERE Id = 'IdUsuario1'";
                var nChangesUsuario = connection.Execute(updateUsuario.ToString());

                Console.WriteLine($"Actualizado {nChangesPueblo + nChangesUsuario} registros");
            }
        }
    }
}
