using System;
using System.Collections.Generic;
using System.Data.Common;

namespace CleanArchitecture.Infraestructure.DbConnectionExtension.Extensions;

public static class QuerySqlRawHelper
{
    public static List<T> ExecuteSqlQuery<T>(this DbConnection connection, string sql, List<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        using (var connect = connection.CreateCommand())
        {
            connect.CommandText = sql;
            connect.CommandType = System.Data.CommandType.Text;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            connection.Open();

            using (var rows = connect.ExecuteReader())
            {
                var entities = new List<T>();
                while (rows.Read())
                {
                    entities.Add(mapper(rows));
                }
                return entities;
            }
        }
    }

    public static List<T> ExecuteProcedure<T>(this DbConnection connection, string nameOfProcedure, List<DbParameter> parameters, Func<DbDataReader, T> mapper)
    {
        using (var connect = connection.CreateCommand())
        {
            connect.CommandType = System.Data.CommandType.StoredProcedure;
            connect.CommandText = nameOfProcedure;

            foreach (var parameter in parameters)
            {
                connect.Parameters.Add(parameter);
            }
            connection.Open();

            using (var rows = connect.ExecuteReader())
            {
                var entities = new List<T>();
                while (rows.Read())
                {
                    entities.Add(mapper(rows));
                }
                return entities;
            }
        }
    }

}
