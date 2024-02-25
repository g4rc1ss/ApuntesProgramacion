using MongoDatabase.Document;


using MongoDB.Driver;

namespace MongoDatabase.Queries;

internal static class SelectData
{
    public static async Task Select()
    {
        var result = await Helper.GetConnectionDatabase.GetCollection<Persona>("persona").FindAsync(FilterDefinition<Persona>.Empty);
        var listaResultados = await result.ToListAsync();

        foreach (var item in listaResultados)
        {
            Console.WriteLine(item.Name);
        }
    }
}
