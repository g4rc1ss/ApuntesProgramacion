https://www.w3schools.com/sql/default.asp

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
La clausula `Distinct` dentro de `SELECT` se ustiliza para obtener resultados diferentes en la consulta cuando, por ejemplo, hay registros repetidos.

```SQL
-- Fijandonos en la tabla de arriba, esta query nos devolveria dos veces "Mexico"
SELECT Country FROM Customers;

-- De esta manera, solo devolveria 1 vez cada resultado
SELECT DISTINCT Country FROM Customers;
```

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
| BETWEEN | Entre x e y. Se usa para filtrar entre un rango de dos resultados, por ejemplo, un rango de fechas|
| LIKE | Busca algo que coincida, que aplican patrones de busqueda, por ejemplo, `LIKE '%textoBuscar%'`, el `%` indica que le da igual el contenido que haya, o antes, o despues de tu filtro |
| IN | Filtra el contenido de la consulta sobre una lista de resultados y devuelve los que coincidan con dicha lista |
| IS NULL | Comprueba si el valor en la columna es nulo |
| IS NOT NULL | Se comprueba si los registros no son nulos |

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
La clausula ``

# Union
La clausula ``


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
