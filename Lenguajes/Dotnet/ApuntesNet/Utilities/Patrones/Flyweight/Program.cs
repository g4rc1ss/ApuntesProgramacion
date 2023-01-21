using Flyweight;

var guardar = new ObjetoGuardar
{
    Nombre = "Hola",
    Apellidos = "Prueba",
    Descripcion = "De cache"
};

FlyweightCache.SetValue("objeto", guardar);
FlyweightCache.SetValue("1", "Holaaaaaaaa");

FlyweightCache.TryGetValue("objeto", out ObjetoGuardar objeto);
Console.WriteLine(objeto);

FlyweightCache.TryGetValue("1", out var objeto1);
Console.WriteLine(objeto1.ToString());

Console.ReadKey();
