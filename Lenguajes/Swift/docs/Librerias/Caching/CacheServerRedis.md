# Instalación de la biblioteca Redis para Swift:

Para interactuar con Redis desde Swift, puedes utilizar la biblioteca `Redbird`. Para instalarla, debes tener un servidor Redis en funcionamiento y agregar `Redbird` a tu proyecto a través de Swift Package Manager.

En tu `Package.swift`, agrega la dependencia de `Redbird`:

```swift
dependencies: [
    .package(url: "https://github.com/vapor/redbird.git", from: "2.0.0")
],
```

# Configuración y conexión a Redis:

Para conectarte a una instancia de Redis, debes configurar la conexión proporcionando la dirección IP y el puerto de tu servidor Redis.

Ejemplo de configuración y conexión:

```swift
import Redbird

let config = RedbirdConfig(address: "127.0.0.1", port: 6379)
let redis = try! Redbird(config: config)
```

En este ejemplo, hemos configurado y establecido una conexión con Redis en la dirección IP `127.0.0.1` y el puerto `6379`. Es importante tener en cuenta que el código de producción debe manejar errores y la configuración debe ser ajustada según tu entorno de Redis.

# Operaciones de Caché con Redis:

Una vez que estés conectado a Redis, puedes realizar operaciones de lectura y escritura en el caché utilizando comandos Redis.

Ejemplo de escritura en el caché:

```swift
let clave = "nombre_usuario"
let valor = "JohnDoe"

let result = try! redis.command("SET", params: [clave, valor])
```

En este ejemplo, hemos utilizado el comando `SET` para almacenar un valor en la clave `nombre_usuario`. La función `command` de `Redbird` se utiliza para enviar comandos Redis al servidor y puede arrojar errores, así que es importante manejarlos adecuadamente en un código de producción.

Ejemplo de lectura en el caché:

```swift
let clave = "nombre_usuario"

let result = try! redis.command("GET", params: [clave])
if let valor = result?.toString() {
    print("Valor obtenido desde Redis: \(valor)")
} else {
    print("La clave no existe en el caché.")
}
```

En este ejemplo, hemos utilizado el comando `GET` para obtener el valor almacenado en la clave `nombre_usuario`. Luego, hemos utilizado el método `toString()` para obtener el valor como una cadena de texto.

Es importante tener en cuenta que Redis es una base de datos en memoria y la capacidad de almacenamiento está limitada por la cantidad de RAM disponible en el servidor. Por lo tanto, debes asegurarte de utilizar la caché de manera eficiente y gestionar el tamaño y el tiempo de expiración de los datos almacenados en Redis para evitar el agotamiento de la memoria.

