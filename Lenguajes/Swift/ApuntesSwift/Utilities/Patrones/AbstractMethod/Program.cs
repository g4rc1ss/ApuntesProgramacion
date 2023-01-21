
using AbstractMethod;

var factoria = new FactoriaAbstracta();

factoria.CreateAlmacenamientoApi().Guardar("objeto de api");
factoria.CreateAlmacenamientoFile().Guardar("Objeto de File");
factoria.CreateAlmacenamientoBBDD().Guardar("Objeto de BBDD");


Console.ReadKey();
