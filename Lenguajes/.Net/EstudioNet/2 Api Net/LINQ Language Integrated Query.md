Con el tiempo se han desarrollado diferentes lenguajes para los distintos tipos de orígenes de datos, como `SQL` para las bases de datos relacionales y `XQuery` para XML.

LINQ simplifica tener que aprender diferentes lenguajes de consulta para trabajar con los datos de varios formatos y orígenes. En una consulta LINQ siempre se trabaja con objetos. Se usan los mismos patrones de codificación básicos para consultar y transformar datos de documentos XML, bases de datos SQL, conjuntos de datos de ADO.NET, colecciones y cualquier otro formato para el que haya disponible un proveedor de LINQ.

Los objetos compatibles con LINQ tienen que tener implementadas las interfaces `IEnumerable` o `IQueryable`

- **IQueryable**: Está pensada para que sea implementada por proveedores de consultas. Un uso muy habitual es con `EntityFramework` para traducir las consultas a `SQL`. Esta interfaz esta pensada para ejecutar e interpretar [**árboles de expresion**](https://docs.microsoft.com/es-es/dotnet/csharp/expression-trees-explained#:~:text=Los%20%C3%A1rboles%20de%20expresiones%20son,y%20generar%20el%20resultado%20compilado.&text=Si%20fuera%20a%20analizarlo%20como,el%20%C3%A1rbol%20contiene%20varios%20nodos.)

# Sintaxis de Linq
Hay varias formas de hacer uso de esta libreria
- **Sintaxis de consulta**: Sintaxis de `C#` que es muy parecido visualmente a lenguajes como `SQL`. Internamente el compilador convierte este tipo de consulta a la sintaxis de metodo correspondiente. Es la forma recomendable de uso cuando creamos queries complejas.
- **Sintaxis de Metodo**: Metodos de extensión de Linq que, por lo general, reciben expresiones para realizar filtros, agrupaciones, ordenaciones, etc.

## Select
Filtra una secuencia de valores en función de un predicado.
```Csharp
from prod in products
select new ProductoDto
{
    Name = prod.Name,
};
```
```Csharp
products.Select(prod => new ProductoDto
{
    Name = prod.Name,
});
```

## Where
Filtra una secuencia de valores en función de un predicado.
```Csharp
from prod in products
where prod.Name == "Producto 2"
select prod;
```
```Csharp
products.Where(prod => prod.Name == "Producto 2");
```

## Join
Establece la correlación de dos secuencias basándose en claves coincidentes
```Csharp
from category in categories
join prod in products on category.ID equals prod.CategoryID
select new
{
    ProductName = prod.Name,
    Category = category.Name
};
```
```Csharp
products.Join(categories,
    product => product.CategoryID,
    category => category.ID,
    (product, category) => new
    {
        ProductName = product.Name,
        Category = category.Name
    });
```

## Order by
Ordena de manera ascendente y descendente los elementos de una secuencia.
```Csharp
from product in products
orderby product.CategoryID ascending
select product;
```
```Csharp
products.OrderBy(product => product.CategoryID);
```
```Csharp
from product in products
orderby product.CategoryID descending
select product;
```
```Csharp
products.OrderByDescending(product => product.CategoryID);
```

## Group by
Agrupa los elementos de una secuencia.
```Csharp
from product in products
group product by new
{
    product.CategoryID,
    product.Name
} into prod
select new
{
    idCategoria = prod.Key.CategoryID,
    nombre = prod.Key.Name
};
```
```Csharp
products.GroupBy(product => new
{
    product.CategoryID,
    product.Name
}).Select(prod => new
{
    idCategoria = prod.Key.CategoryID,
    nombre= prod.Key.Name
});
```

## Let
Almacenar el resultado de una subexpresión para usarlo en las cláusulas siguientes.
```Csharp
from sentence in strings
let words = sentence.Split(' ')
from word in words
let w = word.ToLower()
where w[0] == 'a' || w[0] == 'e'
    || w[0] == 'i' || w[0] == 'o'
    || w[0] == 'u'
select word;
```


# Ejecucion aplazada de consulta
La ejecución aplazada significa que la operación no se realiza en el punto en el código donde se declara la consulta. La operación se realiza solo cuando se enumera la variable de consulta, por ejemplo, mediante una instrucción `foreach`.


# Ejecucion Inmediata de consulta
La ejecución inmediata significa que se lee el origen de datos y la operación se realiza en el punto en el código donde se declara la consulta.

Algunos metodos que proporciona el api Linq para la ejecucion inmediata son los siguientes:
- **.ToArray**: Crea una matriz que contiene los resultados.
- **.ToList**: Fuerza la evaluación inmediata de la consulta y devuelve un `List<T>` que contiene los resultados de la consulta
- **.ToDictionary**: Crea un objeto `Dictionary<TKey,TValue>` según el selector de claves especificado y las funciones del selector de elementos.
- **.ToLookup**: Crea un objeto `Lookup<TKey,TElement>` genérico.
- **.FirstOrDefault**: Devuelve el primer elemento de una secuencia o un valor predeterminado si no se encuentra ningún elemento.
- **.SingleOrDefault**: Devuelve un único elemento concreto de una secuencia o un valor predeterminado si no se encuentra ese elemento.
- **.Count**: Devuelve el número de elementos de una secuencia.


# Personalizar Linq
Podemos ampliar Linq de forma personalizada creando metodos de extension sobre las interfaces `IEnumerable<T>` e `IQueryable<T>`.

## Extendiendo consulta sobre `IEnumerable`
Gracias al uso de yield podemos ahorrarnos el lastre de crear una clase personalizada para iteracion
1. Creamos el metodo de extension de `IEnumerable` y recibimos los parametros correspondientes para realizar la consulta
1. Creamos un bucle foreach del enumerable que recibimos para poder resolver el resto de iterators.
1. Realizamos el proceso de la consulta que necestiamos
1. Usamos la instruccion `yield return` para devolver el elemento.
```Csharp
public static IEnumerable<T> WherePersonalizado<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
{
    foreach (var item in enumerable)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```

## Extendiendo ejecucion inmediata sobre `IEnumerable`
Para resolver una consulta **linq** debemos de iterarlo, por ejemplo, creando un bucle foreach. De esta forma se resuelve la consulta.
```Csharp
public static List<T> ToListPersonalizada<T>(this IEnumerable<T> enumerable)
{
    var lista = new List<T>();
    foreach (var item in enumerable)
    {
        lista.Add(item);
    }
    return lista;
}
```
