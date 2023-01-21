// The client code can parameterize an invoker with any commands.
using Command;

/**
 * Creamos un objeto que se encargara de ejecutar tareas en un orden determinado.
 * Agregamos las tareas, que reciben un objeto de tipo ICommand
 * Ejecutamos el metodo Invoke del Invoker
 */

var invoker = new Invoker();
invoker.Add(new SimpleCommand("Say Hi!"));
var receiver = new Receiver();
invoker.Add(new ComplexCommand(receiver, "Send email", "Save report"));

invoker.Execute();

Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
