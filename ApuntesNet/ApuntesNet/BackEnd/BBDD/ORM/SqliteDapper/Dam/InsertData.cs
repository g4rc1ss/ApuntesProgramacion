using System;
using System.Text;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam
{
    internal class InsertData
    {
        internal static void InsertDataQuery()
        {
            using (var connection = DapperExecute.GetConnection())
            {
                var insertIntoPueblo = new StringBuilder();
                var guidPueblo = Guid.NewGuid();
                insertIntoPueblo.AppendLine($"insert into {nameof(Pueblo)} (id, nombre)");
                insertIntoPueblo.AppendLine($"values ('{guidPueblo}', 'Albacete')");
                var nChangesPueblo = connection.Execute(insertIntoPueblo.ToString());

                var insertIntoUsuario = new StringBuilder();
                insertIntoUsuario.AppendLine($"insert into {nameof(Usuario)} (id, nombre, idpueblo)");
                insertIntoUsuario.AppendLine($"VALUES ('{Guid.NewGuid()}', 'garciss', '{guidPueblo}')");
                var nChangesUsuario = connection.Execute(insertIntoUsuario.ToString());

                Console.WriteLine($"Agregado {nChangesPueblo + nChangesUsuario} registros");
            }
        }
    }
}
