namespace EnMemoria.Copia;

internal class Copiar
{
    public Copiar()
    {
    }

    internal async Task Copy(MemoryStream streamEscrito)
    {
        using var memoryStream = new MemoryStream();

        await streamEscrito.CopyToAsync(memoryStream);
    }
}
