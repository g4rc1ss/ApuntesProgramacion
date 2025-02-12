## Importar módulo

A medida que tu programa se alarga, es posible que quieras dividirlo en varios archivos para facilitar su mantenimiento. También puedes querer utilizar una función útil que hayas escrito en varios programas sin copiar su definición en cada uno de ellos.

Los módulos en Python son simplemente archivos Python con la extensión `.py` que contienen definiciones y declaraciones de Python.
Los módulos se importan de otros módulos utilizando la palabra clave `import` y el nombre del archivo sin la extensión `.py`. 

Supongamos que escribiste un script llamado `my_funcs.py` con un montón de funciones (`func1`, `func2`, etc.). Ahora, si quieres usar esas funciones en otro script que está colocado en el mismo directorio, puedes hacer `import my_funcs`. Esto no importa directamente los nombres de las funciones definidas en `my_funcs`, pero utilizando el nombre del módulo, ahora puedes acceder a las funciones, por ejemplo:
```python
my_funcs.func1()
```
  
Para información más estructurada y detallada, puedes referirte también a [esta página de base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6019#module-loading?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, ya has importado el módulo `my_funcs`.
Llama a la función `hello_world` de este módulo con el argumento `"John"`.

<div class='hint'>Accede a la función desde el módulo utilizando una sintaxis tal como <code>módulo.función()</code>.</div>
<div class="hint">No olvides proporcionar un argumento a la función.</div>
