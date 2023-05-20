# Sistemas de persistencia

Un sistema de persistencia es un software que nos permite guardar la informacion de forma fisica en un sistema de almacenamiento, como un disco duro.

Puede ser, por ejemplo, un fichero de texto, no obstante, en una infraestructura se requiere almacenar la informacion de forma segura y rapida, puesto que necesitamos acceder, consultar y grabar los datos a velocidades muy elevadas. Para ello, lo mas utilizado son las Bases de Datos.

Dentro de las bases de datos nos encontramos con las relacionales(SQL) y las no relacionales(NoSQL)

|                  | No relacional | Relacional |
| ---------------- | ------------- | ---------- |
| LA MEJOR OPCION: | <ul><li>Administrar datos de gran volumen, no relacionados, indeterminados o que cambian rápidamente.</li><li>Datos independientes del esquema o esquema dictados por la aplicación</li><li>Aplicaciones en las que el rendimiento y la disponibilidad son más importantes que una coherencia alta.</li><li>Aplicaciones siempre activas que dan servicios a usuarios de todo el mundo.</li></ul> | <ul><li>Administrar datos relacionales con requisitos lógicos y discretos que se puedan identificar con antelación.</li><li>Administrar datos relacionales con requisitos lógicos y discretos que se puedan identificar con antelación.</li><li>Sistemas heredados creados para estructuras relacionales.</li><li>Aplicaciones que requieren transacciones de varias filas o consultas complejas.</li></ul> |
| ESCENARIOS: | <ul><li>Aplicaciones Moviles</li><li>Analisis en tiempo real</li><li>Administracion de contenido</li><li>Aplicaciones de IoT</li></ul> | <ul><li>Sistemas de contabilidad y bancarios</li><li>Sistemas de administracion</li></ul> |
| ESCALA: | <ul><li>Escala horizontalmente mediate el particionado entre servidores</li></ul> | <ul><li>Escala verticalmente al aumentar la carga del servidor</li></ul> |
| MODELO DE DATOS: | <ul><li>Tipos de base de datos: Clave-Valor, Documentos, columnas y grafos</li><li>Almacena los datos dependiendo de la base de datos que se utilice</li></ul> | <ul><li>Tipos de base de datos: Tablas de filas, agrupadas en relaciones</li><li>Lenguaje de consulta SQL</li></ul> |



## SQL

- **Sqlite**: Sistema de Base de datos embebida y ligera pensada para almacenar y consultar cantidades pequeñas de datos limitado por bajo procesamiento, como un dispositivo movil

- **MySQL**: Sistema creado para almacenar cantidades pequeñas de datos con trafico de alta concurrencia y consultas de alto rendimiento

- **Postgresql**: Software de Base de datos pensado en la gestion de grandes cantidades de datos manteniendo un alto rendimiento y ofreciendo una alta escalabilidad

- **SQL Server**: Software creado por Microsoft para la gestion de grandes cantidades de datos con alto rendimiento y escalabilidad


## NoSQL

-  **Redis**: Almacen de datos Clave-Valor en memoria, prometiendo una velocidad de respuesta inferior al milisegundo. Este software se utliza principalmente para el uso de caché distribuida en arquitecturas serverless.

- **Elastic Search**: Es un sistema orientado a documentos muy popular en Big Data con un sistema de busqueda de alto rendimiento, sus usos mas habituales son: almacenamiento de logs, Machine Learning, etc.

- **MongoDb**: Base de datos orientada a documentos especializada en almacenar volumenes masivos de datos

- **Cosmos**: Sistema de alto rendimiento orientada a documentos, es una Base de datos pensada en la alta escalabilidad y disponibilidad, permitiendo tener cluster de datos distribuidos entre multiples regiones. Una ventaja es que permite el lenguaje SQL para procesar las consultas, de modo que tiene un rango de aprendizaje muy corto.
