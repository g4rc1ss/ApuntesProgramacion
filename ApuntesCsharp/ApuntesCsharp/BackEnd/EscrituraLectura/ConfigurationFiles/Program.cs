using System;
using System.IO;

namespace ConfigurationFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            // Usamos un archivo de configuracion
            var localizacionArchivo = new CFG.UsarAppConfig();
            localizacionArchivo.ArchivosConfiguracion();
            var localizacion_Archivo = localizacionArchivo.LocalizacionArchivo;

            File.Delete(localizacion_Archivo);
        }
    }
}
