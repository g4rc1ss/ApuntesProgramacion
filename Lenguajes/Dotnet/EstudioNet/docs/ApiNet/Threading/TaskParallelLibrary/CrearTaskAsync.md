# Crear Tareas asincronas
La `TPL` a fin de cuentas no deja de ser una libreria que gracias a la magia que hace `roslyn` en tiempo de compilacion, nos permite poder hacer uso de las tareas async de una forma sencilla y entendible, pero la realidad es que por debajo, cuando llamamos a una libreria de bajo nivel, para ejecutar una operacion I/O se hace de forma diferente

Para nosotros es "magico", pero cuando hacemos una llamada por medio de `HttpClient.PostAsync()` en realidad lo que se hace es llamar a una `dll` o libreria del sistema que se encarga de establecer la conexion con la interfaz de red (el hardware) y ejecutar lo que nosotros necesitamos.

Para poder ejecutar ese codigo asincrono a nivel de codigo hay que hacer uso de los `callback`, que, consiste en enviar a esa libreria una referencia a una funcion que se tendra que ejecutar cuando termine la ejecucion, de esta forma, nuestro programa puede liberar el hilo y retornarlo al `Threadpool` hasta que la tarea se termine.


## Ejemplo
Creamos una libreria en Rust con el comando `cargo new --lib rustCallback` 

En el archivo `cargo.toml` agregamos el siguiente codigo:

```toml
[package]
name = "rustCallback"
version = "0.1.0"
edition = "2021"

# See more keys and their definitions at https://doc.rust-lang.org/cargo/reference/manifest.html
[lib]
name = "callback"
path = "src/lib.rs"
crate-type = ["rlib", "dylib"]

[dependencies]
async-std = "*"
```

```rust
use std::{thread, time::Duration};

use async_std::task;

#[no_mangle]
pub fn prueba_callback(callback: fn(result: i32)) {
    let response = 4783784;

    let thread_id = thread::current().id();
    println!("Hilo de ejecucion antes del task::spawn {:?}", thread_id);

    task::spawn(async move {
        let thread_id_antes_sleep = thread::current().id();
        println!(
            "Hilo de ejecucion dentro del task::spawn {:?}",
            thread_id_antes_sleep
        );

        task::sleep(Duration::from_secs(10)).await;

        let thread_id_despues_sleep = thread::current().id();
        println!(
            "Hilo de ejecucion despues del sleep {:?}",
            thread_id_despues_sleep
        );

        // Ejecutamos el callback para indicar que la task ha terminado
        callback(response);
    });

    let thread_id_despues_spawn = thread::current().id();
    println!(
        "Hilo de ejecucion despues del task::spawn {:?}",
        thread_id_despues_spawn
    );
}
```
En este ejemplo de codigo vamos a crear una funcion asíncrona en `Rust` que ejecuta una operacion que lleva un tiempo(10 segundos) y esta recibe una funcion `Callback` para que, cuando termine, poder avisar a nuestra aplicacion

Para compilar la libreria de `Rust` ejecutamos el comando `cargo build --release`

```Csharp
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
```
- Creamos un delegado de `Callback`
- Creamos una funcion `extern` para indicar la dll que queremos ejecutar de forma nativa
- Como la aplicacion se va a ejecutar de forma asincrona, creamos una instancia de `TaskCompletionSource` para poder insertar los resultados y modificar el state de la `Task`
- Implementamos el `callback` que vamos a enviar a la `dll` y esta se encargará de ejecutar, en el indicamos que recibimos un parametro de tipo `int` (que lo inserta la libreria de rust), al recibirlo, cambiamos el resultado y el estado de la tarea
- Ejecutamos la tarea
- Registramos un token de cancelacion vinculado a la tarea, el cual, si el token se modifica a canceled, la tarea terminará
- Esperamos la tarea de forma asincrona.


Si ejecutamos este codigo, podremos ver como en `.Net` cuando vamos a llamar a la dll estamos ejecutando un codigo de thread y cuando reicibimos el resultado, otro diferente, esto es por la *magia* que hace el runtime al detectar que la llamada esta en `await`, el hilo principal vuelve al threadpool para poder procesar otras tareas y cuando termina, lo recoge otro hilo diferente, de esta forma un mismo hilo, puede gestionar varias tareas a la vez en la misma aplicacion.