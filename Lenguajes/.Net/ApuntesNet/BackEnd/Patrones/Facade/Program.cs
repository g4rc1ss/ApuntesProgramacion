using Facade.Patron;

// Inicializamos la clase fachada
var fachada = new Fachada();

// Ejecutamos la clase fachada sin saber que hace por dentro
Console.WriteLine(fachada.Operation());

Console.ReadKey();
