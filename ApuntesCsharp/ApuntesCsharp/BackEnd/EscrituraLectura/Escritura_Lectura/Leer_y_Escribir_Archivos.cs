using Escritura_Lectura.ArchivosTexto.BinaryRead_Writer;
using Escritura_Lectura.ArchivosTexto.StreamRead_Writer;
using InputOutput = System.IO;

namespace Escritura_Lectura {
    internal class Leer_y_Escribir_Archivos {
        private static void Main(string[] args) {
            // Usamos JSON
            new JSON.UsarJSON().UsingJSON();

            // Usamos un archivo de configuracion
            var localizacionArchivo = new CFG.UsarAppConfig();
            localizacionArchivo.ArchivosConfiguracion();
            var localizacion_Archivo = localizacionArchivo.LocalizacionArchivo;

            InputOutput::File.Delete(localizacion_Archivo);
        }
    }
}
