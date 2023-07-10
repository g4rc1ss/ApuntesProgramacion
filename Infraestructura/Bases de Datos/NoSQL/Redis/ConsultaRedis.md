
# Comandos básicos de Redis

Redis es una base de datos en memoria muy popular que se utiliza para almacenar y manipular datos clave-valor. A continuación, se presentan algunos de los comandos básicos más utilizados en Redis:

## Almacenamiento de datos

### SET clave valor
Almacena un valor en una clave específica.

Ejemplo:
```
SET nombre "Juan"
```

### GET clave
Obtiene el valor almacenado en una clave específica.

Ejemplo:
```
GET nombre
```

### DEL clave
Elimina una clave y su valor asociado.

Ejemplo:
```
DEL nombre
```

## Listas

### LPUSH clave valor [valor ...]
Agrega uno o más valores al inicio de una lista.

Ejemplo:
```
LPUSH numeros 1 2 3
```

### RPUSH clave valor [valor ...]
Agrega uno o más valores al final de una lista.

Ejemplo:
```
RPUSH numeros 4 5 6
```

### LLEN clave
Obtiene el tamaño de una lista.

Ejemplo:
```
LLEN numeros
```

### LRANGE clave inicio fin
Obtiene una porción de una lista, especificando el índice de inicio y fin.

Ejemplo:
```
LRANGE numeros 0 3
```

## Sets

### SADD clave valor [valor ...]
Agrega uno o más valores a un conjunto.

Ejemplo:
```
SADD colores rojo azul verde
```

### SMEMBERS clave
Obtiene todos los miembros de un conjunto.

Ejemplo:
```
SMEMBERS colores
```

### SISMEMBER clave valor
Verifica si un valor es miembro de un conjunto.

Ejemplo:
```
SISMEMBER colores rojo
```

## Hashes

### HSET clave campo valor
Asigna un valor a un campo en un hash.

Ejemplo:
```
HSET usuario:1 nombre "Juan" edad 30
```

### HGET clave campo
Obtiene el valor de un campo en un hash.

Ejemplo:
```
HGET usuario:1 nombre
```

### HGETALL clave
Obtiene todos los campos y valores de un hash.

Ejemplo:
```
HGETALL usuario:1
```

### MULTI (TRANSACTIONS)

En Redis, puedes ejecutar una serie de comandos como una transacción atómica utilizando el comando `MULTI` y luego confirmar la transacción con `EXEC`. Esto asegura que todos los comandos se ejecuten en secuencia sin intervención de otros clientes entre ellos. Si algún comando falla durante la ejecución, Redis descarta todos los comandos de la transacción y no se realiza ninguna modificación en la base de datos.

```python
# Iniciar la transacción
MULTI

# Agregar comandos a la transacción
SET clave1 valor1
SET clave2 valor2
GET clave1
GET clave2

# Ejecutar la transacción
EXEC
```

En este ejemplo, los comandos `SET` y `GET` están siendo agregados a la transacción. Cuando se ejecuta el comando `EXEC`, Redis ejecuta todos los comandos de la transacción en secuencia y devuelve los resultados correspondientes.

También puedes utilizar el comando `DISCARD` para descartar una transacción en curso sin ejecutarla. Esto puede ser útil si necesitas cancelar una transacción antes de su ejecución.

Es importante tener en cuenta que Redis no admite rollback de transacciones. Una vez que se ejecuta `EXEC`, los comandos de la transacción se realizan de forma irreversible. 
