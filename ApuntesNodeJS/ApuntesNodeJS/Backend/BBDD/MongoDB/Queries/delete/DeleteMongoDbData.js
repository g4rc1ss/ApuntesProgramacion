
function deleteData(dbConnection, idRegistro) {
    dbConnection.collection('Persona').deleteOne({ _id: mongodb.ObjectId(idRegistro) }, function (err, datos) {
        if (err != undefined) {
            console.log(err);
        } else {
            console.log(datos);
        }
    })
}

module.exports = {
    deleteData: deleteData
}