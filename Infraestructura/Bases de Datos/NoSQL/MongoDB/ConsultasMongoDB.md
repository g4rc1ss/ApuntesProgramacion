# Consultas en MongoDB

MongoDB es una base de datos NoSQL, diseñada para almacenar y gestionar grandes volúmenes de datos de forma escalable y flexible.


1. **Estructura flexible**: No requiere un esquema fijo, lo que significa que los documentos en una colección pueden tener diferentes campos y estructuras.

2. **Escalabilidad horizontal**: Permite distribuir los datos a través de múltiples servidores o clústeres para manejar grandes volúmenes de información.

3. **Alto rendimiento**: MongoDB utiliza el acceso directo a la memoria para acelerar las consultas y escrituras, lo que lo hace adecuado para aplicaciones de alta velocidad y tiempo real.

4. **Consulta avanzada**: Admite una amplia variedad de consultas, índices y operadores para realizar búsquedas, agregaciones y análisis de datos complejos.

5. **Replicación y tolerancia a fallos**: Puede replicar los datos en varios nodos para proporcionar alta disponibilidad y resistencia a fallos.

6. **Ad hoc Queries**: Permite realizar consultas ad hoc en tiempo real para obtener rápidamente la información que se necesita.

MongoDB es ampliamente utilizado en aplicaciones web, aplicaciones móviles, análisis de datos, Internet de las cosas (IoT) y otras áreas donde se requiere una base de datos escalable y flexible.


## Consultas básicas

### db.collection.find()
Recupera todos los documentos de una colección.

Ejemplo:
```javascript
db.users.find()
```

### db.collection.find({ campo: valor })
Recupera los documentos que coinciden con un criterio específico.

Ejemplo:
```javascript
db.users.find({ age: 30 })
```

### db.collection.findOne()
Recupera el primer documento que coincide con el criterio especificado.

Ejemplo:
```javascript
db.users.findOne({ name: "John" })
```

## Operadores de comparación

### $eq
Compara si el valor de un campo es igual a un valor especificado.

Ejemplo:
```javascript
db.users.find({ age: { $eq: 30 } })
```

### $gt, $gte, $lt, $lte
Realiza comparaciones de mayor que, mayor o igual que, menor que, menor o igual que, respectivamente.

Ejemplo:
```javascript
db.users.find({ age: { $gt: 30 } })
```

## Operadores lógicos

### $and
Combina múltiples condiciones con una relación lógica "y".

Ejemplo:
```javascript
db.users.find({ $and: [{ age: { $gt: 30 } }, { city: "New York" }] })
```

### $or
Combina múltiples condiciones con una relación lógica "o".

Ejemplo:
```javascript
db.users.find({ $or: [{ age: 30 }, { city: "New York" }] })
```

## Consultas avanzadas

### db.collection.aggregate()
Realiza operaciones de agregación en los datos de la colección.

Ejemplo:
```javascript
db.orders.aggregate([
  { $match: { status: "completed" } },
  { $group: { _id: "$customer", total: { $sum: "$amount" } } }
])
```

### db.collection.distinct()
Recupera valores únicos para un campo específico en una colección.

Ejemplo:
```javascript
db.users.distinct("city")
```

### db.collection.sort()
Ordena los resultados de una consulta según uno o más campos.

Ejemplo:
```javascript
db.users.find().sort({ age: 1 })
```

## Índices

### db.collection.createIndex()
Crea un índice en un campo específico para mejorar la velocidad de las consultas.

Ejemplo:
```javascript
db.users.createIndex({ age: 1 })
```

