namespace PluginAPI.ExportAPI {
    public sealed class ExportObject {
        public object ObjectToExport { get; }

        public ExportObject(object objectToExport) {
            ObjectToExport = objectToExport;
        }
    }
}
