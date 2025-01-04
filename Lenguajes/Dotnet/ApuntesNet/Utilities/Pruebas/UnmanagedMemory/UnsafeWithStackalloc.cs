namespace UnmanagedMemory;

public static class UnsafeWithStackalloc
{
    public static unsafe void ExecuteWithPointers()
    {
        int* number = stackalloc int[10000];

        for (int i = 0; i < 10000; i++)
        {
            number[i] = 1 * sizeof(int);
        }
    }

    public static unsafe void ExecuteWithSpan()
    {
        // No puede ser usado fuera de métodos
        // Es mejor que usar punteros crudos, ya que abstrae para manejarlo de forma segura
        Span<int> number = stackalloc int[10000];

        for (int i = 0; i < number.Length; i++)
        {
            number[i] = 1 * sizeof(int);
        }
    }

    public static void ExecuteWithMemory()
    {
        var number = new int[10000];
        var memory = new Memory<int>(number);

        for (int i = 0; i < memory.Length; i++)
        {
            number[i] = i;
        }
    }
}