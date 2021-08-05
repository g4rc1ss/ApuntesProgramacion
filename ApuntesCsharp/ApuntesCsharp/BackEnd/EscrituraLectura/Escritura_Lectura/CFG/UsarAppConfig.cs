using System;
using System.Configuration;

namespace Escritura_Lectura.CFG {
    public class UsarAppConfig {
        public string LocalizacionArchivo { get; private set; }

        public void ArchivosConfiguracion() {
            //Se lee el archivo de configuracion app.config
            //se tiene que instalar las dependencia NuGet "System.Configuration.ConfigurationManager"
            var archivoConfiguracion = ConfigurationManager.AppSettings;
            LocalizacionArchivo = archivoConfiguracion["LOCALIZACION_ARCHIVO"] ?? null;
            Console.WriteLine(LocalizacionArchivo);
        }
    }
}
