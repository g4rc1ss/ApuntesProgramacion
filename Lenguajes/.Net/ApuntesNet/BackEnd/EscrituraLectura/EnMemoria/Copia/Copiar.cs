namespace EnMemoria.Copia;

internal class Copiar
{
    public Copiar()
    {
    }

    internal static async Task Copy(MemoryStream streamEscrito)
    {
        using var memoryStream = new MemoryStream();

        await streamEscrito.CopyToAsync(memoryStream);
    }
}
