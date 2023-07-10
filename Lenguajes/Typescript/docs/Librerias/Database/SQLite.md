# SQLite

**Instalación:**

Primero, asegúrate de tener instalado Node.js en tu entorno de desarrollo. Luego, puedes instalar el paquete `sqlite3` utilizando npm:

```bash
npm install sqlite3
```

**Conexión a la base de datos:**

Aquí tienes un ejemplo de cómo conectar a una base de datos SQLite:

```typescript
import sqlite3 from 'sqlite3';

// Ruta y opciones de conexión a la base de datos
const dbPath = 'ruta/hacia/la/base/de/datos.db';
const options = {
  // Opciones adicionales (opcional)
};

// Crear una nueva instancia de base de datos
const db = new sqlite3.Database(dbPath, options, (error) => {
  if (error) {
    console.error('Error al conectar a la base de datos:', error.message);
  } else {
    console.log('Conexión exitosa a la base de datos');
    // Aquí puedes realizar consultas a la base de datos
  }
});
```

En este ejemplo, utilizamos `new sqlite3.Database()` para crear una nueva instancia de base de datos. Especificamos la ruta a la base de datos SQLite en `dbPath` y opcionalmente puedes proporcionar opciones adicionales como el modo de apertura o el tiempo de espera.

Dentro del constructor, proporcionamos una función de devolución de llamada que se ejecuta cuando se establece la conexión. Si la conexión es exitosa, mostramos un mensaje de éxito. En caso de error, mostramos un mensaje de error en la consola.

**Consulta a la base de datos:**

Una vez que hayas establecido la conexión, puedes realizar consultas a la base de datos. Aquí tienes un ejemplo de cómo ejecutar una consulta SELECT:

```typescript
// Ejemplo de consulta SELECT
const sql = 'SELECT * FROM usuarios';

db.all(sql, (error, rows) => {
  if (error) {
    console.error('Error al ejecutar la consulta:', error.message);
  } else {
    console.log('Resultados de la consulta:', rows);
    // Aquí puedes trabajar con los resultados obtenidos
  }
});
```

En este ejemplo, utilizamos `db.all()` para ejecutar una consulta SELECT en la tabla "usuarios". La función de devolución de llamada recibe dos parámetros: el error, en caso de haberlo, y las filas de resultados de la consulta. Si se produce un error, mostramos un mensaje de error en la consola. De lo contrario, mostramos las filas de resultados obtenidas.

Puedes realizar otro tipo de consultas, como INSERT, UPDATE o DELETE, utilizando `db.run()` o `db.exec()` de manera similar, pasando la consulta SQL correspondiente como primer parámetro.

**Cierre de la conexión:**

Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella. Puedes hacerlo utilizando el método `db.close()`:

```typescript
// Cierre de la conexión
db.close((error) => {
  if (error) {
    console.error('Error al cerrar la conexión:', error.message);
  } else {
    console.log('Conexión cerrada correctamente');
  }
});
```
