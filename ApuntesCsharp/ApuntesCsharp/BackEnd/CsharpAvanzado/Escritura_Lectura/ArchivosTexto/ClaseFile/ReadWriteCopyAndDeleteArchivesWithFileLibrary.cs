using System.IO;

namespace Escritura_Lectura.ArchivosTexto.ClaseFile {
    public class ReadWriteCopyAndDeleteArchivesWithFileLibrary {
        public ReadWriteCopyAndDeleteArchivesWithFileLibrary() {
            var fuente = "./archivo";
            var destino = "./destino";

            // Creamos el archivo en la ruta correspondiente
            using (File.Create(fuente)) {
                // Comprobamos la existencia del archivo
                if (File.Exists(fuente)) {
                }
            }
            // Escribimos en el archivo correcpondiente un contenido
            File.WriteAllText(fuente, "fdsjfkhrjgflhndsbafbgrheikabhfarigfbsrghfaslbhfreai \n bfhwbgf rhjsbfgdhsflbglavgfb lcvjavf ljubfa asgfjveasfb esfj");

            using (File.Create(destino)) { }

            // Borramos los archivos
            File.Delete(fuente);
            File.Delete(destino);
        }
    }
}
