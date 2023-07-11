Los operadores son símbolos especiales que se utilizan para realizar operaciones entre variables y valores. Existen varios tipos de operadores en Python, como operadores aritméticos, operadores de asignación, operadores de comparación y operadores lógicos.

## Operadores aritméticos:
Los operadores aritméticos se utilizan para realizar operaciones matemáticas básicas. Aquí tienes algunos ejemplos:

```python
x = 10
y = 3

suma = x + y
resta = x - y
multiplicacion = x * y
division = x / y
modulo = x % y
potencia = x ** y

print(suma)           # Imprime 13
print(resta)          # Imprime 7
print(multiplicacion)  # Imprime 30
print(division)       # Imprime 3.3333333333333335
print(modulo)         # Imprime 1
print(potencia)       # Imprime 1000
```

En este ejemplo, utilizamos diferentes operadores aritméticos como la suma (`+`), resta (`-`), multiplicación (`*`), división (`/`), módulo (`%`) y potencia (`**`).

## Operadores de asignación:
Los operadores de asignación se utilizan para asignar valores a variables. El operador de asignación más común es `=`, pero también existen operadores de asignación combinados que realizan una operación y asignan el resultado a la variable. Aquí tienes un ejemplo:

```python
x = 10
y = 5

x += y  # Equivalente a x = x + y
print(x)  # Imprime 15

x -= y  # Equivalente a x = x - y
print(x)  # Imprime 10
```

En este ejemplo, utilizamos los operadores de asignación combinados `+=` y `-=` para realizar una suma y una resta respectivamente.

## Operadores de comparación:
Los operadores de comparación se utilizan para comparar valores y devuelven un valor booleano (`True` o `False`) que indica si la comparación es verdadera o falsa. Aquí tienes algunos ejemplos:

```python
x = 5
y = 10

igual = x == y
diferente = x != y
mayor = x > y
menor = x < y
mayor_o_igual = x >= y
menor_o_igual = x <= y

print(igual)         # Imprime False
print(diferente)     # Imprime True
print(mayor)         # Imprime False
print(menor)         # Imprime True
print(mayor_o_igual) # Imprime False
print(menor_o_igual) # Imprime True
```

En este ejemplo, utilizamos operadores de comparación como igualdad (`==`), desigualdad (`!=`), mayor que (`>`), menor que (`<`), mayor o igual que (`>=`) y menor o igual que (`<=`).

## Operadores lógicos:
Los operadores lógicos se utilizan para combinar expresiones lógicas y devuelven un valor booleano. Los operadores lógicos más comunes son `and`, `or` y `not`. Aquí tienes un ejemplo:

```python
x = 5
y = 10
z = 3

resultado1 = x < y and z < y
resultado2 = x < y or z > y
resultado3 = not(x < y)

print(resultado1)  # Imprime True
print(resultado2)  # Imprime True
print(resultado3)  # Imprime False
```

En este ejemplo, utilizamos los operadores lógicos `and`, `or` y `not` para combinar expresiones lógicas. El operador `and` devuelve `True` si ambas expresiones son verdaderas, `or` devuelve `True` si al menos una de las expresiones es verdadera, y `not` invierte el valor de la expresión lógica.
