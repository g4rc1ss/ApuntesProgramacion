using System;
using ArchivosTexto.ClaseBinary;
using ArchivosTexto.Read.ClaseBinary;

namespace ArchivosTexto {
    internal class Program {

        private const string NOMBRE_ARCHIVO_BINARY = "ArchivoBinario.bin";
        private const string NOMBRE_ARHIVO_BINARY_DESTINO = "ArchivoBinarioDestino.bin";
        private const string NOMBRE_ARCHIVO_FILE = "ArchivoBinario.bin";
        private const string NOMBRE_ARCHIVO_STREAM = "ArchivoBinario.bin";


        private static void Main(string[] args) {
            Console.WriteLine("USANDO CLASE BINARY");
            new EscribirBinario().EscribirArchivosBin(NOMBRE_ARCHIVO_BINARY);
            new LeerBinario().LeerArchivosBin(NOMBRE_ARCHIVO_BINARY);


            Console.WriteLine("\n-----------------------------------------------------------\n");

            Console.WriteLine("USANDO CLASE FILE");


            Console.WriteLine("\n-----------------------------------------------------------\n");


            Console.WriteLine("USANDO CLASE STREAM");

        }
    }
}
