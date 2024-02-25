using System.Data;


using Dapper;


using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class UpdateData(IDbConnection dbConnection)
{
    private readonly IDbConnection _dbConnection = dbConnection;

    internal async Task UpdateDataQueryAsync()
    {

        var updatePueblo = @$"
UPDATE {nameof(Pueblo)}
SET nombre = 'Bilbao'
WHERE Id = @idPueblo;

UPDATE {nameof(Usuario)}
SET nombre = 'Ramon'
WHERE Id = @idUsuario
";

        var nChanges = await _dbConnection.ExecuteAsync(updatePueblo, new
        {
            idPueblo = 1,
            idUsuario = 4,
        });

        Console.WriteLine($"Actualizado {nChanges} registros");
    }
}
