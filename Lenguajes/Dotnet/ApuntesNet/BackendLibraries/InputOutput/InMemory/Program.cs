using InMemory.Copia;
using InMemory.Escritura;
using InMemory.Lectura;

MemoryStream? streamEscrito = await Escribir.Write();
await Leer.Read(streamEscrito);
await Copiar.Copy(streamEscrito);

Console.ReadKey();
