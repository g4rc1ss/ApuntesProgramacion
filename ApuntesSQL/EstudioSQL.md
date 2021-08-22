https://www.w3schools.com/sql/default.asp

# Sintaxis

```SQL
SELECT column_name(s)
FROM table_name
INNER JOIN table2 ON table_name.column_name = table2.column_name
WHERE condition
GROUP BY column_name(s)
HAVING condition
ORDER BY column_name(s);
```

# Tablas de Ejemplo:

## Orders
| OrderID |	CustomerID | OrderDate |
| ------- | ---------- | --------- |
| 10308 | 2  | 1996-09-18 |
| 10309 | 37 | 1996-09-19 |
| 10310 | 77 | 1996-09-20 |

## Customers
| CustomerID | CustomerName | ContactName |	Country |
| ---------- | ------------ | ----------- | ------- |
| 1 | Alfreds Futterkiste |	Maria Anders | Germany |
| 2 | Ana Trujillo Emparedados y helados | Ana Trujillo | Mexico |
| 3 | Antonio Moreno Taquería |	Antonio Moreno | Mexico |

# Select
La declaracion `SELECT` se usa para consultar registros de una base de datos.

Las consultas con Select se pueden realizar de dos formas, con el atributo `*` que te coge todas las columnas de la tabla automáticamente o indicando el nombre de las columnas manualmente
```SQL
-- Con *
SELECT * FROM Customers;

-- Con nombres de columnas
SELECT CustomerID, CustomerName, ContactName, Country FROM Customers;
```

## Distinct
La palabra reservada `Distinct` dentro de `SELECT` se utiliza para obtener resultados diferentes en la consulta cuando, por ejemplo, hay registros repetidos.

```SQL
-- Fijandonos en la tabla de arriba, esta query nos devolveria dos veces "Mexico"
SELECT Country FROM Customers;

-- De esta manera, solo devolveria 1 vez cada resultado
SELECT DISTINCT Country FROM Customers;
```

## Top
La palabra reservada `Top` dentro de `SELECT` se utiliza para indicar el maximo numero de registros que queremos obtener en la consulta.

> No todos los sistemas de Bases de Datos aceptan la sintaxis `TOP`, para cada cual, habra que buscar cual es su equivalente.
```SQL
SELECT TOP number
FROM table_name
WHERE condition;
```

## Alias
Los alias se utilizan para crear un nombre temporal a una columna o una tabla y poder operar sobre ellas con esos nombres.  

En una consulta de seleccion, muchas veces vas a requerir devolver campos que no necesariamente tienen que ser del mismo nombre que el de la columna a la que corresponde, por tanto, se pueden usar los alias para dicha opcion.

En las consultas, habitualmente, cuando se usan mas de una tabla, se hace uso de los alias para de una forma, aclarar mediante un nombre descriptivo el uso de dicho alias.
```SQL
-- Alias a columna
SELECT column_name AS alias_name
FROM table_name;

-- Alias a tabla
SELECT column_name(s)
FROM table_name AS alias_name;
```

## Union
La clausula `UNION` se utiliza para combinar los resultados de dos o mas consultas `SELECT`
- Cada `SELECT` debe de tener el mismo número de consultas para hacer uso de `UNION`
- Las columnas deben tener tipos de datos similares
- Las columnas deben estar en el mismo orden.

```SQL
-- Obtendra las ciudades de las dos tablas diferentes y las fusionara en un solo registro de resultados.
SELECT City FROM Customers
UNION
SELECT City FROM Suppliers;

-- Se fusionaran los resultados y si huberia duplicados, se agregarán de igual modo
SELECT City FROM Customers
UNION ALL
SELECT City FROM Suppliers;
```

## ALL
La condición será verdadera solo si la operación es verdadera para todos los valores en el rango. 

````SQL
SELECT ALL column_name(s)
FROM table_name
WHERE condition;
````

## INTO
La instruccion `INTO` se usa para copiar datos de una tabla SQL en otra.  
Puede ser usado para crear tablas Backup por ejemplo o para migrar una base de datos a otra.

````SQL
SELECT *
INTO newtable [IN externaldb]
FROM oldtable
WHERE condition;

-- Inserta en una tabla los clientes con pais "Germany"
SELECT * INTO CustomersGermany
FROM Customers
WHERE Country = 'Germany';
````

# Case
Una vez que una condición es verdadera devolverá el resultado que indiquemos. Si no se cumple ninguna condición, devuelve el valor de `ELSE`.

Si no hay `ELSE` y ninguna condición es verdadera, devuelve `NULL`
````SQL
SELECT columnName1, columnName2,
CASE
    WHEN condition1 THEN result1
    WHEN condition2 THEN result2
    WHEN conditionN THEN resultN
    ELSE result
END
FROM tableName;

SELECT OrderID, Quantity,
CASE
    WHEN Quantity > 30 THEN 'The quantity is greater than 30'
    WHEN Quantity = 30 THEN 'The quantity is 30'
    ELSE 'The quantity is under 30'
END AS QuantityText
FROM OrderDetails;

SELECT CustomerName, City, Country
FROM Customers
ORDER BY
(CASE
    WHEN City IS NULL THEN Country
    ELSE City
END);
````

# Where
La clausula `where` sirve para realizar filtrado de registros al realizar la consulta, por ejemplo, si queremos obtener un registro especifico por un campo `id`.

```SQL
SELECT *
FROM Customers
WHERE CustomerID = 1;
```

## Operadores de comparacion Where

| Operator | Description |
| -------- | ----------- |
| = | Igualdad |
| >	| Mayor que |
| <	| Menor que	|
| >= | Mayor o igual que |
| <= | Menor o igual que |
| <> | Distinto de |
| BETWEEN | Entre `x` e `y`. `WHERE column_name BETWEEN value1 AND value2;` |
| LIKE | Busca en el registro el texto que coincida con tu patrón de busqueda [Mas info.](#operador-like) |
| IN | Filtra el contenido de la consulta sobre una lista de resultados y devuelve los que coincidan con dicha lista |
| IS NULL | Comprueba si el valor en la columna es nulo |
| IS NOT NULL | Se comprueba si los registros no son nulos |

### Operador Like
> Estos Operadores pueden cambiar segun el SGDB

| Operator | Description |
| -------- | ----------- |
| WHERE CustomerName LIKE 'a%' | Busca los valores que empiecen por "a"
| WHERE CustomerName LIKE '%a' | Busca los valores que terminen por "a"
| WHERE CustomerName LIKE '%or%' | Busca los valores que contengan la palabra "or" en cualquier parte
| WHERE CustomerName LIKE '_r%' | Busca la palabra "r" ubicada en la segunda posición
| WHERE CustomerName LIKE 'a_%' | Busca los valores que empiecen por "a" y tenga 2 caracteres despues
| WHERE CustomerName LIKE 'a__%' | Busca los valores que empiecen por "a" y tenga 3 caracteres después
| WHERE ContactName LIKE 'a%o' | Busca cualquier valor que empiece por "a" y acabe por "o"

## Operadores Condicionales Where
| Operator | Description |
| -------- | ----------- |
| AND | Muestra un registro en el cual las condiciones que se agregan separadas este operador sea `TRUE` |
| OR | Muestra un registro en el cual una de las multiples condiciones agregadas a este operador sea `TRUE` |
| NOT | Es un operador que devuelve los registros que no cumplan la condicion escrita |

```SQL
SELECT column1, column2
FROM table_name
WHERE condition1 AND condition2 AND condition3;

SELECT column1, column2
FROM table_name
WHERE condition1 OR condition2 OR condition3;

SELECT column1, column2
FROM table_name
WHERE NOT condition

SELECT * FROM Customers
WHERE Country='Germany' AND (City='Berlin' OR City='München');
```

## Exists
Se utiliza para probar la existencia de cualquier registro en una subconsulta.

```SQL
SELECT column_name(s)
FROM table_name
WHERE EXISTS (
    SELECT column_name 
    FROM table_name 
    WHERE condition);
```

## ANY
- Devuelve un valor booleano como resultado
- Devuelve VERDADERO si CUALQUIERA de los valores de la subconsulta cumple la condición

````SQL
SELECT column_name(s)
FROM table_name
WHERE column_name operator ANY
  (SELECT column_name
  FROM table_name
  WHERE condition);
````

## ALL
- Devuelve un valor booleano como resultado.
- Devuelve VERDADERO si TODOS los valores de la subconsulta cumplen la condición
````SQL
SELECT column_name(s)
FROM table_name
WHERE column_name operator ALL
  (SELECT column_name
  FROM table_name
  WHERE condition);
````

# Order By
La clausula `Order By` se utiliza para ordenar de manera ascendente o descendente los resultados de una consulta.  
- `asc` : Ascendente
- `desc` : Descendente

Por defecto, si no se indica nada, se ordenada de manera ascendente
```SQL
SELECT column1, column2
FROM table_name
ORDER BY column1, column2 ASC|DESC;
```

# Join
La clausula `Join` se utiliza para realizar consultas a dos o mas tablas que tienen relación entre si.

## Inner Join
Devuelve registros cuando los valores coinciden en ambas tablas.

Por ejemplo para obtener todos los datos de una tabla vinculada con la otra, estas se vinculan por los id, que suelen ser las claves primarias/foraneas
```SQL
SELECT column_name(s)
FROM table1
INNER JOIN table2 ON table1.column_name = table2.column_name;

-- Ejemplo con las tablas de mas arriba
SELECT Orders.OrderID, Customers.CustomerName
FROM Orders
INNER JOIN Customers ON Orders.CustomerID = Customers.CustomerID;
```

## Left Join
Devuelve todos los registros de la tabla de la izquierda (Clientes), incluso si no hay coincidencias en la tabla de la derecha (Pedidos).

Si por ejemplo, quieres la lista de clientes y sus pedidos, pero no necesariamente todos los clientes tienen que tener pedidos, se puede realizar esta instruccion, puesto que te traera toda la lista de clientes tengan o no pedidos y los que si que tengan tendran el campo `OrderID` relleno
```SQL
SELECT column_name(s)
FROM table1
LEFT JOIN table2 ON table1.column_name = table2.column_name;

-- Si un Customer no tiene un Order vinculado, los campos correspondientes a Order, vendran null
SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
LEFT JOIN Orders ON Customers.CustomerID=Orders.CustomerID
```
Ejemplo de un resultado:

| CustomerName | OrderID |
| ------------ | ------- |
| Alfreds Futterkiste | null |

## Right Join
Devuelve todos los registros de la tabla de la derecha (Empleados), incluso si no hay coincidencias en la tabla de la izquierda (Pedidos)

```SQL
SELECT column_name(s)
FROM table1
RIGHT JOIN table2 ON table1.column_name = table2.column_name;

SELECT Orders.OrderID, Customers.CustomerName
FROM Orders
RIGHT JOIN Customers ON Orders.CustomerID = Customers.CustomerID;
```

## Full Join
Devuelve todos los registros coincidentes de ambas tablas, independientemente de que la otra tabla coincida o no.  
Por lo tanto, si hay filas en "Clientes" que no tienen coincidencias en "Pedidos", o si hay filas en "Pedidos" que no tienen coincidencias en "Clientes", esas filas también se enumerarán.
```SQL
SELECT column_name(s)
FROM table1
FULL OUTER JOIN table2 ON table1.column_name = table2.column_name

SELECT Customers.CustomerName, Orders.OrderID
FROM Customers
FULL OUTER JOIN Orders ON Customers.CustomerID=Orders.CustomerID;
```

# Group By
Agrupa la salida de datos en una única fila a modo resumen.  
Por ejemplo, en estas tablas pueden ser utilizado para obtener el numero de clientes que pertenecen a un pais. La consulta agrupará los registros por el nombre del pais y contará los, en este caso, clientes que pertenecen al pais.

```SQL
SELECT column_name(s)
FROM table_name
GROUP BY column_name(s);

SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country;
```

# Having
La palabra clave `Having` se utiliza para realizar un filtro sobre las agrupaciones.

Por ejemplo, para consultar los paises en los que hay mas de 5 clientes.  
La consulta primero agrupa por paises, cuenta los clientes que tiene cada pais y despues se ejecuta la clausula `HAVING` para filtrar sobre la agrupacion y mostrar los paises con mas de 5 clientes.
```SQL
SELECT COUNT(CustomerID), Country
FROM Customers
GROUP BY Country
HAVING COUNT(CustomerID) > 5;
```

# Insert
La clausula `Insert` se utiliza para poder crear registros a una tabla de la Base de Datos.
```SQL
-- Indicando nombres de la columna y el valor correspondiente a dicha columna
INSERT INTO table_name (column1, column2, column3, ...)
VALUES (value1, value2, value3, ...);

-- Indicando los valores, el orden en el que se agregan, es el orden de las columnas, por tanto, valor1 ira a columna 1
INSERT INTO table_name
VALUES (value1, value2, value3, ...);
```

## INSERT INTO SELECT
- Copia datos de una tabla y los inserta en otra tabla.
- Requiere que los tipos de datos en las tablas de origen y destino coincidan

````SQl
-- Copia todas las columnas de una tabla a otra tabla
INSERT INTO table2
SELECT * FROM table1
WHERE condition;

-- Copia solo algunas columnas de una tabla a otra tabla:
INSERT INTO table2 (column1, column2, column3, ...)
SELECT column1, column2, column3, ...
FROM table1
WHERE condition;
````

# Update
La clausula `Update` se utiliza para actualizar registros almacenados en la tabla indicada.

> Hay que tener cuidado con la actualizacion de los datos sin una clausula Where, puesto que si se ejecuta la consulta, se actualizaran TODOS los datos de dicha tabla

```SQL
UPDATE table_name
SET column1 = value1, column2 = value2
WHERE condition;
```

# Delete
La clausula `delete` se utiliza para borrar registros de una tabla

> Hay que tener cuidado con el borrado de los datos sin una clausula Where, puesto que si se ejecuta la consulta, se borraran TODOS los datos de dicha tabla

Para borrar un registro especifico, se ha de indicar en la clausula where la el contenido de la columna de la primary key
```SQL
DELETE FROM table_name 
WHERE condition;
```
