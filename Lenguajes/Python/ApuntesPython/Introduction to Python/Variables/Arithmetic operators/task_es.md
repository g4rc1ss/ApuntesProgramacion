## Operadores aritméticos

Al igual que en cualquier otro lenguaje de programación, se pueden utilizar los operadores de suma (`+`), resta (`-`), multiplicación (`*`) y división (`/`) con números. Además, Python tiene los operadores de potencia (`**`), módulo (`%`), y división entera (`//`).

- El operador `*` (multiplicación) produce el producto de sus argumentos. Los argumentos deben ser ambos números, o un argumento debe ser un entero y el otro – una secuencia.
  
- Los operadores `/` (división) y `//` (división entera) devuelven el cociente de sus argumentos. La división de enteros produce un flotante, mientras que la división entera de enteros resulta en un entero.
  
- El operador `%` (módulo) devuelve el resto de la división del primer argumento por el segundo.

- El operador `+` (suma) produce la suma de sus argumentos. Los argumentos deben ser ambos números o ambos secuencias del mismo tipo.
  
- El operador `-` (resta) produce la diferencia de sus argumentos.

Por ejemplo
```python
a = 16
b = 3
resultado = a // b  # el resultado será 5
resultado = a % b   # el resultado será 1
resultado = a ** 2  # el resultado será 256 (16 elevado a 2)
```

Las operaciones aritméticas binarias tienen los niveles de prioridad convencionales. Note que algunas de estas operaciones también se aplican a ciertos tipos no numéricos.

Puedes leer más sobre este tema <a href="https://docs.python.org/3/reference/expressions.html#binary-arithmetic-operations">aquí</a>.

Para obtener información más estructurada y detallada, también puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5865?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
 - Divide el valor almacenado en `init_number` por `2`.
 - Calcula el resto de tal división.
 - Multiplica el `division_result` por `2`.
 - Agrega el `division_remainder` al `multiplication_result`.
 - Resta el `multiplication_result` del `init_number`.
 - Realiza una división entera del `init_number` por 2.
 - Eleva el `multiplication_result` a la potencia de 3.

<div class='hint'>Primero, utiliza el operador <code>/</code>.</div>
<div class='hint'>Luego, utiliza el operador <code>%</code>.</div>

<div class='hint'>Después, utiliza el operador <code>*</code>.</div>

<div class='hint'>Después, utiliza el operador <code>+</code>.</div>

<div class='hint'>Después, utiliza el operador <code>-</code>.</div>

<div class='hint'>Luego, utiliza el operador <code>//</code>.</div>

<div class='hint'>Finalmente, usa el operador <code>**</code>.</div>
