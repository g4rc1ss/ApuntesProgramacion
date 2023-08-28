# Instalación de la biblioteca MySQL para Swift:
Para interactuar con una base de datos MySQL desde Swift, puedes utilizar la biblioteca `MySQLSwift`, que proporciona una API para trabajar con MySQL de forma nativa. Agrega `MySQLSwift` a tu proyecto a través de Swift Package Manager.

En tu `Package.swift`, agrega la dependencia de `MySQLSwift`:

```swift
dependencies: [
    .package(url: "https://github.com/IBM-Swift/Kitura-MySQL.git", from: "3.0.0")
],
```

# Configuración y conexión a la base de datos MySQL:
Para conectarte a una base de datos MySQL, debes configurar la conexión proporcionando el host, puerto, nombre de usuario, contraseña y nombre de la base de datos.

Ejemplo de configuración y conexión:

```swift
import MySQL

let host = "localhost"
let user = "tu_usuario"
let password = "tu_contraseña"
let database = "nombre_base_de_datos"

let mysql = try MySQL.Connection(host: host, user: user, password: password, database: database)
defer {
    mysql.close()
}
```

En este ejemplo, hemos configurado y establecido una conexión con MySQL en el host `localhost`, utilizando el usuario y la contraseña proporcionados, y seleccionando la base de datos específica. El uso de `defer` asegura que la conexión se cierre automáticamente al salir del ámbito.

# Operaciones con la base de datos MySQL:
Una vez que estés conectado a la base de datos MySQL, puedes realizar consultas y manipular datos utilizando SQL.

Ejemplo de consulta:

```swift
import MySQL

let query = "SELECT * FROM usuarios"

let result = try mysql.query(query)
guard let resultSet = result else {
    throw MySQLError.noResult
}

for row in resultSet {
    let id = row["id"] as! Int
    let nombre = row["nombre"] as! String
    let edad = row["edad"] as! Int
    print("ID: \(id), Nombre: \(nombre), Edad: \(edad)")
}
```

En este ejemplo, hemos realizado una consulta para seleccionar todos los registros de la tabla "usuarios". La función `query` se utiliza para enviar la consulta a MySQL y `resultSet` contiene el resultado de la consulta. Luego, hemos iterado sobre el conjunto de resultados y obtenido los valores de las columnas utilizando los nombres de las columnas como claves.

# Inserción de datos:
Ejemplo de inserción de datos:

```swift
import MySQL

let nombreNuevoUsuario = "John"
let edadNuevoUsuario = 30

let query = "INSERT INTO usuarios (nombre, edad) VALUES ('\(nombreNuevoUsuario)', \(edadNuevoUsuario))"

let result = try mysql.query(query)
print("Datos insertados exitosamente.")
```

En este ejemplo, hemos realizado una consulta para insertar un nuevo usuario en la tabla "usuarios" con el nombre "John" y la edad "30".

Es importante tener en cuenta que trabajar con bases de datos conlleva la posibilidad de errores y comportamientos inesperados. Es fundamental manejar adecuadamente errores y validar los datos ingresados para evitar problemas de seguridad y la pérdida de datos.
