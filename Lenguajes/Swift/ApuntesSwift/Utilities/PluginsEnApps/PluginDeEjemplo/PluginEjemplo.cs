using PluginAPI;
using PluginAPI.ExportAPI;

namespace PluginDeEjemplo
{
    public class PluginEjemplo : IPlugin
    {
        public PluginEjemplo()
        {
        }

        public string Name => "Enviar Correo";

        public string Description => "Plugin de Ejemplo de .NET CORE";

        public ExportPlugin ExportPlugin { get; private set; }

        public ExportInterface ExportInterface { get; private set; }

        public void Execute()
        {
            ExportInterface = new ExportInterface(new MainWindow().Content, false);
        }
    }
}
