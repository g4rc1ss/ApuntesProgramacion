## Parámetros por defecto

También es posible definir funciones con un número variable de argumentos. Existen
tres formas, que se pueden combinar. La forma más útil es especificar un valor por defecto
para uno o más argumentos. Esto crea una función que se puede llamar con menos
argumentos de los que se definen. Por ejemplo, observa la primera función en el editor de código.
Esta función se puede llamar de varias maneras:

- proporcionando sólo el argumento obligatorio `a`: `multiply_by(3)`

- proporcionando uno de los argumentos opcionales: `multiply_by(3, 47)`, o `multiply_by(3, c=47)`

- o incluso proporcionando todos los argumentos: `multiply_by(3, 47, 0)`

Puedes especificar qué argumento estás proporcionando en la llamada a la función, justo como hicimos en el tercer caso
con `c=47`. Si no lo especificas, los valores se asignarán según su orden.
No coloques espacios alrededor del símbolo `=` en las llamadas y definiciones de funciones.

Explora este tema más a fondo leyendo <a href="https://docs.python.org/3/tutorial/controlflow.html#default-argument-values">esta sección</a>
de la Documentación de Python.

Para obtener información más estructurada y detallada, también puedes consultar [esta página de la base de conocimiento de Hyperskill](https://hyperskill.org/learn/step/10295?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Añade parámetros a la función `hello()` y establece un valor por defecto para el parámetro `name`.  

<div class='hint'>Especifica cualquier valor por defecto para el parámetro <code>name</code>.</div>