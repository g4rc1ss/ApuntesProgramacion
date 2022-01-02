Clave ajena, también llamada clave foránea es aquel campo o campos de una tabla que en otra tabla es llave o campo con la propiedad de único

Los valores de la clave ajena deben existir en la clave principal de la tabla correspondiente o la clave ajena también puede ser nula

Se llaman restricciones de integridad referencial a las restricciones impuestas por el usuario(cliente), estas restricciones pueden ser:

- No se puede borrar ningún departamento de la tabla departamentos si existen empleados en dicho departamento
- No se puede modificar un código departamento de a tabla departamentos si existen empleados en dicho departamento

Estas dos restricciones se llaman operaciones restringidas y en código se utilizan las constantes &quot; no action&quot; o &quot;restrict&quot;(SQL)

- Si se borra un departamento de la table departamentos, se borra toda la información de todos los empleados que pertenezcan a dicho departamento.
- Si se modifica un código departamento de la table departamentos, se modifican los códigos de departamento correspondientes en la tabla de empleados.

Estas dos restricciones se llaman operaciones en cascada y el código se utiliza &quot;cascade&quot;(SQL)

- Si se borra un departamento de la tabla departamentos, los códigos de la tabla de empleados se ponen a nulo(vacío)
- Si se modifica un código departamento de la tabla departamentos los códigos de departamento de la tabla de empleados se ponen a nulo

Estas dos restricciones se llaman operación puesta a nulo y en código se utiliza &quot;SET NULL&quot;

- Si se borra un departamento de la tabla departamentos, los códigos departamento de la tabla de empleados toman el valor por defecto
- Si se modifica el código departamento de la tabla departamentos, los códigos departamento de la tabla de empleados toman el valor por defecto

Estas dos restricciones se llaman operación puesta a valor por defecto y en código se pone &quot;SET DEFAULT&quot;

ENUNCIADO

**T.Repres**

| DNI | NOMBRE | DIRECCION | TELEFONO | MATRICULA |
| --- | --- | --- | --- | --- |
| 1 | A | D1 | T1 | 5 |
| 4 | F | D2 | T2 | 7 |
| 6 | Z | D6 | T6 | 4 |

**TALLER**

| NIF | NOMBRE | DIRECCION | TELEFONO |
| --- | --- | --- | --- |
| 1 | T1 | DT1 | 1 |
| 2 | T2 | DT2 | 9 |
| 3 | T3 | DT3 | - |
| 4 | - | - | - |

**Repres-Prod-Area**

| DNI | COD\_PROD | COD\_AREA | CANT |
| --- | --- | --- | --- |
| 1 | PR4 | A1 | 7 |
| 1 | PR4 | A2 | 7 |
| 1 | PR1 | A2 | 4 |
| 6 | PR1 | A1 | 8 |
| 6 | PR1 | A1 | 7 |

**T.COCHES**

| MATRICULA | COLOR | MARCA |
| --- | --- | --- |
| 5 | R | A |
| 7 | V | A |
| 4 | A | C |

**PRODUCTOS**

| COD-PROD | NOMBRE | P.VENTA |
| --- | --- | --- |
| PR1 | A | 1 |
| PR2 | B | 5 |
| PR3 | C | 1 |
| PR4 | D | 1 |

**T.MARCAS**

| MARCA | NIF |
| --- | --- |
| A | 1 |
| C | 2 |
| D | 1 |
| E | 4 |

**AREAS**

| COD-AREA | NOMBRE |
| --- | --- |
| A1 | NA1 |
| A2 | NA2 |
| A5 | NA5 |



1. Entre la tabla de representantes y coches se ha definido la operación de borrado y modificación en cascada
2. Entre la tabla de coches y marcas, operación de borrado restringida y la de modificación en cascada
3. Taller y marcas  borrado puesta a nulo, modificación en cascada
4. Representante y representante productos área, borrado puesta a valor por defecto y modificación restringida
5. Productos y representante productos área borrado restringida y modificación en cascada
6. Áreas y representante productos área, borrado puesta a nulo y modificación en cascada

**PREGUNTAS**

1. **I.**** ¿Cómo queda la base de datos si se da de baja el representante numero 6?**

La tabla representantes se queda con los representantes 1 y 4 y la tabla representantes productos área los dos últimos DNI se colocaría un DNI por defecto anteriormente designado.

1. **II.**** ¿Cómo queda la base de datos si se da de baja al representante nº 4?**

La tabla representantes queda con el 1 y con el 6

1. **III.**** ¿Cómo queda la base de datos si se da de baja al coche de matrícula 5?**

1. **IV.**** ¿Cómo queda la base de datos si modifico el representante 1 por el 10?**

No se puede

1. **V.**** ¿Cómo queda la base de datos si se da de baja la marca E?**

Si hubiera coches de la marca E no se podría borrar.

1. **VI.**** ¿Cómo queda la base de datos si se da de baja la marca C?**