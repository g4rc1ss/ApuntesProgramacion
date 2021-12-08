using System.Threading.Tasks;
using System.Linq;
using MongoDB.Driver;
using MongoDatabase.Document;

namespace MongoDatabase {
    internal class CreateDatabaseAndCollections {
        internal static async Task CreateCollection() {
            if ((await (await Helper.GetConnectionDatabase.ListCollectionNamesAsync()).ToListAsync()).Where(x => x == "persona").FirstOrDefault() == null) {
                await Helper.GetConnectionDatabase.CreateCollectionAsync("persona");
            }
        }
    }
}
