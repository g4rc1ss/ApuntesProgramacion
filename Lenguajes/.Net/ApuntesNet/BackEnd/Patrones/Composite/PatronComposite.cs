namespace Composite
{
    public class PatronComposite : ILogger
    {
        // Contenemos un objeto que referencia a instancias del objeto original o clase base.
        private readonly Logging loggingOriginal;

        public PatronComposite()
        {
            loggingOriginal = new Logging();
        }

        public void Info(string message) => loggingOriginal.Info(message);

        public void Error(string message, Exception e) => loggingOriginal.Error(message, e);

        public void Fatal(string message, Exception e)
        {
            Console.WriteLine($"Hemos guardado {message} en Base de datos");
        }
    }
}
