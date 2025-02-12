## Argumentos de palabras clave

Ya insinuamos que las funciones también pueden ser llamadas usando argumentos de palabras clave de la forma `kwarg=value`. Por ejemplo, la función `cat()`, que definimos para ustedes,
acepta un argumento requerido (`food`) y tres argumentos opcionales (`state`, `action`, y `breed`).
Puede ser llamada de cualquiera de las siguientes formas (puedes probar todas ellas):

```python
cat('chicken')                     # 1 argumento posicional
cat(food='chicken')                # 1 argumento de palabra clave
cat(food='fish', action='bite')    # 2 argumentos de palabras clave
cat(action='bite', food='fish')    # 2 argumentos de palabras clave
cat('beef', 'happy', 'hiss')       # 3 argumentos posicionales
cat('a hug', state='purrring')     # 1 posicional, 1 de palabra clave
```
En una llamada a una función, los argumentos de palabras clave deben seguir a los argumentos posicionales. Todos los argumentos de palabras clave pasados deben coincidir con uno de los argumentos aceptados por la función (por ejemplo, `book` no es un argumento válido para la función `cat`), y su orden no es importante. Esto también incluye argumentos no opcionales (por ejemplo, `cat(food='fish')` es válido también). Ningún argumento puede recibir un valor más de una vez.
Todas las siguientes llamadas serían inválidas:

```python
cat()                              # falta un argumento requerido
cat(food='fish', 'dead')           # argumento posicional después de un argumento de palabra clave
cat('veggies', food='nothing')     # valor duplicado para el mismo argumento
cat(actor='Johnny Depp')           # argumento de palabra clave desconocido
```

### Tarea
En el editor, completa la llamada a la función con argumentos para que imprima lo siguiente:
```text
-- Este gato no gruñiría si le dieras sopa
-- Hermoso pelaje, la Esfinge
-- ¡Todavía tiene hambre!
```

<div class="hint">Para los argumentos de palabras clave, utiliza la sintaxis como <code>state='asleep'</code>.</div>
<div class="hint">El argumento requerido <code>food</code> debe estar en la primera posición, a menos que lo proporciones como un argumento de palabra clave.</div>