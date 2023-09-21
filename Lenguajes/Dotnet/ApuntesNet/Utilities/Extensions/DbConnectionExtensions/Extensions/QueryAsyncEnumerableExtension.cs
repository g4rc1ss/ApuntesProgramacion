using System.Data;
using System.Data.Common;

namespace Garciss.DbConnectionExtensions.Extensions;

/// <summary>
/// 
/// </summary>
public static class QueryAsyncEnumerableExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="sql"></param>
    /// <param name="parameters"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    public static IAsyncEnumerable<T> ExecuteQueryAsync<T>(this DbConnection connection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        return ExecuteSelectQueryAsync(connection, sql, parameters, mapper, CommandType.Text);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="connection"></param>
    /// <param name="nameOfProcedure"></param>
    /// <param name="parameters"></param>
    /// <param name="mapper"></param>
    /// <returns></returns>
    public static IAsyncEnumerable<T> ExecuteProcedureAsync<T>(this DbConnection connection, string nameOfProcedure, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        return ExecuteSelectQueryAsync(connection, nameOfProcedure, parameters, mapper, CommandType.StoredProcedure);
    }

    private static async IAsyncEnumerable<T> ExecuteSelectQueryAsync<T>(DbConnection dbConnection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper, CommandType typeOfCommand)
    {
        using (dbConnection)
        {
            using var connect = dbConnection.CreateCommand();
            connect.CommandText = sql;
            connect.CommandType = typeOfCommand;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            await dbConnection.OpenAsync();

            using var rows = await connect.ExecuteReaderAsync();

            while (await rows.ReadAsync())
            {
                yield return mapper(rows);
            }
        }
    }

}
