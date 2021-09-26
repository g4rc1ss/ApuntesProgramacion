using System;
using MongoDB.Driver;

namespace MongoDatabase {
    internal class CreateDatabaseAndTables {
        internal static void CreateDatabase(string connectionString) {
            var mongoClient = new MongoClient(connectionString);
            var apuntesNet = mongoClient.GetDatabase("ApuntesNet");
            var lista = mongoClient.ListDatabaseNames();
        }

        internal static void CreateTables(string connectionString) {
            var mongoClient = new MongoClient(connectionString);
        }
    }
}
