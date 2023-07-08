# Consultas en MongoDB

MongoDB es una base de datos NoSQL ampliamente utilizada que permite el almacenamiento y recuperación eficiente de datos. A continuación, se presentan algunas consultas comunes en MongoDB:

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

