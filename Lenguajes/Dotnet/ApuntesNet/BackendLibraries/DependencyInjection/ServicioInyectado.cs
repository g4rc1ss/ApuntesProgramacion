namespace DependencyInjection;

interface PServicioInyectado
{
    Task<bool> ExecuteAsync(CancellationToken cancellationToken = default);
}

public class ServicioInyectado : PServicioInyectado
{
    public Task<bool> ExecuteAsync(CancellationToken cancellationToken = default)
    {
        Console.WriteLine("Ejecutando el Servicio Inyectado");

        return Task.FromResult(true);
    }
}
