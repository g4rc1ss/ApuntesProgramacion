namespace Composite
{
    public class Logging : ILogger
    {
        public void Info(string message)
        {
            Console.WriteLine($"Info - {message}");
        }
        public void Error(string message, Exception e)
        {
            Console.WriteLine($"Error - {message} - Excepcion {e?.Message}");
        }
        public void Fatal(string message, Exception e)
        {
            Console.WriteLine($"Fatal - {message} - Excepcion {e?.Message}");
        }
    }
}
