using MongoDatabase.Queries;

namespace MongoDatabase {
    internal class Program {
        const string CONNECTION_STRING = "mongodb://root:123456@localhost:27017/";
        private static void Main(string[] args) {
            CreateDatabaseAndTables.CreateDatabase(CONNECTION_STRING);
            CreateDatabaseAndTables.CreateTables(CONNECTION_STRING);
            InsertData.Insert(CONNECTION_STRING);
            UpdateData.Update(CONNECTION_STRING);
            DeleteData.Delete(CONNECTION_STRING);
            SelectData.Select(CONNECTION_STRING);
        }
    }
}
