`yield` es una palabra clave utilizada en la definición de funciones generadoras. Las funciones generadoras son funciones especiales que pueden pausar su ejecución y reanudarla más tarde, devolviendo un valor en cada pausa. Esto permite crear iteradores de forma eficiente, ya que no se generan todos los elementos a la vez, sino que se generan bajo demanda. A continuación, te explico detalladamente el uso de `yield` en Python con ejemplos:

1. Uso básico de `yield`:
El uso básico de `yield` es dentro de una función generadora. En lugar de utilizar la palabra clave `return` para devolver un valor, se utiliza `yield`. Cada vez que se encuentra `yield` en la función, se pausa la ejecución y se devuelve el valor especificado. Aquí tienes un ejemplo básico:

```python
def generar_pares(n):
    for i in range(n):
        if i % 2 == 0:
            yield i

# Utilizar la función generadora
for numero in generar_pares(10):
    print(numero)
```

En este ejemplo, hemos definido una función generadora llamada `generar_pares()`. Utilizamos `yield` para devolver los números pares del rango especificado. Al utilizar un bucle `for` para iterar sobre la función generadora, cada vez que se encuentra un `yield`, se pausa la ejecución y se devuelve el valor, imprimiendo los números pares del rango del 0 al 10.

2. Generadores infinitos:
Los generadores también pueden ser utilizados para crear secuencias infinitas de valores. Esto es posible porque la función generadora se ejecuta bajo demanda, devolviendo un valor en cada pausa. Aquí tienes un ejemplo:

```python
def generar_fibonacci():
    a, b = 0, 1
    while True:
        yield a
        a, b = b, a + b

# Utilizar la función generadora
fib = generar_fibonacci()
for _ in range(10):
    print(next(fib))
```

En este ejemplo, hemos definido una función generadora llamada `generar_fibonacci()`. Utilizamos `yield` para devolver los números de la secuencia de Fibonacci. Como la función generadora se ejecuta en un bucle infinito, podemos utilizar `next()` para obtener el siguiente valor de la secuencia en cada iteración del bucle `for`. Imprimimos los primeros 10 números de la secuencia de Fibonacci.
