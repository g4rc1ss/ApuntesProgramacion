# MongoDB

**Instalación:**

Primero, asegúrate de tener instalado Node.js en tu entorno de desarrollo. Luego, puedes instalar el paquete `mongodb` utilizando npm:

```bash
npm install mongodb
```

**Conexión a la base de datos:**

Aquí tienes un ejemplo de cómo conectar a una base de datos MongoDB:

```typescript
import { MongoClient, Db } from 'mongodb';

// Configuración de la conexión
const url = 'mongodb://localhost:27017';
const dbName = 'nombre_de_la_base_de_datos';

// Crear una nueva instancia del cliente de MongoDB
const client = new MongoClient(url, { useNewUrlParser: true, useUnifiedTopology: true });

// Conexión a la base de datos
client.connect((error) => {
  if (error) {
    console.error('Error al conectar a la base de datos:', error.message);
  } else {
    const db: Db = client.db(dbName);
    console.log('Conexión exitosa a la base de datos');
    // Aquí puedes realizar consultas a la base de datos
  }
});
```

En este ejemplo, utilizamos `MongoClient` de `mongodb` para crear una nueva instancia del cliente de MongoDB. Especificamos la URL de conexión en `url` y el nombre de la base de datos en `dbName`.

Luego, llamamos a `client.connect()` para establecer la conexión con la base de datos MongoDB. Si la conexión es exitosa, mostramos un mensaje de éxito y asignamos la base de datos a la variable `db` para su uso posterior.

**Consulta a la base de datos:**

Una vez que hayas establecido la conexión, puedes realizar consultas a la base de datos. Aquí tienes un ejemplo de cómo ejecutar una consulta:

```typescript
// Ejemplo de consulta
const collection = db.collection('usuarios');

collection.find().toArray((error, documents) => {
  if (error) {
    console.error('Error al ejecutar la consulta:', error.message);
  } else {
    console.log('Resultados de la consulta:', documents);
    // Aquí puedes trabajar con los resultados obtenidos
  }
});
```

En este ejemplo, utilizamos `db.collection()` para obtener una referencia a la colección "usuarios". Luego, utilizamos `collection.find()` para buscar todos los documentos en la colección y `toArray()` para obtener los resultados como un arreglo.

La función de devolución de llamada recibe dos parámetros: el error, en caso de haberlo, y los documentos resultantes de la consulta. Si se produce un error, mostramos un mensaje de error en la consola. De lo contrario, mostramos los documentos obtenidos.

Puedes realizar consultas más complejas utilizando métodos como `findOne()`, `insertOne()`, `updateOne()`, `deleteOne()`, entre otros, según tus necesidades.

**Cierre de la conexión:**

Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella. Puedes hacerlo utilizando el método `client.close()`:

```typescript
// Cierre de la conexión
client.close((error) => {
  if (error) {
    console.error('Error al cerrar la conexión:', error.message);
  } else {
    console.log('Conexión cerrada correctamente');
  }
});
```
