using System;
using ConfigurationFiles.JsonConfigFile;
using ConfigurationFiles.XmlConfigFile;

namespace ConfigurationFiles
{
    internal class Program
    {
        private static void Main()
        {
            // Usamos un archivo de configuracion
            var localizacionArchivoAppConfig = new UsarAppConfig();
            localizacionArchivoAppConfig.ArchivosConfiguracion();
            Console.WriteLine(localizacionArchivoAppConfig.LocalizacionArchivo);

            Console.WriteLine("---------------------------------------------------------------------------------------");

            var localizacionArchivoAppSettings = new UsarAppSettingsJson();
            localizacionArchivoAppSettings.ArchivosConfiguracion();
            Console.WriteLine(localizacionArchivoAppSettings.LocalizacionArchivo);
        }
    }
}
