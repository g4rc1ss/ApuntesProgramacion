using System.Net.Http.Json;
using PluginAPI.ExportAPI;

namespace PluginEjemplo;

public partial class RequestWindow : ContentPage
{
    public RequestWindow()
    {
        InitializeComponent();
    }

    async void Button_Clicked(System.Object sender, System.EventArgs e)
    {
        var response = await GetMyIp();
        ExportAPI.ExportEventCaller(new ExportObject(response));
    }

    private async Task<string> GetMyIp()
    {
        try
        {
            var ip = await new HttpClient().GetFromJsonAsync<MyIp>("https://api.ipify.org/?format=json");
            return $"Direccion ip: {ip.Ip} \n";

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }
}

