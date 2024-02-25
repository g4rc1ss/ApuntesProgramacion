using Microsoft.Extensions.Configuration;

namespace ConfigurationFiles.JsonConfigFile;

public class UsarAppSettingsJson
{
    public string LocalizacionArchivo { get; internal set; }
    public UsarAppSettingsJson()
    {

    }

    internal void ArchivosConfiguracion()
    {
        var archivoConfiguracion = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        LocalizacionArchivo = archivoConfiguracion.GetSection("AppSettings").GetSection("LOCALIZACION_ARCHIVO").Value;
    }
}
