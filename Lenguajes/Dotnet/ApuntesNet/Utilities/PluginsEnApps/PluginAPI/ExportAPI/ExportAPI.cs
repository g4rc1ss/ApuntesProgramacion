namespace PluginAPI.ExportAPI;

public static class ExportAPI
{
    public static event EventHandler? ExportEvent;

    public static void ExportEventCaller(ExportObject export)
    {
        ExportEvent?.Invoke(export, null);
    }
}
