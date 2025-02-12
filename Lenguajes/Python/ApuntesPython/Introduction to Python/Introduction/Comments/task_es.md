## Comentarios

Los comentarios en Python comienzan con el carácter de hash (`#`) y un solo espacio,
y se extienden hasta el final de la línea física. Puedes usar &shortcut:CommentByLineComment; para comentar
o descomentar toda la línea o un bloque de código en PyCharm.

¡Siempre debes dar prioridad a mantener los comentarios actualizados cuando el código cambie!
Los comentarios que contradicen el código son peores que la ausencia de comentarios.
Además, son innecesarios y de hecho bastante distractivos si indican lo obvio. No hagas esto:

```python
x = x + 1                 # Incremento x
```

Los comentarios deben ser frases completas. La primera palabra debe estar en mayúsculas,
a menos que sea un identificador que comience con una letra minúscula. Asegúrate de que
tus comentarios sean claros y fácilmente comprensibles para otras personas.

#### Comentarios de bloque

Los comentarios de bloque generalmente se aplican a algún (o todo) código que los sigue y
están alineados al mismo nivel que ese código.

#### Comentarios en línea

Usa los comentarios en línea con moderación. Un comentario en línea es un comentario en
la misma línea que una declaración. Los comentarios en línea deben estar separados por al menos dos espacios de la declaración.

Puedes leer más sobre cómo comentar correctamente en <a href="https://www.python.org/dev/peps/pep-0008/#comments">PEP 8 - Guía de estilo para el código Python</a>.

También puedes comentar una línea o un bloque de código si no quieres eliminarlo, pero no es necesario en este momento.

Para obtener información más estructurada y detallada, puedes referirte a [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6081?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
En el editor de código, comenta la línea con la declaración `print` que dice que no debería imprimirse.
Observa cómo el código ya no está resaltado.

<div class="hint">
  Añade un <code>#</code> y un espacio antes de esa declaración de <code>print</code>. Deja todo lo demás tal como está.
</div>