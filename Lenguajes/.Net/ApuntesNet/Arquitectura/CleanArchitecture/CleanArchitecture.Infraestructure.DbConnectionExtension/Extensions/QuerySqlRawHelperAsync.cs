using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;

namespace CleanArchitecture.Infraestructure.DbConnectionExtension.Extensions;

public static class QuerySqlRawHelperAsync
{
    public static async Task<List<T>> ExecuteSqlQueryAsync<T>(this DbConnection connection, string sql, List<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        using (var connect = connection.CreateCommand())
        {
            connect.CommandText = sql;
            connect.CommandType = System.Data.CommandType.Text;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            await connection.OpenAsync();

            using (var rows = await connect.ExecuteReaderAsync())
            {
                var entities = new List<T>();
                while (await rows.ReadAsync())
                {
                    entities.Add(mapper(rows));
                }
                return entities;
            }
        }
    }

    public static async Task<List<T>> ExecuteProcedureAsync<T>(this DbConnection connection, string nameOfProcedure, List<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        using (var connect = connection.CreateCommand())
        {
            connect.CommandType = System.Data.CommandType.StoredProcedure;
            connect.CommandText = nameOfProcedure;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            await connection.OpenAsync();

            using (var rows = await connect.ExecuteReaderAsync())
            {
                var entities = new List<T>();
                while (await rows.ReadAsync())
                {
                    entities.Add(mapper(rows));
                }
                return entities;
            }
        }
    }

}
