using Facade.CodigoComplejo;

namespace Facade.Patron;

public class Fachada
{
    protected Subsystem1 _subsystem1;

    protected Subsystem2 _subsystem2;

    public Fachada()
    {
        _subsystem1 = new();
        _subsystem2 = new();
    }

    // Esto ejecuta de forma invisible al usuario un proceso mas complejo de clases, etc.
    public string Operation()
    {
        var result = $"Facade initializes subsystems:\n" +
            $"{_subsystem1.Operation1()}" +
            $"{_subsystem2.Operation1()}" +
            $"Facade orders subsystems to perform the action:\n" +
            $"{_subsystem1.OperationN()}" +
            $"{_subsystem2.OperationZ()}";
        return result;
    }
}
