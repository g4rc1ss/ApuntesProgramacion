# Instalación y Configuración
   Asegúrate de tener la extensión `mongodb` instalada y habilitada en tu servidor PHP. Puedes instalarla mediante Composer o a través de los comandos del sistema.

# Conexión a MongoDB
   Debes establecer una conexión con el servidor de MongoDB antes de realizar operaciones. Utiliza la clase `MongoDB\Client` para crear la conexión.

   ```php
   $cliente = new MongoDB\Client("mongodb://localhost:27017");
   ```

# Seleccionar una Base de Datos
   Una vez conectado, selecciona la base de datos con la que deseas trabajar.

   ```php
   $baseDatos = $cliente->selectDatabase("mi_base_de_datos");
   ```

# Crear una Colección y Documentos
   MongoDB almacena datos en colecciones que contienen documentos en formato BSON (JSON binario). Puedes insertar documentos en una colección.

   ```php
   $coleccion = $baseDatos->selectCollection("usuarios");
   
   $documento = [
       "nombre" => "Juan",
       "edad" => 30,
       "correo" => "juan@example.com"
   ];
   
   $coleccion->insertOne($documento);
   ```

# Consulta de Documentos
   Puedes realizar consultas utilizando la función `find()`.

   ```php
   $resultados = $coleccion->find(["nombre" => "Juan"]);
   foreach ($resultados as $documento) {
       echo $documento["nombre"];
   }
   ```

# Actualización de Documentos
   Utiliza la función `updateOne()` para actualizar un documento.

   ```php
   $filtro = ["nombre" => "Juan"];
   $actualizacion = ['$set' => ["edad" => 31]];
   $coleccion->updateOne($filtro, $actualizacion);
   ```

# Eliminación de Documentos
   Utiliza la función `deleteOne()` para eliminar documentos.

   ```php
   $filtro = ["nombre" => "Juan"];
   $coleccion->deleteOne($filtro);
   ```

# Índices
   Puedes crear índices para mejorar el rendimiento en consultas frecuentes.

   ```php
   $coleccion->createIndex(["nombre" => 1]);
   ```

# Cerrar la Conexión
   No olvides cerrar la conexión cuando hayas terminado.

   ```php
   unset($cliente);
   ```