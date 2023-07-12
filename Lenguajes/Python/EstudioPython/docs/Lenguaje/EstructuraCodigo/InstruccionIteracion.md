Los bucles son estructuras de control que permiten ejecutar repetidamente un bloque de código mientras se cumpla una determinada condición o iterar sobre una secuencia de elementos. Los bucles más comunes en Python son el bucle `for` y el bucle `while`. A continuación, te explicaré su uso detalladamente con ejemplos.

## Bucle `for`
El bucle `for` se utiliza para iterar sobre una secuencia (como una lista, una cadena de texto, etc.) o un objeto iterable. Aquí tienes un ejemplo:

```python
frutas = ["manzana", "banana", "cereza"]

for fruta in frutas:
    print(fruta)
```

En este ejemplo, tenemos una lista de frutas. Utilizamos el bucle `for` para iterar sobre cada elemento de la lista. En cada iteración, la variable `fruta` toma el valor del siguiente elemento de la lista y se imprime en la consola. La salida sería:

```
manzana
banana
cereza
```

## Bucle `while`:
El bucle `while` se utiliza para repetir un bloque de código mientras se cumpla una condición específica. Aquí tienes un ejemplo:

```python
contador = 0

while contador < 5:
    print(contador)
    contador += 1
```

En este ejemplo, inicializamos la variable `contador` en 0. El bucle `while` se ejecuta mientras `contador` sea menor que 5. En cada iteración, se imprime el valor actual de `contador` y luego se incrementa en 1. La salida sería:

```
0
1
2
3
4
```

Es importante tener cuidado al utilizar bucles `while` para evitar caer en un bucle infinito. Es necesario asegurarse de que la condición se evalúe en algún momento como falsa.

En ambos tipos de bucles, puedes utilizar instrucciones como `break` y `continue` para controlar el flujo del bucle. `break` se utiliza para salir completamente del bucle y continuar con la ejecución del código después del bucle. `continue` se utiliza para saltar la iteración actual y pasar a la siguiente iteración.
