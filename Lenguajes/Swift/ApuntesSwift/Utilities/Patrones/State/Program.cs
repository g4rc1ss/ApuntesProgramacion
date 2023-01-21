// The client code.
using State;

var context = new Context(new ConcreteStateA());
context.Request1();
context.Request2();


Console.WriteLine("Pulsa una tecla para finalizar");
Console.ReadKey();
