Para conectar y consultar una base de datos MySQL en TypeScript, necesitarás utilizar un controlador o cliente MySQL compatible, como `mysql2` o `typeorm`.

**Instalación:**
Primero, instala el paquete `mysql2` utilizando npm:

```bash
npm install mysql2
```

**Conexión a la base de datos:**
Aquí tienes un ejemplo de cómo conectar a una base de datos MySQL:

```typescript
import mysql from 'mysql2';

// Configuración de la conexión
const connection = mysql.createConnection({
  host: 'localhost',
  user: 'tu_usuario',
  password: 'tu_contraseña',
  database: 'nombre_de_la_base_de_datos',
});

// Establecer la conexión
connection.connect((error) => {
  if (error) {
    console.error('Error al conectar a la base de datos:', error);
  } else {
    console.log('Conexión exitosa a la base de datos');
    // Aquí puedes realizar consultas a la base de datos
  }
});
```

En este ejemplo, utilizamos `mysql.createConnection()` para crear una instancia de conexión con los detalles de configuración, como el host, usuario, contraseña y nombre de la base de datos. Luego, llamamos a `connection.connect()` para establecer la conexión con la base de datos. Si la conexión es exitosa, mostramos un mensaje de éxito. En caso de error, mostramos un mensaje de error en la consola.

**Consulta a la base de datos:**

Una vez que hayas establecido la conexión, puedes realizar consultas a la base de datos. Aquí tienes un ejemplo de cómo ejecutar una consulta SELECT:

```typescript
// Ejemplo de consulta SELECT
connection.query('SELECT * FROM usuarios', (error, results) => {
  if (error) {
    console.error('Error al ejecutar la consulta:', error);
  } else {
    console.log('Resultados de la consulta:', results);
    // Aquí puedes trabajar con los resultados obtenidos
  }
});
```

En este ejemplo, utilizamos `connection.query()` para ejecutar una consulta SELECT en la tabla "usuarios". La función de devolución de llamada recibe dos parámetros: el error, en caso de haberlo, y los resultados de la consulta. Si se produce un error, mostramos un mensaje de error en la consola. De lo contrario, mostramos los resultados obtenidos.

Puedes realizar otro tipo de consultas, como INSERT, UPDATE o DELETE, utilizando `connection.query()` de manera similar, pasando la consulta SQL correspondiente como primer parámetro.

**Cierre de la conexión:**

Es importante cerrar la conexión a la base de datos una vez que hayas terminado de trabajar con ella. Puedes hacerlo utilizando el método `connection.end()`:

```typescript
// Cierre de la conexión
connection.end((error) => {
  if (error) {
    console.error('Error al cerrar la conexión:', error);
  } else {
    console.log('Conexión cerrada correctamente');
  }
});
```

Este ejemplo muestra cómo cerrar la conexión a la base de datos una vez que hayas finalizado todas las consultas y operaciones.