## Diccionarios

Un diccionario es similar a una lista, excepto que accedes a sus valores buscando una 
clave en lugar de un índice. Una clave puede ser de cualquier tipo inmutable. Las cadenas y los números siempre pueden 
ser claves; las tuplas pueden ser usadas como claves si solo contienen objetos inmutables. 
No puedes usar listas como claves.

Piensa en un diccionario como un conjunto de pares <code>clave: valor</code>, con el requisito 
de que las claves sean únicas dentro de un diccionario. Los diccionarios están encerrados 
en llaves, por ejemplo, `dct = {'clave1' : "valor1", 'clave2' : "valor2"}`. Un par de 
llaves crea un diccionario vacío: `{}`.  

Un diccionario también puede ser creado con el constructor `dict`: 
```python
a = dict(uno=1, dos=2, tres=3)
b = {'uno': 1, 'dos': 2, 'tres': 3}
c = dict([('dos', 2), ('uno', 1), ('tres', 3)])
print(a == b == c)
```
```text
Verdadero
```

Puedes acceder a un valor en un diccionario de manera similar a cómo accederías a un valor en una lista,
pero utilizando una clave en lugar de un índice. Puedes encontrar más información acerca de esta estructura de datos 
<a href="https://docs.python.org/3/tutorial/datastructures.html#dictionaries">aquí</a>.

Para información más estructurada y detallada, también puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6481?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Añade el número `570` de Jared (`"Jared"`) a la agenda de teléfonos.
Elimina el número de Gerard de la agenda de teléfonos.
Imprime el número de teléfono de Jane de la `agenda_de_telefonos`.  

<div class='hint'>Utiliza indexación de diccionarios, por ejemplo, <code>dct[clave]</code></div>