using System.Diagnostics;
using System.Runtime.InteropServices;

// Creamos el delegado que vamos a enviar a la DLL
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void Callback(int response);

public class ClaseInteractuaRust
{
    [DllImport("libcallback.dylib", CallingConvention = CallingConvention.Cdecl)]
    static extern void prueba_callback(Callback callback);

    public async Task EjecutarDllAsync(CancellationToken cancellationToken = default)
    {
        var taskCompletionSource = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

        void callback(int response)
        {
            if (!taskCompletionSource.TrySetResult(response))
            {
                taskCompletionSource.SetException(new Exception("No se puede insertar el resultado"));
            }
            Console.WriteLine(response);
        };

        Console.WriteLine($"Hilo de Csharp antes de llamar a la libreria {Thread.CurrentThread.ManagedThreadId}");
        prueba_callback(callback);

        using (cancellationToken.UnsafeRegister(static (task, ct) => ((TaskCompletionSource)task!).TrySetCanceled(ct), taskCompletionSource))
        {
            var stopwatch = Stopwatch.StartNew();
            await taskCompletionSource.Task;
            stopwatch.Stop();
            Console.WriteLine($"Hilo de Csharp despues de esperar con await {Thread.CurrentThread.ManagedThreadId}");

            Console.WriteLine($"Han pasado {stopwatch.ElapsedMilliseconds}");
        }
    }
}
