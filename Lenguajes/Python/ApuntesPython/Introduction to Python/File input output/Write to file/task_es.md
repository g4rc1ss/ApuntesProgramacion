## Escribir en archivo

Como ya mencionamos, si usas `'w'` como el segundo argumento en `open()`, el archivo se abre solo 
para escritura. Se creará un nuevo archivo vacío. Si ya existe otro archivo con el mismo nombre, será 
borrado. Si quieres agregar algún contenido a un archivo existente, deberías usar el modificador `'a'` 
(agregar).

Otro método del objeto de archivo, `f.write(cadena)`, escribe el contenido de una <i>cadena</i> en el archivo, devolviendo 
el número de caracteres escritos.

```python
f.write('Esto es una prueba\n')
```
```text
18
```
Otros tipos de objetos en modo texto necesitan ser convertidos en una cadena primero:
```python
valor = ('la respuesta', 42)
s = str(valor)  # convierte la tupla en cadena
f.write(s)
```
```python
18
```
Dónde se insertará el texto especificado en el archivo depende del modo de archivo (`'a'` vs `'w'`).

`'a'`: el texto se insertará al final del archivo.

`'w'`: el archivo se vaciará antes de que el texto se inserte al principio.

Si quieres incluir un símbolo como un salto de línea en tu cadena (para comenzar desde una nueva línea),
agrégalo con un `+`:
```python
f.write('\n' + 'cadena,' + ' ' + 'otra cadena')
```
Esto agregará una línea nueva y escribirá `'cadena, otra cadena'`.

Para información más estructurada y detallada, puedes consultar [esta página de base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/8334?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, **agrega** una nueva línea a `output.txt` con todos los elementos de la lista `zoo` separados por `' y '`. 
Usa la sintaxis <code>' y '.join(lst)</code> para unir los elementos de la lista en la cadena requerida. Luego, 
agrega otra línea con el `número` al mismo archivo de salida.

<div class='hint'>Usa el modificador <code>'a'</code> para agregar líneas al final del archivo.</div>
<div class='hint'>Usa el método <code>write()</code>.</div>
<div class='hint'>Convierte el <code>número</code> en una cadena antes de escribir.</div>
<div class="hint">Agrega <code>\n</code> al principio de cada cadena a escribir, para que termine en una línea separada.</div>