/* Eliminar la tabla familiares

		DROP TABLE Familiares CASCADE CONSTRAINTS( ORACLE )

Añadir a la tabla de empleados los campos sueldos y numero de hijos 

		ALTER TABLE empleados ADD sueldo number( 6,2 , NHijos number( 2 )

Eliminar el campo presupesto de la tabla proyectos

No se deben permitir sueldos menores de 1.000€ 

		ALTER TABLE empleados ADD CONSTRAINT cSueldo check( sueldo > 1000 )

		ALTER TABLE empleados MODIFY (sueldo) check (sueldo > 1000)

El campo nombre de la tabla de empleados tiene un varchar2 de (20), se quiere modificar a un varchar2 de (50)

		ALTER TABLE empleados MODIFY(  )

Eliminar el valor por defecto del campo provincia de la table empleados.

		ALTER TABLE empleados MODIFY provincia default null

La tabla departamentos contiene el campo nombre-departamentos, hay que añadir que este nombre sea unico
	
		ALTER TABLE 
