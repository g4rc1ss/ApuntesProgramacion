using System.Threading.Tasks;
using MongoDatabase.Queries;

namespace MongoDatabase {
    internal class Program {
        private static async Task Main(string[] args) {
            await CreateDatabaseAndCollections.CreateCollection();
            await InsertData.Insert();
            await UpdateData.Update();
            await DeleteData.Delete();
            await SelectData.Select();
        }
    }
}
