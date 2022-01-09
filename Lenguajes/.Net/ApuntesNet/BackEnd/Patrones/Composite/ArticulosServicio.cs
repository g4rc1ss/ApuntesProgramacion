namespace Composite
{
    public class ArticulosServicio
    {
        private readonly ILogger _logging;

        public ArticulosServicio(ILogger logger)
        {
            _logging = logger;
        }

        public void GuardarArticulo(string contenido, string titulo)
        {
            _logging.Info($"vamos a insertar el articulo {titulo}");
            _logging.Info($"articulo {titulo} insertado");
        }

        public string ConsultarArticulo(string titulo)
        {
            _logging.Info($"Consultar artículo {titulo}");

            _logging.Fatal($"buscar articulo en el sistema de archivos {titulo}", null);
            return string.Empty;
        }
    }
}
