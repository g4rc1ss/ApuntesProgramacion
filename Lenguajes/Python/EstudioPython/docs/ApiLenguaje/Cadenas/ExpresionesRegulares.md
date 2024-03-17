Las expresiones regulares son patrones de búsqueda utilizados para encontrar y manipular texto basado en reglas específicas. En Python, puedes utilizar el módulo `re` para trabajar con expresiones regulares.

## Importar el módulo `re`:
Para utilizar expresiones regulares en Python, primero debes importar el módulo `re`. Aquí tienes un ejemplo:

```python
import re
```

## Búsqueda básica de patrones:
Puedes utilizar el método `re.search()` para buscar un patrón específico dentro de una cadena. El patrón puede ser una cadena literal o una expresión regular. Aquí tienes un ejemplo:

```python
cadena = "Python es un lenguaje de programación"
patron = "Python"
resultado = re.search(patron, cadena)
if resultado:
    print("Patrón encontrado")
else:
    print("Patrón no encontrado")
```

En este ejemplo, utilizamos `re.search()` para buscar el patrón "Python" dentro de la cadena. Si el patrón se encuentra, se imprime "Patrón encontrado".

## Coincidencia de patrones:
Puedes utilizar caracteres especiales y metacaracteres en las expresiones regulares para buscar patrones más complejos. Aquí tienes algunos ejemplos:

```python
cadena = "Python es un lenguaje de programación"
patron1 = r"Py.*n"   # Coincide con cualquier cadena que comienza con "Py" y termina con "n"
patron2 = r"\b\w{4}\b"   # Coincide con palabras de exactamente 4 caracteres
patron3 = r"\d+"   # Coincide con uno o más dígitos

resultado1 = re.search(patron1, cadena)
resultado2 = re.findall(patron2, cadena)
resultado3 = re.findall(patron3, cadena)

print(resultado1.group())   # Imprime "Python"
print(resultado2)   # Imprime ["leng", "prog"]
print(resultado3)   # Imprime ["un"]
```

En este ejemplo, utilizamos diferentes patrones para buscar coincidencias en la cadena. El patrón `patron1` coincide con cualquier cadena que comienza con "Py" y termina con "n". El patrón `patron2` coincide con palabras de exactamente 4 caracteres. El patrón `patron3` coincide con uno o más dígitos. Utilizamos métodos como `group()` y `findall()` para obtener los resultados coincidentes.

4. Sustitución y manipulación de texto:
Puedes utilizar el método `re.sub()` para reemplazar partes de una cadena que coinciden con un patrón. Aquí tienes un ejemplo:

```python
cadena = "Python es un lenguaje de programación"
patron = r"\b\w{4}\b"   # Coincide con palabras de exactamente 4 caracteres
nueva_cadena = re.sub(patron, "Python", cadena)
print(nueva_cadena)   # Imprime "Python es un Python de Python"
```

En este ejemplo, utilizamos `re.sub()` para reemplazar todas las palabras de 4 caracteres con la palabra "Python".
