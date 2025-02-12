## Declaraciones else y elif

Las declaraciones `elif` y `else` complementan la declaración `if`. 
Puede haber cero o más partes `elif`, y la parte `else` es opcional. La palabra clave 
`elif` es una abreviatura de 'else if', y es útil para evitar excesiva indentación.

<div class="hint">Una secuencia <code>if … elif … elif …</code> es un sustituto de las declaraciones <code>switch</code> o 
<code>case</code> encontradas en otros lenguajes, como Java.</div>

En la ejecución condicional, solo una de las suites es seleccionada al evaluar las expresiones una por una hasta que se encuentra 
una que sea `True`. Entonces esa suite se ejecuta y ninguna otra parte de la declaración `if` es evaluada. 
Si todas las expresiones son falsas, la suite de la cláusula `else`, si está presente, se ejecuta.


```python
a = 200
b = 33
if b > a:
  print("b es mayor que a")
elif a == b:
  print("a y b son iguales")
else:
  print("a es mayor que b")
```
```text
a es mayor que b
```

<details>

Una simple declaración if-else también puede ajustarse en una línea de código, tal como hemos mostrado en la tarea anterior. Por ejemplo,
```python
if a > b:
    a += 1
else: 
    a -= 1
```
puede ser escrita como
```python
a += 1 if a > b else a -= 1
```
</details>
  
Para obtener información más estructurada y detallada, puedes consultar [esta](https://hyperskill.org/learn/step/5932?utm_source=jba&utm_medium=jba_courses_links) y [esta](https://hyperskill.org/learn/step/5926?utm_source=jba&utm_medium=jba_courses_links) páginas de la base de conocimientos de Hyperskill.

### Tarea
Imprime `True` si `name` es igual a `"John"` y `False` en caso contrario.  

<div class='hint'>Usa la palabra clave <code>if</code> y el operador <code>==</code>.</div>
<div class='hint'>Usa la palabra clave <code>else</code>.</div>