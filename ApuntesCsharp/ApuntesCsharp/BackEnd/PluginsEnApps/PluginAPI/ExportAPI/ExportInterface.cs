namespace PluginAPI.ExportAPI {
    public class ExportInterface {
        public readonly bool fullWindow;
        public readonly object windowInterface;
        public ExportInterface(object windowInterface, bool fullWindow) {
            this.windowInterface = windowInterface;
            this.fullWindow = fullWindow;
        }
    }
}
