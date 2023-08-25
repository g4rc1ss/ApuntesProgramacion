Los condicionales son estructuras de control que permiten tomar decisiones en función de ciertas condiciones. Los condicionales más comunes son las sentencias `if`, `elif` y `else`. Estas sentencias se utilizan para ejecutar diferentes bloques de código dependiendo de si una condición es verdadera o falsa.

```python
edad = 18

if edad >= 18:
    print("Eres mayor de edad.")
else:
    print("Eres menor de edad.")
```

En este ejemplo, la variable `edad` se establece en 18. Luego, utilizamos la sentencia `if` para evaluar si `edad` es mayor o igual a 18. Si la condición es verdadera, se ejecuta el bloque de código indentado que sigue a la sentencia `if`, en este caso, se imprime "Eres mayor de edad.". Si la condición es falsa, se ejecuta el bloque de código indentado que sigue a la sentencia `else`, y se imprime "Eres menor de edad.".

Además del `if` y el `else`, también podemos utilizar la sentencia `elif` para evaluar múltiples condiciones. Aquí tienes un ejemplo:

```python
edad = 20

if edad < 18:
    print("Eres menor de edad.")
elif edad >= 18 and edad < 21:
    print("Eres mayor de edad pero aún no puedes beber alcohol en Estados Unidos.")
else:
    print("Eres mayor de edad y puedes beber alcohol en Estados Unidos.")
```

En este ejemplo, se evalúan tres condiciones diferentes utilizando `if`, `elif` y `else`. Si `edad` es menor que 18, se imprime "Eres menor de edad.". Si no se cumple esa condición pero `edad` está entre 18 y 21 (inclusive), se imprime "Eres mayor de edad pero aún no puedes beber alcohol en Estados Unidos.". Finalmente, si ninguna de las condiciones anteriores se cumple, se ejecuta el bloque de código después de la sentencia `else` y se imprime "Eres mayor de edad y puedes beber alcohol en Estados Unidos.".
