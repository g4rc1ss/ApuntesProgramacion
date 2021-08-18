
SELECT E.nombre

FROM Empleados E

WHERE 2 <= (SELECT count( * )
			
			FROM Familiar F

			WHERE E.dni = F.dni_empleado
		)

--FORMA2:

	SELECT E.nombre

	FROM Familiar F, Empleados E

	WHERE F.dni_empleado = E.dni

	GROUP BY F.dni_empleado

	HAVING count >= 2


--1-numero de empleados por departamento y salario medio del departamento

	SELECT cod_dpto, AVG(salario) "salario medio", COUNT(*)

	FROM empleados E

	GROUP BY cod_dpto

--2-De cada proyecto obtener el codigo de proyecto, el nombre y cuantos empleados trabajan en el proyecto

	SELECT T.clave_prog "proyecto", count(*) "num_empleado", decr "descripcion"

	FROM trabaja T, proyecto P

	WHERE T.clave_prog = P.clave_prog

	GROUP BY T.clave_prog, descripcion

--3-Nombre de los empleados que no tienen familiares

	SELECT E.nombre

	FROM Empleados E, Familiar F

	WHERE E.dni NOT IN F.dni_empleado 

--2ª forma

	SELECT nombre

	FROM Empleados

	WHERE =(SELECT COUNT(*)

			FROM EMPLEADOS E, Familiar F

			WHERE E.cod_empleado = F.cod_empleado

			)

--Salario maximo y minimo para cada grupo de empleados con igual numero de hijos y que al menos tengan 1
--y solo si hay 1 empleados en el grupo y el salario maximo de ese grupo excede a 1000€

SELECT num_hijos "numero de hijos", max(salario) "max Salario", min(salario) "min salario"

FROM empleados

GROUP BY num_hijos

HAVING num_hijos <>0 AND max(salario) > 1000 AND COUNT(*) > 1

--de los empleados que tienen familiares a su cargo: nombre, apellido1, apellido2, nombre_dpto y nombre_zona 

	SELECT DISTINCT E.nombre, E.apellido1, E.apellido2, D.nombre_dpto, Z.nombre_zona

	FROM Empleados E, departamento D, zona Z, Familiar F
 
	WHERE E.Dni = F.dni_familiar AND E.cod_dpto = D.cod_dpto AND E.cod_zona = Z.cod_zona

--igual que el anterior pero de los empleados que no tienen familiares a su cargo.

	

	

--datos de los empleados que no sean de la provincia de bizkaia

--empleados que ganen mas que cualquier empleado de bizkaia