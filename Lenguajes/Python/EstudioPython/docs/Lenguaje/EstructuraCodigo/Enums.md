Los enumeradores (también conocidos como enumerations o enums) son objetos que representan un conjunto fijo de valores constantes. Los enumeradores proporcionan una forma de definir y trabajar con un conjunto limitado de opciones predefinidas. A partir de Python 3.4, la biblioteca estándar de Python incluye el módulo `enum` para trabajar con enumeradores de manera más conveniente

## Importar el módulo `enum`:
Primero, necesitamos importar el módulo `enum` para poder utilizar las funcionalidades relacionadas con enumeradores. Puedes hacerlo de la siguiente manera:

```python
from enum import Enum
```

## Definir un enumerador:
Para definir un enumerador, puedes crear una clase que herede de `Enum`. Dentro de esta clase, puedes definir los valores constantes utilizando nombres en mayúsculas. Aquí tienes un ejemplo:

```python
from enum import Enum

class DiaSemana(Enum):
    LUNES = 1
    MARTES = 2
    MIERCOLES = 3
    JUEVES = 4
    VIERNES = 5
    SABADO = 6
    DOMINGO = 7
```

En este ejemplo, hemos creado un enumerador llamado `DiaSemana` que representa los días de la semana. Cada día se define como una constante con un valor numérico asociado.

## Utilizar el enumerador:
Una vez que has definido el enumerador, puedes utilizar sus valores constantes en tu código. Aquí tienes algunos ejemplos:

```python
# Acceder a los valores constantes del enumerador
print(DiaSemana.LUNES)  # Imprime "DiaSemana.LUNES"
print(DiaSemana.MIERCOLES)  # Imprime "DiaSemana.MIERCOLES"

# Comparar valores del enumerador
if DiaSemana.MARTES == DiaSemana.MIERCOLES:
    print("Los martes y miércoles son iguales.")
else:
    print("Los martes y miércoles son diferentes.")  # Imprime "Los martes y miércoles son diferentes."

# Iterar sobre los valores del enumerador
for dia in DiaSemana:
    print(dia)
```

En este ejemplo, estamos accediendo a los valores constantes del enumerador utilizando la sintaxis `Enumerador.NombreValor`. También podemos comparar valores del enumerador utilizando operadores de igualdad (`==`). Además, podemos iterar sobre los valores del enumerador utilizando un bucle `for`.
