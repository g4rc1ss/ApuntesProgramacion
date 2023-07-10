# TypeORM

**Instalación:**

Para empezar, debes asegurarte de tener Node.js y npm instalados en tu entorno de desarrollo. Luego, puedes instalar TypeORM y su controlador de base de datos correspondiente utilizando npm. Por ejemplo, si quieres utilizar MySQL, puedes ejecutar el siguiente comando:

```bash
npm install typeorm mysql
```

Ten en cuenta que `mysql` es el controlador de la base de datos específico para MySQL. Puedes reemplazarlo con el controlador adecuado para tu base de datos preferida, como `pg` para PostgreSQL o `sqlite3` para SQLite.

**Configuración de la conexión:**

A continuación, necesitarás configurar la conexión a tu base de datos en un archivo de configuración, como `ormconfig.json`. Aquí tienes un ejemplo de configuración para MySQL:

```json
{
  "type": "mysql",
  "host": "localhost",
  "port": 3306,
  "username": "tu_usuario",
  "password": "tu_contraseña",
  "database": "nombre_de_la_base_de_datos",
  "synchronize": true,
  "logging": true,
  "entities": [
    "src/entities/*.ts"
  ],
  "migrations": [
    "src/migrations/*.ts"
  ],
  "cli": {
    "entitiesDir": "src/entities",
    "migrationsDir": "src/migrations"
  }
}
```

Asegúrate de ajustar los valores de `host`, `port`, `username`, `password` y `database` según tu configuración específica.

**Definición de entidades:**

Luego, debes definir tus entidades, que representan las tablas en tu base de datos. Por ejemplo, si tienes una tabla "usuarios", puedes crear una entidad `Usuario` de la siguiente manera:

```typescript
import { Entity, PrimaryGeneratedColumn, Column } from 'typeorm';

@Entity()
export class Usuario {

  @PrimaryGeneratedColumn()
  id: number;

  @Column()
  nombre: string;

  @Column()
  edad: number;

  @Column()
  email: string;
}
```

En este ejemplo, utilizamos las anotaciones proporcionadas por TypeORM, como `Entity`, `PrimaryGeneratedColumn` y `Column`, para definir la entidad `Usuario` con sus respectivas columnas.

**Realizar consultas y operaciones:**

Una vez que hayas configurado la conexión y definido tus entidades, puedes realizar consultas y operaciones en la base de datos. Aquí tienes algunos ejemplos:

```typescript
import { createConnection, getRepository } from 'typeorm';
import { Usuario } from './entities/Usuario';

// Establecer la conexión
createConnection()
  .then(async (connection) => {
    const usuarioRepository = getRepository(Usuario);

    // Consulta SELECT
    const usuarios = await usuarioRepository.find();
    console.log('Usuarios:', usuarios);

    // Consulta INSERT
    const nuevoUsuario = new Usuario();
    nuevoUsuario.nombre = 'John Doe';
    nuevoUsuario.edad = 30;
    nuevoUsuario.email = 'john.doe@example.com';
    await usuarioRepository.save(nuevoUsuario);

    // Consulta UPDATE
    const usuarioActualizado = await usuarioRepository.findOne({ nombre: 'John Doe' });
    usuarioActualizado.edad = 35;
    await usuarioRepository.save(usuarioActualizado);

    // Consulta DELETE
    const usuarioEliminado = await usuarioRepository.findOne({ nombre: 'John Doe' });
    await usuarioRepository.remove(usuarioEliminado);

    // Cerrar la conexión
    await connection.close();
  })
  .catch((error) => {
    console.error('Error al establecer la conexión:', error);
  });
```

En este ejemplo, utilizamos `createConnection()` para establecer la conexión a la base de datos según la configuración proporcionada en `ormconfig.json`. Luego, utilizamos `getRepository()` para obtener el repositorio correspondiente a la entidad `Usuario`.

Realizamos consultas y operaciones en la base de datos utilizando los métodos proporcionados por el repositorio, como `find()`, `save()`, `findOne()` y `remove()`. Los resultados se manejan de forma asíncrona utilizando `async/await`.

Finalmente, cerramos la conexión utilizando `connection.close()` para liberar los recursos correctamente.

**Migraciones:**

TypeORM también proporciona soporte para migraciones de base de datos, lo que te permite modificar el esquema de la base de datos de forma controlada. Puedes generar y ejecutar migraciones utilizando el CLI de TypeORM. Por ejemplo:

```bash
typeorm migration:generate -n NombreDeLaMigracion
typeorm migration:run
```

Esto generará una nueva migración en el directorio configurado en `ormconfig.json` y luego ejecutará todas las migraciones pendientes en la base de datos.

