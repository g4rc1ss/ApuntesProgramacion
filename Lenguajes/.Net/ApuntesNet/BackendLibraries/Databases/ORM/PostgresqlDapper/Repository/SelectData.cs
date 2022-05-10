using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository
{
    internal class SelectData
    {
        internal readonly IDbConnection _dbConnection;

        public SelectData(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        internal async Task SelectDataQueryAsync()
        {
            var sqlPueblo = @$"SELECT Id as {nameof(Pueblo.IdPueblo)}
                                    ,Nombre as {nameof(Pueblo.NombrePueblo)}
                                FROM {nameof(Pueblo)}";
            var respuestaPueblo = await _dbConnection.QueryAsync<Pueblo>(sqlPueblo);
        }
    }
}
