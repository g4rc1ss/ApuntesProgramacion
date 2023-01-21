using InMemory.Copia;
using InMemory.Escritura;
using InMemory.Lectura;

var streamEscrito = await Escribir.Write();
await Leer.Read(streamEscrito);
await Copiar.Copy(streamEscrito);

Console.ReadKey();
