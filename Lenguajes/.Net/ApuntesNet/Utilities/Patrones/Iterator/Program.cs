using Iterator;

var coleccionPersonalizado = new EnumerablePersonalizado<string>(2);
coleccionPersonalizado.enumerable[0] = "Hola";
coleccionPersonalizado.enumerable[1] = "Adios";

foreach (var item in coleccionPersonalizado)
{
    Console.WriteLine(item);
}

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
