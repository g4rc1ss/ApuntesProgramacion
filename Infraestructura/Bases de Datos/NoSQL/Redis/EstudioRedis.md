
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