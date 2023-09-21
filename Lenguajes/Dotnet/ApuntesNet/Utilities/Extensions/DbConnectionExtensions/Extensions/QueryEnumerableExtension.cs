using System.Data;
using System.Data.Common;

namespace Garciss.DbConnectionExtensions.Extensions;

/// <summary>
/// 
/// </summary>
public static class QueryEnumerableExtension
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
    public static IEnumerable<T> ExecuteSqlQuery<T>(this DbConnection connection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        return ExecuteSelectQuery(connection, sql, parameters, mapper, CommandType.Text);
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
    public static IEnumerable<T> ExecuteProcedure<T>(this DbConnection connection, string nameOfProcedure, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        return ExecuteSelectQuery(connection, nameOfProcedure, parameters, mapper, CommandType.StoredProcedure);
    }

    private static IEnumerable<T> ExecuteSelectQuery<T>(DbConnection dbConnection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper, CommandType typeOfCommand)
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
            dbConnection.Open();

            using var rows = connect.ExecuteReader();

            while (rows.Read())
            {
                yield return mapper(rows);
            }
        }
    }

}
