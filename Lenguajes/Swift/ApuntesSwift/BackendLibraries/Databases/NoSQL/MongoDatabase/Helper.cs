using MongoDB.Driver;

namespace MongoDatabase
{
    internal class Helper
    {
        private const string CONNECTION_STRING = "mongodb://root:123456@localhost:27017/";
        internal static IMongoClient GetMongoClient => new MongoClient(CONNECTION_STRING);

        internal static IMongoDatabase GetConnectionDatabase => GetMongoClient.GetDatabase("prueba");

    }
}
