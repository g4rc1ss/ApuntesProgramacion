using System;
using System.IO;

namespace ArchivosTexto.ClaseFile {
    internal class CreateFile {
        public CreateFile(params string[] archivosCrear) {
            // Creamos el archivo en la ruta correspondiente
            foreach (var archivo in archivosCrear) {
                using var file = File.Create(archivo);
                Console.WriteLine($"Archivo {archivo} creado");
            }
        }
    }
}
