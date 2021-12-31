using System;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SqliteDapper.Database;
using SqliteDapper.Database.Sqlite;

namespace SqliteDapper.Dam
{
    internal class InsertData
    {
        internal static async Task InsertDataQueryAsync()
        {
            using var connection = DapperExecute.GetConnection();
            
            var insertIntoPueblo = new StringBuilder();
            var guidPueblo = Guid.NewGuid();
            insertIntoPueblo.AppendLine($"insert into {nameof(Pueblo)} (id, nombre)");
            insertIntoPueblo.AppendLine($"values (@guidPueblo, @NombrePueblo)");
            var nChangesPueblo = await connection.ExecuteAsync(insertIntoPueblo.ToString(), new
            {
                guidPueblo,
                NombrePueblo = "Albacete"
            });

            var insertIntoUsuario = new StringBuilder();
            insertIntoUsuario.AppendLine($"insert into {nameof(Usuario)} (id, nombre, idpueblo)");
            insertIntoUsuario.AppendLine($"VALUES (@guidUsuario, @nombreUsuario, @guidPueblo)");
            var nChangesUsuario = await connection.ExecuteAsync(insertIntoUsuario.ToString(), new
            {
                guidUsuario = Guid.NewGuid(),
                nombreUsuario = "garciss",
                guidPueblo
            });

            Console.WriteLine($"Agregado {nChangesPueblo + nChangesUsuario} registros");
        }
    }
}
