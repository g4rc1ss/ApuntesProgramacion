## Tuplas

Las tuplas representan otro tipo de datos de secuencia estándar.
Son casi idénticas a las listas. La única diferencia significativa entre las tuplas y
las listas es que las tuplas son inmutables: no puedes agregar, reemplazar, ni eliminar elementos en 
una tupla. Las tuplas se construyen con elementos separados por comas encerrados en paréntesis, por 
ejemplo: 

```python
(a, b, c)
```
 
Una situación especial es la construcción de tuplas que contienen 0 o 1 elementos. 
Las tuplas vacías se construyen con un par de paréntesis vacíos; 
una tupla con un solo elemento se construye siguiendo un valor con una coma. Por ejemplo:

```python
empty = ()
singleton = 'hola',    # <-- nota la coma final
len(empty)
```
```text
0
```
```python
len(singleton)
```
```text
1
```
```python
singleton
```
```text
('hola',)
```

La declaración `t = 12345, 54321, '¡hola!'` es un ejemplo de empaquetamiento de tuplas: los
valores `12345`, `54321`, y `¡hola!` se agrupan juntos en una tupla. 

Algunos otros métodos de lista también 
son aplicables a las tuplas. Puedes leer más sobre las tuplas <a href="https://docs.python.org/3/tutorial/datastructures.html#tuples-and-sequences">aquí</a>.

Para obtener información más estructurada y detallada, también puedes consultar [esta página de la base de conocimiento de Hyperskill](https://hyperskill.org/learn/step/7462?utm_source=jba&utm_medium=jba_courses_links).
  
### Tarea
Imprime la longitud de la tupla `alphabet`. Luego, crea una tupla con un solo elemento `'fun_tuple'`. 
Puedes ejecutar el código para ver lo que imprime.  

<div class='hint'>Usa la función <code>len()</code>.</div>

<div class='hint'>No olvides la coma al final en la tupla con un elemento.</div>