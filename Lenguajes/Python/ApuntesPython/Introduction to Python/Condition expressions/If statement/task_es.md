## Sentencia if

Las sentencias compuestas en Python contienen (grupos de) otras sentencias; afectan o controlan 
la ejecución de esas otras sentencias de alguna manera.

Quizás el tipo de sentencia más conocido es la sentencia `if`. La palabra clave `if` se 
utiliza para formar una sentencia condicional que ejecuta algún 
código especificado después de verificar si su expresión es `True`. Python utiliza la indentación 
para definir bloques de código: 

```python
if value > 1000: 
    print("¡Es un número grande!")  # Bloque indentado
    a += 1                         # Bloque indentado
    
print("¡Fuera del bloque!")        
```

Un bloque de código comienza con indentación y termina con la primera línea sin indentar. La cantidad de indentación debe 
ser consistente en todo el bloque. Generalmente, se utilizan cuatro espacios en blanco o pestañas individuales para la indentación.
Una indentación incorrecta resultará en un `IndentationError`.

Si sólo tienes una sentencia para ejecutar, puedes ponerla en la misma línea que la sentencia `if`.

```python
if a > b: print("a es mayor que b")
```

Para obtener información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/5953?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
Escriba `"¡No es una lista vacía!"` si la lista `tasks` no está vacía.
Después de que la lista se haya vaciado, compruébalo de nuevo (¡puedes necesitar una condición diferente!) e imprime `'¡Ahora vacía!'` si lo está.

<div class='hint'>Usa la función <code>len()</code> para comprobar si <code>tasks</code> está vacía.</div>