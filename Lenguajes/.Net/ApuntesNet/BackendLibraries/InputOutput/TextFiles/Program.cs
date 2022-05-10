using System;
using ArchivosTexto.ClaseBinary;
using ArchivosTexto.ClaseFile;
using ArchivosTexto.ClaseStream;

namespace ArchivosTexto
{
    internal class Program
    {

        private const string NOMBRE_ARCHIVO_BINARY = "ArchivoBinario.bin";
        private const string NOMBRE_ARCHIVO_BINARY_DESTINO = "ArchivoBinarioDestino.bin";

        private const string NOMBRE_ARCHIVO_FILE_TEXT = "ArchivoFileText.bin";
        private const string NOMBRE_ARCHIVO_FILE_TEXTASYNC = "ArchivoFileTextAsync.bin";
        private const string NOMBRE_ARCHIVO_FILE_BYTES = "ArchivoFileBytes.bin";
        private const string NOMBRE_ARCHIVO_FILE_ALLINES = "ArchivoFileAllLines.bin";
        private const string NOMBRE_ARCHIVO_FILE_DESTINO = "ArchivoFileDestino.bin";

        private const string NOMBRE_ARCHIVO_STREAM = "ArchivoStream.bin";


        private static void Main()
        {
            Console.WriteLine("USANDO CLASE BINARY");
            _ = new EscribirBinario(NOMBRE_ARCHIVO_BINARY);
            _ = new LeerBinario(NOMBRE_ARCHIVO_BINARY);
            _ = new CopyBinaryFile(NOMBRE_ARCHIVO_BINARY, NOMBRE_ARCHIVO_BINARY_DESTINO);

            Console.WriteLine("\n-----------------------------------------------------------\n");

            Console.WriteLine("USANDO CLASE STREAM");
            _ = new WriteWithStream(NOMBRE_ARCHIVO_STREAM);
            _ = new ReadWithStream(NOMBRE_ARCHIVO_STREAM);

            Console.WriteLine("\n-----------------------------------------------------------\n");

            Console.WriteLine("USANDO CLASE FILE");
            _ = new CreateFile(NOMBRE_ARCHIVO_FILE_TEXT, NOMBRE_ARCHIVO_FILE_TEXTASYNC, NOMBRE_ARCHIVO_FILE_BYTES, NOMBRE_ARCHIVO_FILE_ALLINES);
            _ = new WriteFile(NOMBRE_ARCHIVO_FILE_TEXT, NOMBRE_ARCHIVO_FILE_TEXTASYNC, NOMBRE_ARCHIVO_FILE_BYTES, NOMBRE_ARCHIVO_FILE_ALLINES);
            _ = new ReadFile(NOMBRE_ARCHIVO_FILE_TEXT, NOMBRE_ARCHIVO_FILE_TEXTASYNC, NOMBRE_ARCHIVO_FILE_BYTES, NOMBRE_ARCHIVO_FILE_ALLINES);
            _ = new CopyFile(NOMBRE_ARCHIVO_FILE_TEXT, NOMBRE_ARCHIVO_FILE_DESTINO);
            _ = new DeleteFile(NOMBRE_ARCHIVO_BINARY, NOMBRE_ARCHIVO_BINARY_DESTINO,
                NOMBRE_ARCHIVO_FILE_TEXT, NOMBRE_ARCHIVO_FILE_TEXTASYNC, NOMBRE_ARCHIVO_FILE_BYTES, NOMBRE_ARCHIVO_FILE_ALLINES, NOMBRE_ARCHIVO_FILE_DESTINO,
                NOMBRE_ARCHIVO_STREAM);
        }
    }
}
