Nos ubicamos en la carpeta del api desde la terminal y ejecutamos `npm start`

El `index.js` es el archivo principal de la aplicación

Explicacion Index:

- `cors`: es una libreria que se usa para evitar el sistema de seguridad que bloquea poder pedir consultas al api desde una direccion de localhost, cuando intentamos por react solicitar algo, da error por ello.
```javascript
//Creamos constantes para poder usar la libreria de expressjs, mongodb y cors
const express = require("express");
const mongodb = require("mongodb");
const cors  = require('cors')
const app = express();

// Escuchamos en el puerto 55434
app.listen(55434);
// indicamos a express que las solicitudes van a venir el formato json
app.use(express.json())
app.use(cors())
```


Hacemos la peticion GET
Una peticion GET se usa para solicitar datos(obtener) y estas peticiones se realizar con el formato de `QueryString`
- `QueryString`: `http://localhost:55434/listaUsuarios?DNI=${dni}` en la peticion, aparte de la url se indican los parametros de la siguiente forma: `?DNI=${dni}`

```javascript
app.get('/listaUsuarios', (request, response) => {
    // recogemos el parametro DNI, que es el parametro que esperamos recibir
    let dniUsuario = request.query.DNI;

    // Creamos el objeto con el que vamos a filtrar los datos en mongoDB
    let datoBusqueda = {}
    // Comprobamos que el DNI del usuairo no este vacio
    if (dniUsuario != undefined) {
        // Si no esta vacio, lo agregamos
        datoBusqueda["DNI"] = dniUsuario;
    }

    let db = app.locals.db;
    // Consultamos a la base de datos de la coleccion Persona que busque el dni
    db.collection('Persona').find(datoBusqueda).toArray(function (error, datos) {
        if (error != undefined) {
            console.log(error);
            response.send({ mensaje: "Error: " + error });
        } else {
            console.log(datos);
            response.send(datos)
        }
    })
});
```

```javascript
// conexion Base de Datos
let MongoClient = mongodb.MongoClient;

// Conectamos a la base de datos de MongoDB
MongoClient.connect(
    // Insertamos la cadena de conexion, que es la url de acceso a la base de datos
    "mongodb://localhost:27017/",
    function (err, client) {
        if (err !== undefined) {
            console.log("hey", err);
        } else {
            // Guardamos la conexion con la base de datos para poderla usar en el resto del codigo
            app.locals.db = client.db("Proyecto3");
        }
    }
);
```

```javascript

```

```javascript

```

```javascript

```

```javascript

```