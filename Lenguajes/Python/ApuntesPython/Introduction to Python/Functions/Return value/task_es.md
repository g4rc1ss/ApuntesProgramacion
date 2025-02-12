## Valor devuelto

Las funciones pueden devolver un valor al llamador, utilizando la palabra clave `return`. Puedes usar el 
valor devuelto para asignarlo a una variable o simplemente imprimirlo. De hecho, incluso las funciones 
sin una declaración `return` devuelven un valor. Este valor se 
llama `None` (es un nombre incorporado). Escribir el valor `None` normalmente es suprimido por 
el intérprete, pero si realmente quieres verlo, puedes usar `print(some_func())`.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5900#execution-and-return?utm_source=jba&utm_medium=jba_courses_links).

><i>La primera declaración del cuerpo de la función puede ser opcionalmente una cadena literal; esta cadena 
literal es la cadena de documentación de la función, o docstring (se puede encontrar más información sobre docstrings 
en la sección <a href="https://docs.python.org/3/tutorial/controlflow.html#tut-docstrings">Cadenas de Documentación</a>
en la Documentación de Python). Es una buena práctica incluir docstrings en el código que escribes.</i>
  
En la [secuencia de Fibonacci](https://es.wikipedia.org/wiki/Sucesi%C3%B3n_de_Fibonacci), los dos primeros números son `1` y `1` (a veces, sin embargo, son `0` y `1` o `1` y `2`), y cada número subsiguiente 
es la suma de los dos anteriores. 

### Tarea
Escribe una función que devuelva una lista de números 
de la secuencia de Fibonacci hasta `n`.  

<div class='hint'>Inicializa <code>b</code> con 1.</div>
<div class='hint'>Actualiza <code>b</code> con <code>a + b</code>.</div>
<div class='hint'>Actualiza <code>a</code> con <code>tmp_var</code>.</div>