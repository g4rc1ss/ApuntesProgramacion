using AplicationToExtender.Model;

using PluginAPI;
using PluginAPI.ExportAPI;

using System.Reflection;

namespace AplicationToExtender;

public partial class MainPage : ContentPage
{
    private List<DllData> DllData { get; set; } = [];

    public MainPage()
    {
        InitializeComponent();
        LoadEventCallers();
    }

    private async void CargarPluginsCLick(System.Object sender, EventArgs e)
    {
        var openFileDialog1 = await FilePicker.PickAsync();
        if (!string.IsNullOrEmpty(openFileDialog1.FullPath))
        {
            var plugin = CreateInstanceForAssemblyPath(openFileDialog1.FullPath);

            DllData.Add(new DllData
            {
                Name = openFileDialog1.FileName,
                Path = openFileDialog1.FullPath
            });
            ListaPlugins.ItemsSource = DllData;
        }
    }

    private void ListaPlugins_SelectionChanged(System.Object sender, SelectedItemChangedEventArgs e)
    {
        if (ListaPlugins.SelectedItem != null)
        {
            if (e.SelectedItem is DllData pluginData)
            {
                if (!string.IsNullOrEmpty(pluginData?.Path))
                {
                    var plugin = CreateInstanceForAssemblyPath(pluginData.Path);
                    plugin.Execute();

                    if (plugin.ExportInterface.fullWindow)
                    {
                        Application.Current.OpenWindow(plugin.ExportInterface.windowInterface as Window);
                    }
                    else
                    {
                        Control.Content = (View)plugin.ExportInterface.windowInterface;
                    }
                }
            }
        }
    }

    private IPlugin CreateInstanceForAssemblyPath(string path)
    {
        var plugin = Assembly.LoadFrom(path);
        return Activator.CreateInstance((from tipo in plugin.GetTypes()
                                         where tipo.GetInterface(nameof(IPlugin)) != null
                                         select tipo).FirstOrDefault()) as IPlugin;
    }

    private void LoadEventCallers()
    {
        ExportAPI.ExportEvent += LoadEventCall;
    }

    private async void LoadEventCall(object sender, EventArgs e)
    {
        var itemToLoad = sender as ExportObject;
        if (itemToLoad.ObjectToExport is string)
        {
            await DisplayAlert("Plugin", itemToLoad.ObjectToExport as string, "Cancel");
        }
    }

}
