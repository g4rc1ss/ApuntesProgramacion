/* AUTHOR: Asier */

CREATE SCHEMA BaseDeDatos AUTHORIZATION 1234;

CREATE DOMAIN claves varchar( 5 ) DEFAULT 0 CONSTRAINT cClaves CHECK < 10000;

CREATE DOMAIN dni varchar( 9 )

CREATE TABLE Departamento (

	Clave_Departamento claves,

	Nombre_Departamento varchar( 5 ),

	DNI_Jefe_De_Dpto varchar( 9 ),

	Fecha_incorporacion DATE,

	PRIMARY KEY ( Clave_Departamento ),

	FOREIGN KEY ( DNI_Jefe_De_Dpto ) references empleados ON UPDATE NO ACTION

);

CREATE TABLE Dpto_Zona (

	Clave_Departamento claves,

	Codigo_Zona claves,

	PRIMARY KEY ( Clave_Departamento, Codigo_Zona ),

	FOREIGN KEY ( Clave_Departamento ) references Departamento ON DELETE NO ACTION ON UPDATE CASCADE, 
		--ON DELETE NO ACTION: No se puede eliminar ningun registro de la table principal si hay registros referentes en la tabla secundaria

	FOREIGN KEY ( Codigo_Zona ) references Zona ON DELETE CASCADE ON UPDATE SET DEFAULT

);

CREATE TABLE Zona (

	Codigo_Zona claves,

	Descripcion varchar( 200 ),

	PRIMARY KEY ( Codigo_Zona ),

);

CREATE TABLE Empleados (

	DNI dni,

	Nombre varchar( 20 ),

	Apellido1 varchar( 20 ),

	Apellido2 varchar( 20 ),

	Direccion varchar( 50 ),

	Telefono varchar( 9 ),

	Fecha_Nacimiento DATE,

	Fecha_incorporacion DATE,

	Clave_Departamento claves,

	Codigo_Zona claves,

	DNI_Jefe dni,

	PRIMARY KEY ( DNI ),

	FOREIGN KEY ( Codigo_Zona, Clave_Departamento ) references Dpto_Zona ON DELETE NO ACTION ON UPDATE SET NULL,

	FOREIGN KEY ( DNI_Jefe ) references Empleados ON UPDATE CASCADE ON DELETE SET DEFAULT /*Si se modifica el DNI (la clave) se modificara tambien el dato de DNI_JEFE así si se modifica 
		por algun casual el dni del jefe ya sea por equivocacion o algo tambien se modificara el dni del jefe para marcar que siempre es el mismo... Es una reflexiva */

);

CREATE TABLE Trabaja (

	DNI dni,

	Clave_Proyecto claves,

	Horas DATE,

	PRIMARY KEY ( DNI ),

	FOREIGN KEY ( Clave_Proyecto ) references Tabla_Proyecto ON DELETE NO ACTION ON UPDATE SET DEFAULT

);

CREATE TABLE Proyecto(

	Clave_Proyecto claves,

	Descripcion varchar2( 200 ),

	Fecha_Comienzo DATE,

	Presupuesto varchar2( 20 ),

	Clave_Departamento claves,

	Codigo_Zona claves,

	PRIMARY KEY ( Clave_Proyecto ),

	--FOREIGN KEY (  )

)

CREATE TABLE Familiar(

	DNI_Empleado dni,

	Nombre varchar( 20 ),

	Parentesco varchar( 50 ),

	Fecha_Nacimiento DATE,

	DNI_Familar dni,

	PRIMARY KEY ( DNI_Empleado ),

	--FOREIGN KEY (  )

)

