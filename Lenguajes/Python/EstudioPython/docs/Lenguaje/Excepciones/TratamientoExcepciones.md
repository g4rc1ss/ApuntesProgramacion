Ls excepciones se utilizan para manejar errores y situaciones excepcionales durante la ejecución de un programa. Las excepciones permiten detectar y responder a errores de tiempo de ejecución y controlar el flujo del programa cuando ocurren esas situaciones inesperadas.

## Lanzar una excepción:
Puedes lanzar una excepción utilizando la palabra clave `raise` seguida de un objeto de excepción. Aquí tienes un ejemplo básico:

```python
def dividir(a, b):
    if b == 0:
        raise ZeroDivisionError("No se puede dividir entre cero.")
    return a / b

try:
    resultado = dividir(10, 0)
    print(resultado)
except ZeroDivisionError as error:
    print(f"Error: {error}")
```

En este ejemplo, la función `dividir()` verifica si el divisor (`b`) es cero y lanza una excepción `ZeroDivisionError` en ese caso. En el bloque `try-except`, intentamos ejecutar la división y, si ocurre una excepción `ZeroDivisionError`, capturamos la excepción y mostramos un mensaje de error personalizado.

## Capturar y manejar excepciones:
Puedes utilizar bloques `try-except` para capturar y manejar excepciones. El bloque `try` contiene el código que puede generar una excepción, y el bloque `except` define cómo manejar esa excepción. Aquí tienes un ejemplo:

```python
try:
    edad = int(input("Ingresa tu edad: "))
    if edad < 0:
        raise ValueError("La edad no puede ser negativa.")
    print(f"Tienes {edad} años.")
except ValueError as error:
    print(f"Error: {error}")
```

En este ejemplo, utilizamos `input()` para obtener la edad del usuario como una cadena de texto. Luego, convertimos esa cadena en un entero utilizando `int()`. Si el valor ingresado no puede ser convertido a un entero, se lanzará una excepción `ValueError` y la capturaremos en el bloque `except` para mostrar un mensaje de error personalizado.

## Utilizar el bloque `finally`:
Puedes utilizar el bloque `finally` junto con el bloque `try-except` para definir un código que se ejecutará sin importar si ocurre una excepción o no. El bloque `finally` se utiliza para realizar acciones de limpieza o liberación de recursos. Aquí tienes un ejemplo:

```python
try:
    archivo = open("datos.txt", "r")
    contenido = archivo.read()
    print(contenido)
except FileNotFoundError:
    print("El archivo no existe.")
finally:
    archivo.close()
```

En este ejemplo, intentamos abrir un archivo llamado "datos.txt" en modo lectura. Si el archivo no existe, se lanzará una excepción `FileNotFoundError`. Utilizamos el bloque `finally` para asegurarnos de que el archivo se cierre correctamente, independientemente de si ocurre una excepción o no.
