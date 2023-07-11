Una variable es un contenedor que almacena valores. Estos valores pueden ser de diferentes tipos, como números, cadenas de texto, listas, diccionarios, etc. Las variables permiten almacenar y manipular datos de manera dinámica en un programa.

Para utilizar una variable en Python, simplemente le das un nombre descriptivo y le asignas un valor utilizando el operador de asignación (=). Aquí tienes un ejemplo básico:

```python
nombre = "Juan"
edad = 25
```

En este ejemplo, hemos creado dos variables: `nombre` y `edad`. `nombre` es una cadena de texto que almacena el valor "Juan", mientras que `edad` es un número entero que almacena el valor 25.

Una vez que has asignado un valor a una variable, puedes utilizarla en tu código. Por ejemplo, puedes imprimir el valor de una variable en la consola utilizando la función `print()`:

```python
nombre = "Juan"
print(nombre)  # Imprime "Juan" en la consola
```

También puedes actualizar el valor de una variable en cualquier momento asignándole un nuevo valor:

```python
edad = 25
print(edad)  # Imprime 25 en la consola

edad = 26
print(edad)  # Imprime 26 en la consola
```

Las variables en Python son dinámicas, lo que significa que no tienes que declarar explícitamente su tipo. Python deduce automáticamente el tipo de una variable según el valor que le asignas. Esto permite que una variable pueda cambiar de tipo a lo largo del programa:

```python
x = 10
print(x)  # Imprime 10 en la consola

x = "Hola"
print(x)  # Imprime "Hola" en la consola
```

Además, puedes utilizar variables en expresiones matemáticas u operaciones:

```python
x = 5
y = 3

suma = x + y
resta = x - y
multiplicacion = x * y
division = x / y

print(suma)           # Imprime 8 en la consola
print(resta)          # Imprime 2 en la consola
print(multiplicacion)  # Imprime 15 en la consola
print(division)       # Imprime 1.6666666666666667 en la consola
```
