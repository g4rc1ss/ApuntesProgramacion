using System;
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

            var insert = @$"
insert into {nameof(Pueblo)} (id, nombre)
values (@guidPueblo, @NombrePueblo);

insert into {nameof(Usuario)} (id, nombre, idpueblo)
VALUES (@guidUsuario, @nombreUsuario, @guidPueblo);";
            var nChanges = await connection.ExecuteAsync(insert, new
            {
                guidPueblo = Guid.NewGuid(),
                NombrePueblo = "Albacete",
                guidUsuario = Guid.NewGuid(),
                nombreUsuario = "garciss",
            });

            Console.WriteLine($"Agregado {nChanges} registros");
        }
    }
}
