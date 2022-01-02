CREATE USER nombre\_usuario IDENTIFIED BY contraseña;

GRANT DBA TO nombre\_usuario;

CREATE TABLESPACE  nombre\_tablespace DATAFILE &#39; ruta y nombre del fichero&#39; SIZE númeroM;

CREATE TABLE nombre\_tabla

(nombre\_columna tipo\_datos [DEFAULT valor] [NULL|NOT NULL|],

…

…

Restricciones de tabla) TABLESPACES nombre\_tablespaces;

Restricciones de tabla:

PRIMARY KEY(nombre\_columna, ….)

UNIQUE(nombre\_columna)

CHECK(condición/es)

FOREIGN KEY(nombre\_columna,…)REFERENCES nombre\_tabla [ON DELETE {NO ACTION|CASCADE}]



CREATE TABLE nombre\_tabla AS SELECT \* FROM nombre\_tabla -\&gt;copia estructura y datos, no copia llave, check,…

ALTER TABLE nombre\_tabla DROP COLUMN nombre\_columna;

ALTER TABLE nombre\_tabla MODIFY nombre\_columna tipo\_datos

ALTER TABLE nombre\_tabla {DISABLE|ENABLE} CONSTRAINT nombre\_restricción;



ALTER TABLE nombre\_tabla MODIFY nombre\_columna DEFAULT NULL;

ALTER TABLE nombre\_tabla MODIFY nombre\_columna DEFAULT valor;



DROP TABLE nombre\_tabla [CASCADE CONSTRAINTS];



DROP TABLESPACE nombre\_tablespace [INCLUDING CONTENTS];

DESC nombre\_tabla| nombre\_vista;



Permiso para crear vistas de tablas de otros usuarios y para crear claves foráneas de una tabla de otro usuario:

GRANT ALL ON nombre\_tabla TO nombre\_usuario;



VISTAS:

USER\_TABLES| USER\_TABLESPACES| USER\_VIEWS| USER\_CONSTRAINTS|….

ALL\_TABLES| ALL\_TABLESPACES| ALL\_ CONSTRAINTS|….

Reglas de integridad y columna a la que afectan -\&gt;vista:  SYS.ALL\_CONS\_COLUMNS

\*\*En where al hacer referencia a las tablas, se deben escribir en mayúsculas.



Fecha del sistema:   SYSDATE

COMILLAS SIMPLES Y DOBLES COMILLAS

SELECT \* FROM EMPLEADOS WHERE PROVINCIA=&#39;Bizkaia&#39;;

SELECT NOM &quot;nombre del empleado&quot; FROM EMPLEADOS;



La claúsula IN en Oracle admite N columnas

ALTER TABLE  nombre\_tabla RENAME COLUMN nombre\_anterior TO  nombre\_nuevo;

Cambiar nombre a una tabla: RENAME nombre \_anterior TO nombre\_nuevo;

Para trabajar con tablas de otro usuario: SELECT \* FROM nombre\_usuario.nombre\_tabla;