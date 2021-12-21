using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDatabase.Queries
{
    internal class CreateDatabaseAndCollections
    {
        internal static async Task CreateCollection()
        {
            if ((await (await Helper.GetConnectionDatabase.ListCollectionNamesAsync()).ToListAsync()).Where(x => x == "persona").FirstOrDefault() == null)
            {
                await Helper.GetConnectionDatabase.CreateCollectionAsync("persona");
            }
        }
    }
}
