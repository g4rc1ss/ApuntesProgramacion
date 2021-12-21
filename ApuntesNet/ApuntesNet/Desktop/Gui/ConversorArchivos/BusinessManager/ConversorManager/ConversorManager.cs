namespace ConversorArchivos.BusinessManager.ConversorManager
{
    using System.IO;
    using System.Threading.Tasks;
    using Aspose.Words;
    using ConversorArchivos.BusinessManager.ConversorManager.Interfaces;

    public class ConversorManager : IConversorManager
    {
        public ConversorManager()
        {

        }

        public void ConvertTo(string folderPath, string extensionInicial, string extensionFinal)
        {
            var listadoArchivos = Directory.GetFiles(folderPath, $"*.{extensionInicial}", SearchOption.AllDirectories);

            _ = Parallel.ForEach(listadoArchivos, archivo =>
            {
                var nombreArchivo = new FileInfo(archivo);
                var nombreArchivoSinExtension = nombreArchivo.Name.Replace(nombreArchivo.Extension, string.Empty);
                var directorio = Directory.CreateDirectory($"{nombreArchivo.DirectoryName}\\{nombreArchivoSinExtension}");

                var archivoConvertido = new Document(nombreArchivo.FullName);
                archivoConvertido.Save($"{directorio.FullName}\\{nombreArchivoSinExtension}.{extensionFinal}");
            });
        }
    }
}
