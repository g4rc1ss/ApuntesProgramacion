using System.Data;


using Dapper;


using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class DeleteData(IDbConnection dbConnection)
{
    private readonly IDbConnection _dbConnection = dbConnection;

    internal async Task DeleteDataQueryAsync()
    {

        var deleteUsuario = @$"
DELETE FROM {nameof(Usuario)} 
WHERE Id = @idUsuario";
        var nChangesUsuario = await _dbConnection.ExecuteAsync(deleteUsuario.ToString(), new
        {
            idUsuario = 2
        });

        Console.WriteLine($"Borrado {nChangesUsuario} registros");
    }
}
