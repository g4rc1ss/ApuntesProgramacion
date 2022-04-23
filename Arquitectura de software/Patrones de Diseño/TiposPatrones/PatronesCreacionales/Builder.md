# Builder
También llamado: **Constructor**

## Proposito

Es un patrón de diseño creacional que nos permite construir objetos complejos paso a paso. El patrón nos permite producir distintos tipos y representaciones de un objeto empleando el mismo código de construcción.

## Problema

Imaginemos una funcion que recibe muchos parametros para devolver una Query SQL formada, algo como:

```csharp
public string ResolveQuery(string select, string from, string where, string orderBy, string limit);

ResolveQuery("Id", "table", null, null, null);
ResolveQuery("Id", "table", "Id = 1", null, null);
```

Este codigo si nos fijamos es muy engorroso y nada descriptivo, porque si no necesitamos de todos los parametros, encima tenemos que enviar los datos a null.

## Solucion

Para la solución se puede crear una clase que implemente una serie de metodos para agregar las opciones, basicamente, pasar los parametros a ser funciones e ir agregandolos a variables de clase privadas y una funcion `Build()`, que se encargara de montarlo todo y devolver lo que se necesita.

```csharp
internal interface IPatronBuilder
{
    string Build();
    IPatronBuilder From(string from);
    IPatronBuilder OrderBy(string orderBy);
    IPatronBuilder Select(string select);
    IPatronBuilder Where(string where);
}

internal class PatronBuilder : IPatronBuilder
{
    private string _select;
    private string _where;
    private string _from;
    private string _orderby;

    public IPatronBuilder Select(string select)
    {
        _select = select;
        return this;
    }

    public IPatronBuilder Where(string where)
    {
        _where = where;
        return this;
    }

    public IPatronBuilder From(string from)
    {
        _from = from;
        return this;
    }

    public IPatronBuilder OrderBy(string orderBy)
    {
        _orderby = orderBy;
        return this;
    }

    public string Build()
    {
        var query = new StringBuilder();

        query.AppendLine($"SELECT {(!string.IsNullOrEmpty(_select) ? _select : "*")}");
        query.AppendLine($"FROM {_from}");

        if (!string.IsNullOrEmpty(_where))
        {
            query.AppendLine($"WHERE {_where}");
        }
        if (!string.IsNullOrEmpty(_orderby))
        {
            query.AppendLine($"ORDER BY {_orderby}");
        }

        return query.ToString();
    }
}


public static void Main(string[] args)
{
    var claseImplementaBuilder1 = new PatronBuilder();
    var claseImplementaBuilder2 = new PatronBuilder();
    var claseImplementaBuilder3 = new PatronBuilder();


    var query1 = claseImplementaBuilder1
        .Select("Id")
        .From("table")
        .Where("1 = 1")
        .OrderBy("Id")
        .Build();

    var query2 = claseImplementaBuilder2
        .From("table")
        .Build();

    var query3 = claseImplementaBuilder3
        .Select("Hola")
        .From("tableFrom")
        .Build();

    Console.WriteLine(query1);
    Console.WriteLine(query2);
    Console.WriteLine(query3);
}
```
De esta manera, la forma de crear la query es mucho mas clara por los nombres de las funciones y al poder concatenarse y usar el metodo Build() para la creacion de todo, es mucho mas claro.

## Estructura

![image](https://user-images.githubusercontent.com/28193994/147788813-274ff133-b0c5-4f46-bb4d-fbef70e4a585.png)
