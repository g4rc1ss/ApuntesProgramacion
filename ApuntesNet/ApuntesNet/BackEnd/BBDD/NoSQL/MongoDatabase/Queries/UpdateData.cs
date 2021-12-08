using System;
using System.Threading.Tasks;
using MongoDatabase.Document;
using MongoDB.Bson;
using MongoDB.Driver;

namespace MongoDatabase.Queries {
    internal static class UpdateData {
        public static async Task Update() {
            var filter = Builders<Persona>.Filter.Eq(x => x.Name, "asier");
            var update = Builders<Persona>.Update.Set(x => x.Name, "asier updateado");
            await Helper.GetConnectionDatabase.GetCollection<Persona>("persona").UpdateOneAsync(filter, update);
        }
    }
}
