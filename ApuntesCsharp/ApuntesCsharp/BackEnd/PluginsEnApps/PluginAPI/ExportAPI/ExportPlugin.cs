using System.Collections.Generic;

namespace PluginAPI.ExportAPI {
    public class ExportPlugin {
        public List<object> ExportItems { get; }

        public ExportPlugin() {
            ExportItems = new List<object>();
        }
    }
}
