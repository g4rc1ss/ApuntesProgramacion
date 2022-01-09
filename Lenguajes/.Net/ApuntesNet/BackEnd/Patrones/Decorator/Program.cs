using Decorator;


Client client = new Client();

var simple = new ConcreteComponent();
Console.WriteLine("Client: I get a simple component:");
client.ClientCode(simple);
Console.WriteLine();

/**
 * Instanciamos clases que hereden de PatronDecorator, que este a su vez, hereda de Component
 * Les podemos pasar por parametro tanto clases inferiores como Component, como mas superiores, PatronDecorator
 * Cuando llamemos a la funcion, se iran ejecutando las funciones de las instancias abstractas que recibimos.
 * 
 */
ConcreteDecoratorA decorator1 = new ConcreteDecoratorA(simple);
ConcreteDecoratorB decorator2 = new ConcreteDecoratorB(decorator1);
Console.WriteLine("Client: Now I've got a decorated component:");
client.ClientCode(decorator2);

Console.ReadKey();
