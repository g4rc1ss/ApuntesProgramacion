## Leer archivo

Para leer el contenido de un archivo, puedes llamar a `f.read(size)`, que lee una cantidad de datos y los devuelve como
una cadena. Cuando se omite size o es negativo, se leerá y devolverá todo el contenido del archivo.

```python
with open('algunarchivo.txt') as f:
    print(f.read())
```
```text
Aquí está todo lo que hay en el archivo.\n
```
<i>**Nota**: habrá un problema si el archivo es dos veces más grande que la memoria de su máquina.</i>


`f.readline()` lee una sola línea del archivo; un carácter de nueva línea (`\n`) se deja al final de la 
cadena y solo se omite en la última línea del archivo si el archivo no termina en una nueva línea. Si `f.readline()` 
devuelve una cadena vacía, se ha llegado al final del archivo, mientras que una línea en blanco se representa mediante `\n`, 
una cadena que solo contiene un salto de línea.

```python
f.readline()
```
```text
'Esta es la primera línea del archivo.\n'
```
```python
f.readline()
```
```text
'Segunda línea del archivo\n'
```
```python
f.readline()
```
```text
''
``` 
Para leer líneas de un archivo, puedes hacer un bucle sobre el objeto archivo. Esto es eficiente en memoria, rápido y 
hace que el código sea simple:
```python
for line in f:
    print(line)
```
```text
Esta es la primera línea del archivo.
Segunda línea del archivo
```

Si quieres leer todas las líneas de un archivo en una lista, también puedes usar `list(f)` o `f.readlines()`.

Para más detalles, consulta la sección [Métodos de objetos de archivo](https://docs.python.org/3/tutorial/inputoutput.html#methods-of-file-objects) en el Tutorial de Python.

Para información más estructurada y detallada, también puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/8139?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Imprime el contenido de "input.txt" en la salida iterando sobre las líneas del archivo e imprimiendo cada una.
Luego imprime solo la primera línea de "input1.txt".

<div class="hint">Haz un bucle sobre el objeto del archivo como en el ejemplo de la descripción de la tarea.</div>
<div class='hint'>Usa la función <code>print</code>.</div>
<div class='hint'>Usa el método <code>readline()</code> para imprimir una sola línea.</div>