using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Windows;
using System.Windows.Controls;
using AplicacionToExtender.Database;
using AplicacionToExtender.Database.DatabaseEntities;
using Microsoft.Win32;
using PluginAPI;
using PluginAPI.ExportAPI;

namespace AplicacionToExtender
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPlugins();
            LoadEventCallers();
        }

        private void CargarPluginsCLick(object sender, RoutedEventArgs e)
        {
            var fileDialog = new OpenFileDialog()
            {
                Multiselect = true,
                Filter = "dll files (*.dll) |*.dll",
                InitialDirectory = Assembly.GetExecutingAssembly().Location,
            };

            if (fileDialog.ShowDialog() == true)
            {
                var listaPlugins = new List<Plugin>();

                foreach (var file in fileDialog.FileNames)
                {
                    var plugin = CreateInstanceForAssemblyPath(file);
                    listaPlugins.Add(new Plugin
                    {
                        Name = plugin.Name,
                        Description = plugin.Description,
                        LocalDllPath = file
                    });
                    ListaPlugins.Items.Add($"{plugin.Name} | {plugin.Description}");
                }
                if (listaPlugins.Count > 0)
                {
                    using (var context = new PluginsContext())
                    {
                        context.Plugins.AddRange(listaPlugins);
                        context.SaveChanges();
                    }
                }
            }
        }

        private void ListaPlugins_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListaPlugins.SelectedItem != null)
            {
                var selectedPlugin = (ListaPlugins.SelectedItem as string).Split("|");
                if (selectedPlugin != null && selectedPlugin.Length == 2)
                {

                    var pluginPath = default(string);

                    using (var context = new PluginsContext())
                    {
                        pluginPath = (from plugin in context.Plugins
                                      where plugin.Name == selectedPlugin[0].Trim() && plugin.Description == selectedPlugin[1].Trim()
                                      select plugin.LocalDllPath).FirstOrDefault();
                    }

                    if (!string.IsNullOrEmpty(pluginPath))
                    {
                        var plugin = CreateInstanceForAssemblyPath(pluginPath);
                        plugin.Execute();

                        if (plugin.ExportInterface.fullWindow)
                        {
                            (plugin.ExportInterface.windowInterface as Window).Show();
                        }
                        else
                        {
                            control.Content = plugin.ExportInterface.windowInterface;
                        }
                    }
                }
            }
        }

        private void LoadPlugins()
        {
            using (var context = new PluginsContext())
            {
                var query = (from plugin in context.Plugins
                             select plugin).ToList();
                foreach (var item in query)
                {
                    ListaPlugins.Items.Add($"{item.Name} | {item.Description}");
                }
            }
        }

        private IPlugin CreateInstanceForAssemblyPath(string path)
        {
            var plugin = Assembly.LoadFrom(path);
            var dependencias = new AssemblyDependencyResolver(plugin.Location);
            return Activator.CreateInstance((from tipo in plugin.GetTypes()
                                             where tipo.GetInterface(nameof(IPlugin)) != null
                                             select tipo).FirstOrDefault()) as IPlugin;
        }

        private void LoadEventCallers()
        {
            ExportAPI.ExportEvent += LoadEventCall;
        }

        private void LoadEventCall(object sender, EventArgs e)
        {
            var itemToLoad = sender as ExportObject;
            if (itemToLoad.ObjectToExport is string)
            {
                MessageBox.Show(itemToLoad.ObjectToExport as string);
            }
        }
    }
}
