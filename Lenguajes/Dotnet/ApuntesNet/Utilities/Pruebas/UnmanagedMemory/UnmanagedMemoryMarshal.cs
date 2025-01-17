using System.Diagnostics;
using System.Runtime.InteropServices;

namespace UnmanagedMemory;

public static class UnmanagedMemoryMarshal
{
    public static void Execute()
    {
        var pointer = IntPtr.Zero;
        var size = 2L * 1024 * 1024 * 1024;
        var numberOfIntegers = size / sizeof(int);

        try
        {
            Console.WriteLine("Reservamos memoria no administrada con Marshal");
            pointer = Marshal.AllocHGlobal((nint)size);

            Console.WriteLine("Rellenamos la memoria reservada no administrada");
            for (long i = 0; i < numberOfIntegers; i++)
            {
                // Calculamos la dirección de memoria de cada entero
                var ptr = IntPtr.Add(pointer, (int)(i * sizeof(int)));

                // Escribimos el valor entero (por ejemplo, asignar el valor de i)
                Marshal.WriteInt32(ptr, (int)i);
            }

            Console.WriteLine($"Memoria que usa el proceso: {GC.GetTotalMemory(true)}");
        }
        catch (Exception)
        {
            Console.WriteLine("No se pudo asignar la memoria requerida.");
        }
        finally
        {
            if (pointer != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(pointer);
                Console.WriteLine("La memoria no administrada ha sido liberada.");
            }

            Console.WriteLine($"Memoria que usa el proceso: {Process.GetCurrentProcess().PrivateMemorySize64}");
        }
    }
}