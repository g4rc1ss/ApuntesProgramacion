const mongodb = require("mongodb");
const createData = require('./Queries/create/CreateMongoDbData');
const updateData = require('./Queries/update/UpdateMongoDbData');
const deleteData = require('./Queries/delete/DeleteMongoDbData');
const findData = require('./Queries/find/FindMongoDbData');


let MongoClient = mongodb.MongoClient;
let dbConnection;
MongoClient.connect(
    "mongodb://root:123456@localhost:27017/",
    function (err, client) {
        if (err !== undefined) {
            console.log("hey", err);
        } else {
            dbConnection = client.db("Proyecto3");
        }
    }
);

createData.createData(dbConnection);
updateData.updateData(dbConnection);
deleteData.deleteData(dbConnection);
findData.findData(dbConnection);
