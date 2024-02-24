ADO.NET proporciona acceso coherente a orígenes de datos como SQL Server y XML, así como a orígenes OLE DB y ODBC.

El funcionamiento de ADO.NET se basa esencialmente en utilizar los siguientes componentes:
- **DataSet**: El componente más importante, puede almacenar datos provenientes de múltiples consultas.
- **DataReader** Realiza eficientemente lecturas de grandes cantidades de datos que no caben en memoria
- **DbConnection** Utilizada para conectarse a la base de datos.
- **DbCommand** Permite especificar las órdenes, generalmente en `SQL`.

Un proveedor de datos debe proporcionar una implementación de Connection, Command, DataAdapter y DataReader.

El modo de funcionamiento típico de ADO.NET es el siguiente:
- Se crean un objeto `DbConnection` especificando la cadena de conexión.
- Se crea un objeto `DbCommand` y se indica la Query `SQL`.
- Se crea un DataSet donde almacenar los datos.
- Se abre la conexión.
- Se rellena el DataSet con datos a través del DataAdapter.
- Se cierra la conexión.
- Se trabaja con los datos almacenados en el DataSet.

# Interfaz `IDbConnection`
Representa una conexión abierta a un origen de datos y se implementa mediante proveedores de datos de .NET que acceden a bases de datos relacionales, por ejemplo, `SqlClient`.

# Interfaz `IDbCommand`
Se utiliza para definir, parametrizar y ejecutar una consulta al origen de datos, por ejemplo, una query SQL a una Sqlite.

Dispone de los siguientes metodos:
- `ExecuteReader()` Devuelve un `IDataReader` para leer los datos de una consulta, por ejemplo, para una `SELECT`
- `ExecuteScalar` devuelve un objeto, por ejemplo, para procedimientos almacenados
- `ExecuteNonQuery` devuelve un `int` para indicar el numero de registros modificados, por tanto se usara para insertar, actualizar y borrar.

# Interfaz `IDataReader`
Proporciona acceso secuencial de sólo lectura a una fuente de datos, por ejemplo, los datos que nos devuelve la consulta.
> Utilizar IDataReader deshabilita las operaciones con IDbConnection hasta que esta sea cerrada.

# Clase `DataSet`
Un DataSet encapsula un conjunto de tablas independientemente de su procedencia y mantiene las relaciones existentes entre estas.

El contenido de un DataSet puede serializarse en formato XML.

# Clase `DataTable`
Conjunto de `DataColumn` y `DataRow` que reprensenta el concepto de una tabla en memoria. La integridad de los datos se mantienen gracias al uso de objetos que representan restricciones

- `DataColumn` Define el tipo de una columna de una tabla e incluye las restricciones y las relaciones que afectan a la columna.
- `DataRow` Representa una coleccion de Rows en un `DataTable`, de acuerdo con el esquema definido por los `DataColumn` de la tabla. Además, incluye propiedades para determinar el estado de una fila especifica, por ejemplo, "nuevo, cambiado, borrado, etc".

> Cabe decir que las clases `DataSet` y `DataTable` no necesariamente se tienen que utilizar para el acceso a bases de datos, se pueden crear y utilizar para uso normal si, por ejemplo, queremos crear una tabla en memoria por algun motivo. No obstante, habra que valorar eso en cuestiones de rendimiento.

# Microsoft SQL Server
El procedimiento de una consulta sql con las clases abstractas podria ser el siguiente:

1. Creamos una extension de la clase abstracta `DbConnection` para tener acceso a las llamadas asincronas, recibimos la `sql`, una lista de `DbParameter` para parametrizar la query y el delegado en el que vamos a indicar el proceso de mapeo
1. Indicamos al objeto connection que se desechará al acabar, creamos un `DbCommand`, que sera el encargado de la ejecucion y lectura de la query.
1. Pasamos la query al `CommandText` e indicamos que es de tipo `text`, esto es debido a que podemos pasarle tipos como el de `StoredProcedure`.
1. Si tenemos parametros, los agregamos.
1. Abrimos la conexion de forma asincrona
1. Ejecutamos la query de forma asincrona
1. Leemos los resultados de forma asincrona y al agregar a la lista que devolvemos el resultado, lo mapeamos con el delegado que le pasamos.
```Csharp
public static async Task<IEnumerable<T>> ExecuteSqlQueryAsync<T>(this DbConnection connection, string sql, IEnumerable<DbParameter> parameters, Func<DbDataReader, T> mapper)
{
    using (connection)
    {
        using var connect = connection.CreateCommand();
        connect.CommandText = sql;
        connect.CommandType = System.Data.CommandType.Text;

        foreach (var parameter in parameters)
        {
            connect.Parameters.Add(parameter);
        }
        await connection.OpenAsync();

        using var rows = await connect.ExecuteReaderAsync();
        var entities = new List<T>();
        while (await rows.ReadAsync())
        {
            entities.Add(mapper(rows));
        }
        return entities;
    }
}
```
> **Importante**: Hay que hacer uso de las queries parametrizadas para evitar problemas como las Sql Injection.
