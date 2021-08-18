-- Ejercicio Base de datos SQL --

CREATE TABLE Departamentos (

	Cod_dpto varchar2( 5 ) PRIMARY KEY,

	Nombre_d varchar2( 50 ),

	DNI_Jefe varchar( 9 ),

	Fecha_Alta DATE,

);

CREATE TABLE Zonas (

	Cod_Zona varchar2( 5 ) PRIMARY KEY,

	Descripcion varchar2( 200 ),

);

CREATE TABLE DptosZona (

	Cod_dpto varchar2( 5 ),

	Cod_Zona varchar2( 5 ),

	PRIMARY KEY( Cod_dpto, Cod_Zona )

	FOREIGN KEY ( Cod_dpto ) REFERENCES Departamentos,

	FOREIGN KEY ( Cod_Zona ) REFERENCES Zonas ON UPDATE CASCADE

);