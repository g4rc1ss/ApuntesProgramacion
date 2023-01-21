﻿using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using PluginAPI.ExportAPI;
using PluginDeEjemplo.DeserializeJson;

namespace PluginDeEjemplo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var response = await GetMyIp();
            ExportAPI.ExportEventCaller(new ExportObject(response));
        }

        private Task<string> GetMyIp()
        {
            return Task.Run(() =>
            {
                try
                {
                    var response = string.Empty;
                    var request = (HttpWebRequest)WebRequest.Create("https://api.ipify.org/?format=json");

                    using (var responseHttp = (HttpWebResponse)request.GetResponse())
                    {
                        using (var stream = responseHttp.GetResponseStream())
                        {
                            using (var reader = new StreamReader(stream))
                            {
                                var leerConsultaWebJson = reader.ReadToEnd();
                                var leerJsonLocalizacion = JsonConvert.DeserializeObject<MyIp>(leerConsultaWebJson);
                                response = $"Direccion ip: {leerJsonLocalizacion.Ip} \n";
                            }
                        }
                    }
                    return response;
                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            });
        }
    }
}
