# FUNCIONES

**Funciones de valores simples:**

- `ABS(n)`= Devuelve el valor absoluto de (n).
- `CEIL(n)`=Obtiene el valor entero inmediatamente superior o igual a &quot;n&quot;.
- `FLOOR(n)` = Devuelve el valor entero inmediatamente inferior o igual a &quot;n&quot;.
- `MOD (m, n)`= Devuelve el resto resultante de dividir &quot;m&quot; entre &quot;n&quot;.
- `NVL (valor, expresión)`= Sustituye un valor nulo por otro valor.
- `POWER (m, exponente)`= Calcula la potencia de un numero.
- `ROUND (numero [, m])`= Redondea números con el numero de dígitos de precisión indicados.
- `SIGN (valor)`= Indica el signo del &quot;valor&quot;.
- `SQRT(n)`= Devuelve la raíz cuadrada de &quot;n&quot;.
- `TRUNC` (numero, [m])= Trunca números para que tengan una cierta cantidad de dígitos de precisión.

**Funciones de grupos de valores:**

- `AVG(n)`= Calcula el valor medio de &quot;n&quot; ignorando los valores nulos.
- `COUNT (\* | Expresión)`= Cuenta el numero de veces que la expresión evalúa algún dato con valor no nulo. La opción &quot;\*&quot; cuenta todas las filas seleccionadas.
- `MAX (expresión)`= Calcula el máximo.
- `MIN (expresión)`= Calcula el mínimo.
- `SUM (expresión)`= Obtiene la suma de los valores de la expresión.
- `GREATEST (valor1, valor2)`= Obtiene el mayor valor de la lista.
- `LEAST (valor1, valor2)`= Obtiene el menor valor de la lista.

**Funciones que devuelven valores de caracteres:**

- `CHR(n)` = Devuelve el carácter cuyo valor en binario es equivalente a &quot;n&quot;.
- `CONCAT (cad1, cad2)`= Devuelve &quot;cad1&quot; concatenada con &quot;cad2&quot;.
- `LOWER (cad)`= Devuelve la cadena &quot;cad&quot; en minúsculas.
- `UPPER (cad)`= Devuelve la cadena &quot;cad&quot; en mayúsculas.
- `INITCAP (cad)`= Convierte la cadena &quot;cad&quot; a tipo titulo.

- `LPAD (cad1, n[,cad2])`= Añade caracteres(cad2) a la izquierda de la cadena(cad1) hasta que alcanzar la longitud n. Si se suprime cad2 se rellena a blancos.
- `RPAD (cad1, n[,cad2])`= Añade caracteres a la derecha de la cadena hasta que alcanzar la longitud n. Si se suprime cad2 rellena a blancos.
- `LTRIM (cad [,set])`= Suprime un conjunto de caracteres a la izquierda de la cadena.
- `RTRIM (cad [,set])`= Suprime un conjunto de caracteres a la derecha de la cadena.
- `REPLACE (cad, cadena\_busqueda [, cadena\_sustitucion])`= Sustituye un carácter o caracteres de una cadena con 0 o mas caracteres.
- `SUBSTR (cad, m [,n])`= Obtiene parte de una cadena. Devuelve la subcadena &quot;cad&quot; desde la posicion &quot;m&quot; tantos caracteres como indique &quot;n&quot;.

El valor de &quot;m &quot; puede ser negativo; en este caso devuelve la cadena empezando por su final.

- `TRANSLATE (cad1, cad2, cad3)`= Convierte caracteres de una cadena(cad1) en caracteres diferentes, sustituyendo los caracteres &quot;cad2&quot; por &quot;cad3&quot;.
**Funciones que devuelven valores numéricos:**

- `ASCII(cad)`= Devuelve el valor ASCII de la primera letra de la cadena &quot;cad&quot;.
- `INSTR (cad1, cad2 [, comienzo [,m]])`= Permite una búsqueda de un conjunto de caracteres en una cadena .Devuelve la posición de la &quot;m-esima&quot; ocurrencia de &quot;cad2&quot; en  &quot;cad1&quot;, empezando la búsqueda en la posición &quot;comienzo&quot;. Por omisión, empieza buscando en la posición 1.

- `LENGTH (cad)`= Devuelve el numero de caracteres de cad.

**Funciones para el manejo de fechas:**

- `SYSDATE`= Devuelve la fecha del sistema.
- `ADD\_MONTHS (fecha, [+|-]n)`= Devuelve la fecha &quot;fecha&quot; incrementada 0 decrementada en &quot;n&quot; meses.
- `LAST\_DAY (fecha)`= Devuelve la fecha del último día del mes que contiene &quot;fecha&quot;.
- `MONTHS\_BETWEEN (fecha1, fecha2)`= Devuelve la diferencia en meses entre las fechas &quot;fecha1&quot; y &quot;fecha2&quot;.
- `NEXT\_DAY (fecha, cad)`= Devuelve la fecha del primer día de la semana indicado por &quot;cad&quot; después de la fecha indicada por &quot;fecha&quot;.

**Funciones de conversión:**

- `TO\_CHAR(fecha, &#39;formato&#39;)`= Transforma un tipo DATE  u una cadena de caracteres.

El formato es una cadena de caracteres que puede incluir las máscaras de formato definidas en la tabla siguiente, y donde es también es posible utilizar literales definidos por el programador encerrados entre comillas dobles.

| **Format-picture** | **Descripción** |
| --- | --- |
| YYYY | Año 4  dígitos |
| YYY | últimos 3 dígitos del año |
| YY | últimos 2 dígitos del año |
| Y | último dígito del año |
| year | Año en letra en inglés |
| MONTH | nombre completo del mes(9-letras) - todos los caracteres en mayúsculas |
| Month | nombre completo del mes(9-letras) - el primer carácter en mayúsculas |
| month | nombre completo del mes(9-letras) - todos los caracteres en minúsculas |
| MON | nombre abreviado del mes(3-letras) -todos los caracteres en mayúsculas |
| Mon | nombre abreviado del mes(3-letras) - el primer carácter en mayúsculas |
| mon | nombre abreviado del mes(3-letras) - todos los caracteres en minúsculas |
| MM | mes (01-12) |
| DAY | nombre completo del día(9-letters) - todos los caracteres en mayúsculas |
| Day | nombre completo del día(9-letters) - el primer carácter en mayúsculas |
| day | nombre completo del día(9-letters) - todos los caracteres en minúsculas |
| DY | nombre abreviado del día(3-letters) - todos los caracteres en mayúsculas |
| Dy | nombre abreviado del día(3-letters) - el primer carácter en mayúsculas |
| dy | nombre abreviado del día(3-letters) - todos los caracteres en minúsculas |
| DDD | día del año(001-366) |
| DD | día del mes(01-31) |
| D | día de la semana(1-7; SUN=1) |
| W | semana del mes |
| WW | número de la semana en el año |
| Q | Número del trimestre |

`TO\_CHAR(numero, &#39;formato&#39;)`= Transforma un tipo &quot;número&quot;a  una cadena de caracteres el el &quot;formato&quot; especificado.

| **ormat-picture** | **Descripción** |
| --- | --- |
| 9 | devuelve tantos dígitos como 9s especificados.Los ceros de la izq. los sustituye por blancos, excepto si es sólo 1 número en este caso si pone el 0(logicamente) |
| 0 | como 9, pero en lugar de espacios en blanco usa ceros |
| . (period) | punto decimal |
| , (comma) | separador de grupo (miles) |
| PR | retorna el valor negativo en angle brackets (entre \&lt; y \&gt;) |
| S | retorna el valor negativo con el signo menos (usa locales) |
| L | símbolo monetario (usa locales) |
| D | punto decimal (usa locales) |
| G | separador de grupos (usa locales) |
| EEEE | Devuelve el valor usanso notación científica |

`TO\_DATE(cad[,&#39;formato&#39;])`= Transforma una cadena de caracteres a un tipo DATE.
`TO\_NUMBER (cad[,formato&#39;]`= Transforma una cadena de caracteres en NUMBER.