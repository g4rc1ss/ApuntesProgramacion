Es un Micro-ORM(Object Relational Mapper) creado por `Stackoverflow` encargado de ejecutar queries SQL y devolver el resultado mapeado en un objeto.

# **Caracteristicas de Dapper**
Las caracteristicas principales de Dapper son.

- **Consulta y Mapeo**: Dapper en concreto se centra en hacer un mapeo rápido y preciso de nuestros objetos. 
- **Rendimiento**: Dapper es el rey de los ORM en términos de rendimiento, para conseguir esto, extiende la interfaz `IDbConnection`, lo que implica que es un poco más cercano “al core” del lenguaje, y nos da beneficios de rendimiento. Dapper tiene en su página de [GitHub](https://github.com/DapperLib/Dapper#performance) una lista con el rendimiento comparado con otros ORM.
- **Api muy sencilla**:  El objetivo de dapper es hacer un par de funcionalidades y hacerlas todas muy bien. La api, nos provee de tres tipos de métodos.
    - Métodos que mapean tipos concretos.
    - Métodos que mapean tipos dinámicos.
    - Métodos para ejecutar comandos, como por ejemplo insert o delete;

- **Cualquier Base de Datos**: Al trabajar directamente con `IDbConnection`, permite utilizar las librerias de conexion de otras bases de datos, como MySQL, SqlServer, Postgres, etc.

# Dependency Injection with Dapper
Dapper extiende directamente de la interfaz `IDbConnection`, por tanto para mandar el objeto de conexion mediante Inyeccion de dependencias, se debera de usar dicha interfaz.

```Csharp
services.AddScoped<IDbConnection>(service => new SqlConnection(configuration.GetConnectionString("Database")));
```

# Ejecución de Consultas
Dapper tiene la opcion de realizar la ejecucion de las consultas de forma `sincrona` y `asincrona`

## SELECT
Hay varias funciones para realizar consultas con Dapper.

### QuerySingleOrDefault<>
Cuando queremos realizar una consulta que solamente va a devolver una fila, ejecutamos el metodo `QuerySingleOrDefault`, que nos devolvera una instancia del objeto mapeado que solicitamos

```Csharp
con.QuerySingleOrDefaultAsync<T?>($"SELECT * FROM {TableName} where UserId = @userId", new
{
    userId = userId
});
```

### Query<>
Cuando queremos obtener una lista de objetos mapeados de una query, usamos el metodo `QueryAsync` y este nos devolvera un objeto `IEnumerable<T>` que podremos iterar, convertir a `List`, etc.

```Csharp
con.QueryAsync<T>($"SELECT * FROM {TableName} where UserId = @userId", new
{
    userId = userId
});
```

### Consultas relacionadas de varias entidades
Cuando queremos ejecutar consultas relacionadas, queremos mapear objetos completos, por ejemplo, un usuario pertenece a un municipio y tenemos una clase `Usuario` y una clase `Pueblo`,

La entidad usuario es la siguiente:

```Csharp
public class Usuario
{
    public string IdUsuario { get; set; }
    public string NombreUsuario { get; set; }

    public Pueblo FKPueblo { get; set; }
}

internal class Pueblo
{
    internal string IdPueblo { get; set; }
    internal string NombrePueblo { get; set; }
}
```

Por tanto queremos realizar la siguiente consulta para obtener un listado de usuarios, con el correspondiente pueblo tendremos que realizar nosotros mismos el mapeo.

1. Creamos la query SQL en orden, primero deberemos de seleccionar lo correspondiente a un objeto todos los parametros y despues el siguiente, en este caso, primero los parametros de usuario y despues los del pueblo correspondiente al usuario
1. La funcion `Query<T1, T2, TResult>` se le pasan los parametros de los objetos que tiene que crear y por ultimo el objeto resultante, en este caso, primero indicamos la clase `Usuario`, despues `Pueblo` y por ultimo indicamos que el objeto a devolver es `Usuario`
    1. En el primer parametro indicamos el mapeo a realizar y donde tenemos que ubicar los diferentes objetos
    1. En el segundo parametro le pasamos un objeto para la query parametrizada, de esta forma evitamos ataques SQL Injection
    1. En el parametro llamado `splitOn` tenemos que indicar el objeto a partir del cual debemos separar los objetos a crear, en este caso indicamos que cada vez que se encuentre el nombre "IdPueblo" se debe de mapear el siguiente objeto.  
    Tener en cuenta que en el caso de que haya mas objetos a mapear, se deberan separar por comas `,`, por ejemplo `IdPueblo,OtroId`

```Csharp
var sqlPueblo = @$"SELECT user.Id as {nameof(Usuario.IdUsuario)}
                    ,user.Nombre as {nameof(Usuario.NombreUsuario)}
                    ,village.Id as {nameof(Pueblo.IdPueblo)}
                    ,village.Nombre as {nameof(Pueblo.NombrePueblo)}
                FROM {nameof(Usuario)} as user
                INNER JOIN {nameof(Pueblo)} as village ON user.IdPueblo = village.Id
                WHERE user.Id = @idUsuario";
var respuestaPueblo = connection.QueryAsync<Usuario, Pueblo, Usuario>(sqlPueblo, (user, pueblo) =>
{
    user.FKPueblo = pueblo;
    return user;
}, new
{
    idUsuario = "IdUsuario3"
}, splitOn: $"{nameof(Pueblo.IdPueblo)}");
```

### QueryMultiple
A veces para obtener una serie de datos, necesitamos realizar varias consultas diferentes. Para ello dapper permite la ejecucion de varias queries juntas en orden.

1. Creamos la `sql` con las diferentes queries, para separarlas se pone el `;` al finalizar la query correspondiente.
1. Ejecutamos el metodo `QueryMultiple` con la SQL
1. Obtenemos los resultados de dicha query de forma ordenada.  
Si primero realizamos una Select sobre los usuarios, debemos de ejecutar el metodo `Read<>` de usuarios y asi sucesivamente.

```Csharp
var sqlMultipleUserPueblo = $@"
SELECT Id as {nameof(Usuario.IdUsuario)}
    ,Nombre as {nameof(Usuario.NombreUsuario)}
FROM Usuario
ORDER BY Id;

SELECT Id as {nameof(Pueblo.IdPueblo)}
    ,Nombre as {nameof(Pueblo.NombrePueblo)}
FROM Pueblo
ORDER BY Id;
";
var queryMultiple = await connection.QueryMultipleAsync(sqlMultipleUserPueblo);
var users = await queryMultiple.ReadAsync<Usuario>();
var villages = await queryMultiple.ReadAsync<Pueblo>();
```

## INSERT
Para insertar un registro nuevo en la Base de Datos con Dapper, se deberá de crear la sql correspondiente y ejecutar la función `ExecuteAsync` que devolvera el numero de registros modificados.

```Csharp
var guidPueblo = Guid.NewGuid();
var insertIntoPueblo = @$"
insert into {nameof(Pueblo)} (id, nombre)
values (@guidPueblo, @NombrePueblo)";
var nChangesPueblo = await connection.ExecuteAsync(insertIntoPueblo, new
{
    guidPueblo,
    NombrePueblo = "Albacete"
});
```

### Insert varias queries
Para insertar varias queries con dapper, simplemente debemos separar las `INSERT INTO` con `;` y mandar la sql en la funcion de `ExecuteAsync()`

```Csharp
var insert = @$"
insert into {nameof(Pueblo)} (id, nombre)
values (@guidPueblo, @NombrePueblo);

insert into {nameof(Usuario)} (id, nombre, idpueblo)
VALUES (@guidUsuario, @nombreUsuario, @guidPueblo);";

var nChanges = await connection.ExecuteAsync(insert, new
{
    guidPueblo = Guid.NewGuid(),
    NombrePueblo = "Albacete",
    guidUsuario = Guid.NewGuid(),
    nombreUsuario = "garciss",
});
```

### Insertar varios registros en la misma Tabla
Si necesitamos registrar varios datos en el mismo proceso, podemos enviar un array de objetos parametrizados.

```Csharp
var foos = new List<Foo>
{
    { new Foo { A = 1, B = 1 } }
    { new Foo { A = 2, B = 2 } }
    { new Foo { A = 3, B = 3 } }
};

var count = connection.Execute(@"insert MyTable(colA, colB) values (@a, @b)", foos);
```

## UPDATE
Para actualizar registros de la base de datos con `Dapper` ejecutamos igualmente `ExecuteAsync()`

```Csharp
var updatePueblo = @$"
UPDATE {nameof(Pueblo)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idPueblo;

UPDATE {nameof(Usuario)}
SET Id = '{Guid.NewGuid()}'
WHERE Id = @idUsuario";
var nChanges = await connection.ExecuteAsync(updatePueblo, new
{
    idPueblo = "IdPueblo1",
    idUsuario = "IdUsuario1",
});
```

## DELETE
Para borrar registros de la base de datos con `Dapper` ejecutamos igualmente `ExecuteAsync()`

```Csharp
var deleteUsuario = @$"
DELETE FROM {nameof(Usuario)} 
WHERE Id = @idUsuario";
var nChangesUsuario = await connection.ExecuteAsync(deleteUsuario.ToString(), new
{
    idUsuario = "IdUsuario2"
});

Console.WriteLine($"Borrado {nChangesUsuario} registros");
```


# Ejecutar Procedimientos Almacenados
Un procedimiento almacenado de SQL Server es un grupo de una o más instrucciones Transact-SQL.

- Si el procedimiento va a retornar los datos como una consulta, podemos realizar la siguiente instrucción.
    ```Csharp
    cnn.Query<User>("StoredProcedureName", new {Id = 1},
            commandType: CommandType.StoredProcedure).SingleOrDefault();
    ```
- Si el procedimiento retorna por variable de dirección, ejecutaremos el siguiente código
    ```Csharp
    var p = new DynamicParameters();
    p.Add("@a", 11);
    p.Add("@b", dbType: DbType.Int32, direction: ParameterDirection.Output);
    p.Add("@c", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);
    
    cnn.Execute("spMagicProc", p, commandType: CommandType.StoredProcedure);

    int b = p.Get<int>("@b");
    int c = p.Get<int>("@c");
    ```
