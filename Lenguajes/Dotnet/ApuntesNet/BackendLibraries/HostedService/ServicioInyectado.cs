namespace DependencyInjection;

public interface IServicioInyectado
{
    Task<int> ExecuteAsync(CancellationToken cancellationToken = default);
}

public class ServicioInyectado : IServicioInyectado
{
    public int _counter = 0;

    public Task<int> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Ejecutando el Servicio Inyectado");
        _counter ++;
        return Task.FromResult(_counter);
    }
}
