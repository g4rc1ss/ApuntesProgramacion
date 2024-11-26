using LiteDB;

using LittleDB;


using var liteDb = new LiteDatabase("Filename=./database.db;Password=1234");

var userCollection = liteDb.GetCollection<User>("Users");

var user = new User { Username = "prueba", PhoneNumber = "748347384738", };
userCollection.Insert(user);

var resultFindOne = userCollection.FindOne(x => x.Username == "prueba");
Console.WriteLine(resultFindOne.Username);


user.Username = "Prueba de modificacion";
userCollection.Update(user);

// Establecemos este campo como un indice para hacer la busqueda de forma mas optima
userCollection.EnsureIndex(x => x.Username);

var resultQuery = userCollection.Query()
    .Where(x => x.Username == "Prueba de modificacion")
    .FirstOrDefault();


Console.WriteLine(resultQuery.Username);
