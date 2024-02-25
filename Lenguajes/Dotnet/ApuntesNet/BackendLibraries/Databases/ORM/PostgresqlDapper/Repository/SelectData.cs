using System.Data;


using Dapper;


using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository;

internal class SelectData(IDbConnection dbConnection)
{
    internal readonly IDbConnection dbConnection = dbConnection;

    internal async Task SelectDataQueryAsync()
    {
        var sqlPueblo = @$"SELECT Id as {nameof(Pueblo.IdPueblo)}
                                    ,Nombre as {nameof(Pueblo.NombrePueblo)}
                                FROM {nameof(Pueblo)}";
        var respuestaPueblo = await dbConnection.QueryAsync<Pueblo>(sqlPueblo);
    }
}
