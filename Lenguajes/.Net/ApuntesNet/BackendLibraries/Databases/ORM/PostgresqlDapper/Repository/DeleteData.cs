using System.Data;
using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository
{
    internal class DeleteData
    {
        private readonly IDbConnection _dbConnection;

        public DeleteData(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

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
}
