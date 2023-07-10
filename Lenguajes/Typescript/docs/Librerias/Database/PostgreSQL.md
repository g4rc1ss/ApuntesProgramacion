# PostgreSQL

**Instalación:**

Primero, asegúrate de tener instalado Node.js en tu entorno de desarrollo. Luego, puedes instalar el paquete `pg` utilizando npm:

```bash
npm install pg
```

**Conexión a la base de datos:**

Aquí tienes un ejemplo de cómo conectar a una base de datos PostgreSQL:

```typescript
import { Client } from 'pg';

// Configuración de la conexión
const connectionConfig = {
  user: 'tu_usuario',
  password: 'tu_contraseña',
  host: 'localhost',
  port: 5432,
  database: 'nombre_de_la_base_de_datos',
};

// Crear una nueva instancia del cliente de PostgreSQL
const client = new Client(connectionConfig);

// Conexión a la base de datos
client.connect((error) => {
  if (error) {
    console.error('Error al conectar a la base de datos:', error.message);
  } else {
    console.log('Conexión exitosa a la base de datos');
    // Aquí puedes realizar consultas a la base de datos
  }
});
```

En este ejemplo, utilizamos `Client` de `pg` para crear una nueva instancia del cliente de PostgreSQL. Especificamos los detalles de configuración de la conexión en `connectionConfig`, como el usuario, contraseña, host, puerto y nombre de la base de datos.

Luego, llamamos a `client.connect()` para establecer la conexión con la base de datos PostgreSQL. Si la conexión es exitosa, mostramos un mensaje de éxito. En caso de error, mostramos un mensaje de error en la consola.

**Consulta a la base de datos:**

Una vez que hayas establecido la conexión, puedes realizar consultas a la base de datos. Aquí tienes un ejemplo de cómo ejecutar una consulta SELECT:

```typescript
// Ejemplo de consulta SELECT
const sql = 'SELECT * FROM usuarios';

client.query(sql, (error, result) => {
  if (error) {
    console.error('Error al ejecutar la consulta:', error.message);
  } else {
    console.log('Resultados de la consulta:', result.rows);
    // Aquí puedes trabajar con los resultados obtenidos
  }
});
```

En este ejemplo, utilizamos `client.query()` para ejecutar una consulta SELECT en la tabla "usuarios". La función de devolución de llamada recibe dos parámetros: el error, en caso de haberlo, y el resultado de la consulta. Si se produce un error, mostramos un mensaje de error en la consola. De lo contrario, mostramos las filas de resultados obtenidas accediendo a `result.rows`.

Puedes realizar otro tipo de consultas, como INSERT, UPDATE o DELETE, utilizando `client.query()` de manera similar, pasando la consulta SQL correspondiente como primer parámetro.

**Cierre de la conexión:**

Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella. Puedes hacerlo utilizando el método `client.end()`:

```typescript
// Cierre de la conexión
client.end((error) => {
  if (error) {
    console.error('Error al cerrar la conexión:', error.message);
  } else {
    console.log('Conexión cerrada correctamente');
  }
});
```
