## Abrir archivo
Python tiene una serie de funciones incorporadas para leer y escribir información en un archivo en su computadora.

`open()` devuelve un objeto de archivo, y se usa más comúnmente con dos argumentos: `open(nombre_del_archivo, modo)`:
```python
f = open('archivo.txt', 'w')
```
El primer argumento es una cadena que contiene el nombre del archivo. El segundo argumento es otra cadena que contiene unos pocos caracteres que describen la forma en que se usará el archivo. Puede ser `'r'` si el archivo solo se leerá, `'w'` - solo para escritura (un archivo ya existente con el mismo nombre será borrado), y `'a'` abre el archivo para agregar - cualquier dato escrito en el archivo se añade al final. `'r+'` abre el archivo para lectura y escritura. El argumento del modo es opcional; se asumirá `'r'` si se omite.

Es una buena práctica usar la palabra clave `with` al tratar con objetos de archivo. La ventaja es que el archivo se cierra correctamente después de que finaliza el conjunto de código.

```python
with open('archivo.txt') as f:
    read_data = f.read()
  
# Podemos comprobar que el archivo se ha cerrado automáticamente.
f.closed
```
```text
Verdadero
```
**Importante**: Si no estás usando la palabra clave `with`, entonces deberías llamar a `f.close()` para cerrar el archivo y liberar cualquier recurso del sistema utilizado por él. No puedes usar el objeto de archivo después de que se cierra, ya sea mediante una declaración `with` o llamando a `f.close()`.

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/8691?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
- En el editor de código, abre el archivo `input1.txt` en modo de lectura, utilizando correctamente la declaración `with`. El archivo `input1.txt` guarda el nombre del archivo donde se debe mostrar la cadena `Hola Mundo`. Leer este nombre ya está implementado en la variable `nombre_del_archivo_salida`.
- Abra el archivo con el nombre `nombre_del_archivo_salida` en modo de escritura.
- Después, cierra el archivo de salida que se abrió.

Después de ejecutar tu código, revisa el archivo de salida que apareció en la vista del curso entre los otros archivos.

<div class="hint">Proporcione el argumento <code>r</code> al método <code>open()</code>,
¡solo para practicar!</div>