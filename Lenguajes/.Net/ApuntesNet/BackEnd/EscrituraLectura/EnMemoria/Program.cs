using EnMemoria.Copia;
using EnMemoria.Escritura;
using EnMemoria.Lectura;


var streamEscrito = await new Escribir().Write();
await new Leer().Read(streamEscrito);
await new Copiar().Copy(streamEscrito);
