using Dapper;
using PostgresqlDapper.Entities;

namespace PostgresqlDapper.Repository.SelectExtensionMethods
{
    internal static class SelectDataSingle
    {
        internal static async Task SelectDataSingleAsync(this SelectData select)
        {
            var sqlPueblo = @$"
SELECT Id as {nameof(Pueblo.IdPueblo)}
    ,Nombre as {nameof(Pueblo.NombrePueblo)}
FROM {nameof(Pueblo)}
WHERE Id = @IdPueblo
";
            var parameters = new
            {
                IdPueblo = 2
            };

            var respuestaPueblo = await select._dbConnection.QuerySingleAsync<Pueblo>(sqlPueblo, parameters);
        }
    }
}
