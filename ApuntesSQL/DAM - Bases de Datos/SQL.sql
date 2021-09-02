/*

Crear y eliminar objetos 
Crear: CREATE
Eliminar: DROP
Altas: INSERT
Bajas: DELETE
Modificaciones: UPDATE
Consultas: SELECT
Conceder y denegar permisos:
Conceder: GRANT
Denegar: REVOKE

SQL interativo y SQL embebido (juntándolo con otros lenguajes de programación como java…)


EJERCICIO 1 de ejemplo con sql
EMPLEADOS:
NEmpl
Nom
Puesto
Fecha-Alta
Sueldo
Comision
COD-DPTO
NUM-SS

El mínimo del sueldo es : 1000.00€
La comisión por defecto es 6,5€ y el numero de ls SS tiene que ser único

*/

Codigo:
CREATE TABLE empleados

(
	
	Nempl Varchar2( 5 ) PRIMARY KEY,
	
	NOM varchar2( 50 ),
	
	PUESTO varchar2( 20 ),
	
	FECHA_Alta DATE,

	SUELDO NUMBER ( 6,2 ) CHECK ( sueldo > 1000 ),

	COMISION NUMBER ( 4,2 ) DEFAULT 6.5,

	Cod_DPTO varchar2( 5 ) REFERENCES DPTOS( Cod-DPTO ) ON DELETE CASCADE ON UPDATE NO ACTION,

	NUM_SS varchar2( 5 ) UNIQUE ); -- 1 forma de hacerlo unico


/*
	Sintaxtis para crear el esquema de una base de datos

		CREATE SCHEMA nombreBD [ AUTHORIZATION contraseña ];

	
	Sintaxtis paracrear tablas

		CREATE TABLE [ nombreBB. ] nombreTabla

		( nombreColumna  tipoDeDatos | dominio  [ expresion DEFAULT ]  [ restricciones de columnas ],  (Restricciones de columna se pueden poner en :
																											NULL/NOTNULL
																											UNIQUE/PRMARY KEY
																											REFERENCES nombretable[ ( nombreColumna ) ]) ONDELETE Y ONUPDATE
																											CHECK( CONDICION )

		....

		....


	[ restricciones de tabla ] )

		unique/primary key

		FOREKN KEY ( campo 1, campo2 ) REFERENCES nombretabla( [ nombreColumna ] )

	
	DOMINIOS:

		En vez de tipo de datos se puede utilizar un dominio

			CREATE DOMAIN nombreDominio tipoDeDatos

			[ DEFAULT valor por defecto ]

			[ [ CONSTRAINT nombre restriccion ] CHECK( condicion ) ]

	Ejemplo: CREATE DOMAIN TiposDoc varchar2( 5 );

	Ejemplo2: CREATE DOMAIN claves varchar2( 5 ) DEFAULT 0 CONTRAINT cClaves CHECK claves < 1000; 

		DEFAULT 0 quiere decir que por defecto tiene un 0 

		CONSTRAINT cClaves  quiere decir que el nombre de la restriccion CHECK se llama cClaves y asi podremos retocarlo mas adelante

		CHECK claves < 1000  quiere decir que comprobara que las claves siempre sean menores a 1000



ejemplo de todo lo anterior:

CREATE TABLE documentos

(  

	tipo TiposDoc,

	codDoc varchar2( 5 ),

	titulo varchar2( 50 ) NOT NULL,

	idioma Idiomas,

	codigoE Codigos,

	anyo integer( 4 ) CHECK ( anyo > 1950 ),

	isbn integer ( 10 ),

	PRIMARY KEY( tipo, CodDoc ),

	UNIQUE(isbn),

	CHECK ( ( tipo = "A" AND isbn IS NULL AND codigoE IS NULL ) OR ( TIPO = "L" AND isbn IS NOT NULL AND codigoE NOTNULL ) ),

	FOREIGN KEY ( codigoE ) REFERENCES Editorial

)

	ELIMINAR OBJETOS:

		DROP objeto nombre-objeto { CASCADE | RESTRICT }

Para borrar una base de datos se usara DROP SCHEMA nombreDeLaBaseDeDatos CASCADE O RESTRICT

Para borrar una tabla  DROP TABLE empleados CASCADE CONTRAINT;

MODIFICAR LA ESTRCTURA DE UNA TABLA --> ALTER TABLE

ALTER TABLE nombre-tabla

[ DROP ( nombre-columna ) tipoDatos | dominios[ DEFAULT ] [ restricciones columna ] [ ,nombre-columna ] ) ]

[ ADD ( nombre-columna ) tipoDatos | dominio [ DEFAULT ] [ restricciones columna ] [ , nombre-columna ] ]

[ MODIFY ( nombre-columna ) [ tipoDatos | dominio ] [ DEFAULT ] [ restricciones columna ] [ , nombre-columna ] ]

[ ADD CONSTRAINT nombre-restriccion restriccion-table ]

[ DROP CONSTRAINT nombre-restriccion ]


	CONSULTAS

SELECT nombre-columna, expresiones... ( salida de la consulta )

FROM tablas y/o vistas|consultas

		Obtener DNI, nombre y numero de telefono de todos lo empleados

		SELECT DNI, NOMBRE, TELEFONO

	FROM empleados 

	Obtener todos los datos de todos los empleados

		SELECT *

		FROM EMPLEADOS

[ WHERE condicion/es ]

	SELECT *
	
	

	hacer una copia de la tabla de empleados

		CREATE TABLE empleadosCopia AS SELECT * FROM empleados

	Obtener nombre y direccion de los empleados que trabajen en el dpto investigacion

		SELECT NOM-EMPL, EMPLEADOS.DIR

		FROM empleados dptos

		WHERE empleados.Cod-Dpto = Dptos.Cod-Dpto

				AND NOM-DPTO = "INVESTIGACION"