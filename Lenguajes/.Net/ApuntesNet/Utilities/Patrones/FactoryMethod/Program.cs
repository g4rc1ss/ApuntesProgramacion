using FactoryMethod;

var baseDeDatos = Factory.GetAlmacenamientoBaseDatos();
baseDeDatos.Guardar("entidad BBDD");

var file = Factory.GetAlmacenamientoFile();
file.Guardar("Entidad File");

Console.ReadKey();
