using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace MongoDatabase {
    internal class Helper {
        private const string CONNECTION_STRING = "mongodb://root:123456@localhost:27017/";
        internal static IMongoClient GetMongoClient {
            get {
                return new MongoClient(CONNECTION_STRING);
            }
        }

        internal static IMongoDatabase GetConnectionDatabase {
            get {
                return GetMongoClient.GetDatabase("prueba");
            }
        }

    }
}
