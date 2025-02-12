## Longitud de la cadena

El método `len()` se utiliza para contar cuántos caracteres contiene una cadena.

Por ejemplo:
```python
s = "Hello World"
print(len(s))   # imprimirá 11
```

Ten en cuenta que el resultado de la operación de división `/` es de tipo flotante:
```python
a = 10/2
print(a)        # 5.0
print(type(a))  # <class 'float'>
```

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5814?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Obtén la primera mitad de la cadena almacenada en la variable `phrase`.  
Nota: al obtener el índice, recuerda sobre la conversión de tipo.  

<div class='hint'>Necesitas obtener una porción de la cadena desde su inicio  
hasta el punto medio.</div>

<div class='hint'>Obtén el índice medio dividiendo la longitud de la cadena por 2. El 
resultado de la división necesita ser un entero.</div>