# Instalación y habilitación de cURL
   Asegúrate de que la extensión cURL esté habilitada en tu instalación de PHP. Si no lo está, puedes habilitarla en el archivo `php.ini`.

# Realizar una petición GET
   Puedes realizar una petición GET utilizando la función `curl_init()` para inicializar una sesión cURL, `curl_setopt()` para establecer opciones de configuración y `curl_exec()` para ejecutar la petición.

   ```php
   $url = "https://api.example.com/data";
   $ch = curl_init($url);

   curl_setopt($ch, CURLOPT_RETURNTRANSFER, true); // Retorna el resultado en lugar de imprimirlo
   $response = curl_exec($ch);

   curl_close($ch);

   echo $response;
   ```

# Realizar una petición POST
   Para realizar una petición POST, configura cURL para enviar datos a través del método POST.

   ```php
   $url = "https://api.example.com/submit";
   $data = ["nombre" => "Juan", "edad" => 30];

   $ch = curl_init($url);

   curl_setopt($ch, CURLOPT_POST, 1);
   curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($data));
   curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

   $response = curl_exec($ch);

   curl_close($ch);

   echo $response;
   ```

# Manejo de encabezados y opciones avanzadas
   Puedes configurar encabezados personalizados y opciones adicionales, como tiempos de espera y certificados SSL.

   ```php
   $url = "https://api.example.com/data";
   $ch = curl_init($url);

   $headers = [
       "Authorization: Bearer YOUR_ACCESS_TOKEN",
       "Content-Type: application/json"
   ];

   curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
   curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);

   $response = curl_exec($ch);

   curl_close($ch);

   echo $response;
   ```

# Manejo de errores
   Es importante verificar si la petición cURL fue exitosa y manejar los errores adecuadamente.

   ```php
   $ch = curl_init($url);

   // Configurar opciones...

   $response = curl_exec($ch);

   if ($response === false) {
       echo "Error cURL: " . curl_error($ch);
   }

   curl_close($ch);
   ```
