using System;
using System.IO;

namespace ArchivosTexto.ClaseStream
{
    internal class ReadWithStream
    {
        public ReadWithStream(string nombreArchivo)
        {
            using (var readFile = new StreamReader(nombreArchivo))
            {
                Console.WriteLine($"Leido hasta el final - {readFile.ReadToEnd()}");
            }

            using (var readFile = new StreamReader(nombreArchivo))
            {
                Console.WriteLine($"\n Leido caracter a caracter - ");
                while (readFile.Peek() >= 1)
                {
                    Console.Write((char)readFile.Read());
                }
            }

            using (var readFile = new StreamReader(nombreArchivo))
            {
                Console.WriteLine($"\n \n Leido por Bloques - ");
                var buffer = new char[5];
                while (!readFile.EndOfStream)
                {
                    var lenght = readFile.ReadBlock(buffer, 0, buffer.Length);
                    Console.WriteLine(new string(buffer, 0, lenght));
                }
            }
        }
    }
}
