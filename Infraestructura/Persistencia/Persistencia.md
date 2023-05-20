# Sistemas de persistencia

Un sistema de persistencia es un software que nos permite guardar la informacion de forma fisica en un sistema de almacenamiento, como un disco duro.

Puede ser, por ejemplo, un fichero de texto, no obstante, en una infraestructura se requiere almacenar la informacion de forma segura y rapida, puesto que necesitamos acceder, consultar y grabar los datos a velocidades muy elevadas. Para ello, lo mas utilizado son las Bases de Datos.

Dentro de las bases de datos nos encontramos con las relacionales(SQL) y las no relacionales(NoSQL)

|                  | No relacional | Relacional |
| ---------------- | ---- | ---- |
| LA MEJOR OPCION: | <ul><li>Administrar datos de gran volumen, no relacionados, indeterminados o que cambian rápidamente.</li><li>Datos independientes del esquema o esquema dictados por la aplicación</li><li>Aplicaciones en las que el rendimiento y la disponibilidad son más importantes que una coherencia alta.</li><li>Aplicaciones siempre activas que dan servicios a usuarios de todo el mundo.</li></ul> | <ul><li>Administrar datos relacionales con requisitos lógicos y discretos que se puedan identificar con antelación.</li><li>Administrar datos relacionales con requisitos lógicos y discretos que se puedan identificar con antelación.</li><li>Sistemas heredados creados para estructuras relacionales.</li><li>Aplicaciones que requieren transacciones de varias filas o consultas complejas.</li></ul> |
| ESCENARIOS: | <ul><li>Aplicaciones Moviles</li><li>Analisis en tiempo real</li><li>Administracion de contenido</li><li>Aplicaciones de IoT</li></ul> | <ul><li>Sistemas de contabilidad y bancarios</li><li>Sistemas de administracion</li></ul> |
| ESCALA: | <ul><li>Escala horizontalmente mediate el particionado entre servidores</li></ul> | <ul><li>Escala verticalmente al aumentar la carga del servidor</li></ul> |
| MODELO DE DATOS: | <ul><li>Tipos de base de datos: Clave-Valor, Documentos, columnas y grafos</li><li>Almacena los datos dependiendo de la base de datos que se utilice</li></ul> | <ul><li>Tipos de base de datos: Tablas de filas, agrupadas en relaciones</li><li>Lenguaje de consulta SQL</li></ul> |



## SQL
- [Sqlite](./SQL/Sqlite.md)
- [MySQL o MariaDB](./SQL/MySQL.md)
- [Postgresql](./SQL/Postgresql.md)
- [Microsoft SQL Server](./SQL/SqlServer.md)


## NoSQL
- [Redis](./NoSQL/Redis.md)
- [Mongo Database](./NoSQL/MongoDB.md)
- [Elastic Search](./NoSQL/ElasticSearch.md)
- [Microsoft Cosmos Database](./NoSQL/Cosmos.md)

