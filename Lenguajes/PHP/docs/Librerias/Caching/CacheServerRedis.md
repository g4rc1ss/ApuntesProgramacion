# Instalación y configuración de Redis
   Asegúrate de que la extensión Redis esté instalada y habilitada en tu servidor. También debes tener un servidor Redis en funcionamiento al que puedas conectarte.

# Almacenar y recuperar datos en caché
   Puedes utilizar la clase `Redis` para almacenar y recuperar datos en caché. Aquí tienes un ejemplo básico:

   ```php
   // Crear una instancia de Redis
   $redis = new Redis();
   
   // Conectar al servidor Redis
   $redis->connect('127.0.0.1', 6379);
   
   // Almacenar un valor en caché con una clave
   $clave = 'mi_clave';
   $valor = 'Datos que deseas almacenar en caché';
   $expiracion = 3600; // Tiempo de expiración en segundos (1 hora)
   $redis->setex($clave, $expiracion, $valor);
   
   // Recuperar un valor de caché
   $valorCachado = $redis->get($clave);
   
   if ($valorCachado !== false) {
       echo "Valor en caché: $valorCachado";
   } else {
       // Si no se encuentra en caché, realizar consulta y almacenar en caché
       $valorConsulta = realizarConsulta(); // Función hipotética para realizar una consulta
       $redis->setex($clave, $expiracion, $valorConsulta);
       echo "Valor consultado: $valorConsulta";
   }
   ```

# Expiración de caché
   Al igual que con Memcached, es importante establecer un tiempo de expiración para los datos en caché para garantizar que los datos se actualicen periódicamente.

# Eliminación y borrado de caché
   Puedes eliminar un valor en caché utilizando el método `del()` o borrar todos los valores en caché utilizando el método `flushAll()`.

   ```php
   // Eliminar un valor en caché
   $redis->del($clave);
   
   // Borrar todos los valores en caché
   $redis->flushAll();
   ```