const express = require("express");
const mongodb = require("mongodb");
const cors  = require('cors')
const app = express();
app.listen(55434);
app.use(express.json())
app.use(cors())


app.get('/listaUsuarios', (request, response) => {
    let dniUsuario = request.query.DNI;
    let idUsuario = request.query.id;

    let datoBusqueda = {}
    if (dniUsuario != undefined) {
        datoBusqueda["DNI"] = dniUsuario;
    }
    if (idUsuario != undefined) {
        datoBusqueda["_id"] = mongodb.ObjectId(idUsuario);
    }

    let db = app.locals.db;
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

app.post('/crearUsuario', (request, response) => {
    let nombreUsuario = request.body.Nombre;
    let apellidoUsuario = request.body.Apellido;
    let dniUsuario = request.body.DNI;

    let nuevoUsuario = {
        Nombre: nombreUsuario,
        Apellido: apellidoUsuario,
        DNI: dniUsuario,
        FechaUltimaEntrada: new Date(),
        FechaUltimaSalida: new Date(),
        EstaEnOficina: false
    }

    const db = app.locals.db;
    db.collection('Persona').insertOne(nuevoUsuario, function (err, InsertDatos) {
        if (err != undefined) {
            console.log(err);
            response.send({ mensaje: "Error: " + err });
        } else {
            console.log(InsertDatos);
            response.send(InsertDatos)
        }
    });
});

app.put('/actualizarUsuario', (request, response) => {
    let idUsuario = request.body.Id;
    let nombreUsuarioPut = request.body.Nombre;
    let apellidoUsuarioPut = request.body.Apellido;
    let DNIPut = request.body.DNI;
    let estaEnOficina = request.body.estaEnOficina;

    if (idUsuario == undefined) {
        response.send("No hay id de usuario")
    }

    let datosUpdate = {}
    if (nombreUsuarioPut != undefined) {
        datosUpdate["Nombre"] = nombreUsuarioPut;
    }

    if (apellidoUsuarioPut != undefined) {
        datosUpdate["Apellido"] = apellidoUsuarioPut;
    }

    if (DNIPut != undefined) {
        datosUpdate["DNI"] = DNIPut;
    }
    if (estaEnOficina != undefined) {
        datosUpdate["EstaEnOficina"] = estaEnOficina;
        if (estaEnOficina) {
            datosUpdate["FechaUltimaEntrada"] = new Date();
        } else{
            datosUpdate["FechaUltimaSalida"] = new Date();
        }
    }

    let db = request.app.locals.db;
    db.collection('Persona').updateOne({ _id: mongodb.ObjectId(idUsuario) }, { $set: datosUpdate }, function (err, datos) {
        if (err != undefined) {
            console.log(err);
            response.send({ mensaje: "Error: " + err });
        } else {
            console.log(datos);
            response.send(datos);
        }
    })
});

app.delete('/borrarUsuario', (request, response) => {
    let idUsuario = request.body.Id;

    let db = request.app.locals.db;
    db.collection('Persona').deleteOne({ _id: mongodb.ObjectId(idUsuario) }, function (err, datos) {
        if (err != undefined) {
            console.log(err);
            response.send({ mensaje: "Error: " + err });
        } else {
            console.log(datos);
            response.send(datos);
        }
    })
});


// conexion Base de Datos
let MongoClient = mongodb.MongoClient;
MongoClient.connect(
    "mongodb+srv://agarciab:Bilbo2018!@pruebarapida.ym6bw.mongodb.net/Proyecto3?retryWrites=true&w=majority",
    //"mongodb://localhost:27017/",
    function (err, client) {
        if (err !== undefined) {
            console.log("hey", err);
        } else {
            app.locals.db = client.db("Proyecto3");
        }
    }
);