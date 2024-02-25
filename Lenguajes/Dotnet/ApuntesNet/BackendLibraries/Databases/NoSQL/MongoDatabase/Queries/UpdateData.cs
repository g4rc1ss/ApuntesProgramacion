using MongoDatabase.Document;


using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class UpdateData
{
    public static async Task Update()
    {
        var filter = Builders<Persona>.Filter.Eq(x => x.Name, "asier");
        var update = Builders<Persona>.Update.Set(x => x.Name, "asier updateado");
        var valorRespuesta = await Helper.GetConnectionDatabase.GetCollection<Persona>("persona").UpdateOneAsync(filter, update);

        Console.WriteLine($"Se han modificado {valorRespuesta.ModifiedCount}");
    }
}
