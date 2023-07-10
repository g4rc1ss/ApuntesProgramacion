# LiteDB

**Instalación:**

Primero, asegúrate de tener Node.js y npm instalados en tu entorno de desarrollo. Luego, puedes instalar el paquete "litedb" utilizando npm:

```bash
npm install litedb
```

**Conexión a la base de datos:**

A continuación, te mostraré cómo crear una conexión a una base de datos LiteDB en TypeScript:

```typescript
import { LiteDB } from 'litedb';

// Ruta a la base de datos
const dbPath = 'ruta/a/la/base/de/datos.db';

// Crear una nueva instancia de LiteDB
const db = new LiteDB(dbPath);
```

En este ejemplo, importamos la clase `LiteDB` del paquete "litedb" y creamos una nueva instancia de LiteDB, especificando la ruta a la base de datos LiteDB en `dbPath`.

**Operaciones en la base de datos:**

A continuación, te mostraré algunos ejemplos de operaciones básicas en la base de datos LiteDB utilizando el objeto `db`:

```typescript
// Obtener una colección
const collection = db.getCollection('usuarios');

// Insertar un documento
const nuevoUsuario = {
  nombre: 'John Doe',
  edad: 30,
  email: 'john.doe@example.com',
};

collection.insert(nuevoUsuario);

// Obtener todos los documentos de la colección
const usuarios = collection.find();

usuarios.forEach((usuario) => {
  console.log(usuario.nombre);
});

// Actualizar un documento
const documentoActualizado = {
  $set: {
    edad: 35,
  },
};

collection.update({ nombre: 'John Doe' }, documentoActualizado);

// Eliminar un documento
collection.remove({ nombre: 'John Doe' });
```

En este ejemplo, creamos una instancia de la colección "usuarios" utilizando `db.getCollection()`. Luego, realizamos operaciones como `insert()`, `find()`, `update()` y `remove()` en la colección para insertar, consultar, actualizar y eliminar documentos.

**Cierre de la conexión:**

Por último, cuando hayas finalizado todas las operaciones en la base de datos, puedes cerrar la conexión utilizando el método `close()`:

```typescript
db.close();
```
