## Ejecutando módulos como scripts

Un módulo de Python es un archivo que contiene declaraciones ejecutables así como definiciones de funciones o clases. Estas declaraciones se ejecutan la primera vez que se encuentra el nombre del módulo en una declaración `import`. El nombre del archivo es el nombre del módulo con el sufijo .py añadido. Dentro de un módulo, el nombre del módulo (como una cadena) está disponible como el valor de la variable global `__name__`.

Cuando ejecutas un módulo **directamente** (es decir, sin importarlo en otro), el código en el módulo se ejecutará, tal como si lo hubieras importado, pero con `__name__` establecido en `"__main__"`.

Puedes usar `__name__` y `__main__` de esta manera:

```python
if __name__ == "__main__":
   # Haz algo aquí
```

Las declaraciones dentro de este bloque solo se ejecutarán si el módulo se ejecuta directamente y no a través de la importación en otro módulo. Por ejemplo, consideremos dos archivos:

programa_principal:
```python
import some_module

print(f"el __name__ del programa_principal es: {__name__}")

if __name__ == "__main__":
   print("programa_principal ejecutado directamente")
else:
   print("programa_principal ejecutado cuando se importa")
```

some_module:
```python
print(f"el __name__ del some_module es: {__name__}")

if __name__ == "__main__":
   print("some_module ejecutado directamente")
else:
   print("some_module ejecutado cuando se importa")
```

Salida después de ejecutar `programa_principal`:
```text
el __name__ del some_module es: some_module
some_module ejecutado cuando se importa
el __name__ del programa_principal es: __main__
programa_principal ejecutado directamente
```

Salida después de ejecutar `some_module`:
```text
el __name__ del some_module es: __main__
some_module ejecutado directamente
```

Para obtener información más estructurada y detallada, puedes consultar [esta página de la base de conocimientos de Hyperskill](https://hyperskill.org/learn/step/6057?utm_source=jba&utm_medium=jba_courses_links).

### Tarea
<i>Los archivos en esta tarea tienen el mismo nombre que en los ejemplos anteriores, pero su código es un poco diferente.</i>

Modifica `task.py` y `some_module.py` para que cuando ejecutes `task.py`, tu salida sea la siguiente:

```text
Este es un mensaje de some_module.
Este es un mensaje de __main__.
Este es un mensaje de la función en el módulo importado.
Esto debe imprimirse SOLO cuando se llama directamente a task.py.
```