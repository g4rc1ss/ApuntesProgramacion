using System;
using MongoDB.Driver;

namespace MongoDatabase {
    internal class CreateDatabaseAndTables {
        internal static void CreateDatabase(string connectionString) {
            var mongoClient = new MongoClient(connectionString);
            mongoClient.GetDatabase("ApuntesNet");
        }

        internal static void CreateTables(string connectionString) {
            var mongoClient = new MongoClient(connectionString);
        }
    }
}
