1. [Create DB](#create-db)

1. [Drop DB](#drop-db)

1. [Backup DB](#backup-db)

1. [Create Table](#create-table)

	 1. [Create Table AS](#create-table-as)

	 1. [Constraints](#constraints)

		 1. [Ejemplos de los diferentes Constraints](#ejemplos-de-los-diferentes-constraints)

1. [Drop Table](#drop-table)

1. [Alter Table](#alter-table)

1. [Vistas](#vistas)

1. [Tipos de datos](#tipos-de-datos)


# Create DB
Sentencia `SQL` para crear una Base de Datos nueva.

````SQL
CREATE DATABASE databasename;
````

# Drop DB
Sentencia `SQL` para borrar una Base de Datos.
````SQL
DROP DATABASE databasename;
````

# Backup DB
Sentencia `SQL` para crear una copia de seguridad de una Base de Datos.

````SQL
BACKUP DATABASE databasename
TO DISK = 'filepath';
````

# Create Table
Sentencia `SQL` para crear una tabla

````SQL
CREATE table tablename(
    column1 datatype,
    column2 datatype,
    column3 datatype,
);

CREATE TABLE Persons (
    PersonID int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
);
````

## Create Table AS
Crea una tabla a traves de otra ya creada, realiza copia de la estructura y de los datos indicados en la query
````SQL
CREATE TABLE new_table_name AS
SELECT column1, column2
FROM existing_table_name
WHERE condition;
````

## Constraints
Las restricciones se utilizan para crear reglas en para los datos de una tabla, por ejemplo, para indicar la primary key.

````SQL
CREATE TABLE table_name (
    column1 datatype constraint,
    column2 datatype constraint,
    column3 datatype constraint,
);
````

| Constraints | Description |
| ----------- | ----------- |
| NOT NULL | Una columna no pueda tener un valor NULL |
| UNIQUE | Todos los valores de una columna deben ser diferentes |
| PRIMARY KEY | Una combinación de una `NOT NULL` y `UNIQUE`. Identifica de forma única cada fila en una tabla |
| FOREIGN KEY | Vincula la tabla que se esta creando con otra ya creada y evita acciones que destruirían enlaces entre dichas tablas |
| CHECK | Los valores en una columna deben cumplir una condición específica |
| DEFAULT | Establece un valor predeterminado para una columna si no se especifica ninguno |
| CREATE INDEX | Se utiliza para crear y recuperar datos más rápido |
| AUTOINCREMENT | Se utiliza para, cada vez que se agrega un nuevo registro, incrementar el `id` de manera automática |

### Ejemplos de los diferentes Constraints

````SQL
-- NOT NULL
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255) NOT NULL,
    Age int
);

-- UNIQUE
CREATE TABLE Persons (
    ID int NOT NULL UNIQUE,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);

CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    CONSTRAINT UC_Person UNIQUE (ID,LastName)
);

-- PRIMARY KEY
CREATE TABLE Persons (
    ID int NOT NULL PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);

CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    CONSTRAINT PK_Person PRIMARY KEY (ID,LastName)
);

-- FOREIGN KEY
CREATE TABLE Orders (
    OrderID int NOT NULL PRIMARY KEY,
    OrderNumber int NOT NULL,
    PersonID int FOREIGN KEY REFERENCES Persons(PersonID)
);

CREATE TABLE Orders (
    OrderID int NOT NULL,
    OrderNumber int NOT NULL,
    PersonID int,
    PRIMARY KEY (OrderID),
    CONSTRAINT FK_PersonOrder FOREIGN KEY (PersonID)
    REFERENCES Persons(PersonID)
);

-- CHECK
CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int CHECK (Age>=18)
);

CREATE TABLE Persons (
    ID int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int,
    City varchar(255),
    CONSTRAINT CHK_Person CHECK (Age>=18 AND City='Sandnes')
);

-- DEFAULT
CREATE TABLE Orders (
    ID int NOT NULL,
    OrderNumber int NOT NULL,
    OrderDate date DEFAULT GETDATE()
);

-- CREATE INDEX
CREATE INDEX index_name
ON table_name (column1, column2, ...);

-- AUTOINCREMENT
CREATE TABLE Persons (
    Personid int IDENTITY(1,1) PRIMARY KEY,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Age int
);
````

# Drop Table
Sentencia `SQL` para borrar una tabla

````SQL
DROP table tablename;
````

# Alter Table
Sentencia `SQL` para modificar una tabla pudiendo agregar, borrar o moidificar las columnas de la tabla.  

````SQL
-- Creamos una columna nueva
ALTER TABLE table_name
ADD column_name datatype;

-- Borramos una columna existente
ALTER TABLE table_name
DROP COLUMN column_name;

-- Modificamos una columna
ALTER TABLE table_name
ALTER COLUMN column_name datatype;
````

# Vistas
Una vista es una tabla virtual basada en el conjunto de resultados de una declaracion SQL.

Una vista contiene filas y columnas, como una tabla real. Los campos de una vista son campos de una o mas tablas reales de la base de datos.

> Una vista siempre muestra datos actualizados! El motor de la base de datos recrea la vista cada vez que un usuario la consulta.
````SQL
CREATE VIEW view_name AS
SELECT column1, column2, ...
FROM table_name
WHERE condition;
````

# Tipos de datos
Puesto que cada SGDB maneja diferentes tipos de datos para almacenar los registros, dejo un enlace donde hay informacion de los Sistemas Gestores mas usados [aqui](https://www.w3schools.com/sql/sql_datatypes.asp) 