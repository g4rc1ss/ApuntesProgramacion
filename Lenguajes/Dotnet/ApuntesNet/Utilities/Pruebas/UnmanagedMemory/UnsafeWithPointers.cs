namespace UnmanagedMemory;

public static class UnsafeWithPointers
{
    public static void Execute()
    {
        // Los punteros se usan para gestionar la memoria a mas bajo nivel, pero estos obj
        // Siguen siendo gestionados por el runtime y el GC
        unsafe
        {
            var value = 42;

            // Obtenemos el puntero de la variable creada y asignada por el runtime
            int* ptr = &value;

            // Desreferenciamos el puntero(Accedemos al valor)
            Console.WriteLine(*ptr);
        }
    }
}