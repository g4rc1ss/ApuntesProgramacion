using Proxy;

var client = new Client();

// Ejecutamos con el codigo del usuario
Console.WriteLine("Client: Executing the client code with a real subject:");
var realSubject = new RealSubject();
client.ClientCode(realSubject);

Console.WriteLine();

// Intermediario que antes y despues de la ejecucion del codigo, realiza ciertas acciones.
// Es un Middleware en realidad
Console.WriteLine("Client: Executing the same client code with a proxy:");
var proxy = new PatronProxy(realSubject);
client.ClientCode(proxy);

Console.ReadKey();
