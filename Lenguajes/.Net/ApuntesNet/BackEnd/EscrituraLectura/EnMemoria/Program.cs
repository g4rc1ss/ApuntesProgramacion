using EnMemoria.Copia;
using EnMemoria.Escritura;
using EnMemoria.Lectura;


var streamEscrito = await Escribir.Write();
await Leer.Read(streamEscrito);
await Copiar.Copy(streamEscrito);

Console.ReadKey();
