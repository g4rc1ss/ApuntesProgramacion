

function findData(dbConnection, idUsuario) {

    let datoBusqueda = {
        DNI: "DNI del Usuario"
    }
    if (idUsuario != undefined) {
        datoBusqueda["_id"] = mongodb.ObjectId(idUsuario);
    }

    dbConnection.collection('Persona').find(datoBusqueda).toArray(function (error, datos) {
        if (error != undefined) {
            console.log(error);
        } else {
            console.log(datos);
        }
    })
}

module.exports = {
    findData: findData
}