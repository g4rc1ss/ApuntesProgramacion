

function createData(dbConnection) {
    let nuevoUsuario = {
        Nombre: "Nombre de Usuario",
        Apellido: "Apellido del Usuario",
        DNI: "DNI del Usuario",
        FechaUltimaEntrada: new Date(),
        FechaUltimaSalida: new Date(),
        EstaEnOficina: false
    }

    dbConnection.collection('Persona').insertOne(nuevoUsuario, function (err, InsertDatos) {
        if (err != undefined) {
            console.log(err);
        } else {
            console.log(InsertDatos);
        }
    });
}

module.exports = {
    createData: createData
};