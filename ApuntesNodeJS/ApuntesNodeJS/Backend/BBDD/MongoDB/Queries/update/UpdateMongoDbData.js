

function updateData(dbConnection, nombreUsuarioPut, apellidoUsuarioPut, DNIPut, estaEnOficina) {
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
        } else {
            datosUpdate["FechaUltimaSalida"] = new Date();
        }
    }

    dbConnection.collection('Persona').updateOne({ _id: mongodb.ObjectId(idUsuario) }, { $set: datosUpdate }, function (err, datos) {
        if (err != undefined) {
            console.log(err);
        } else {
            console.log(datos);
        }
    })
}

module.exports = {
    updateData: updateData
}