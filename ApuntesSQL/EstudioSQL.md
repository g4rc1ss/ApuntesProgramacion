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


# Join

# Union

# Insert

# Update

# Delete

