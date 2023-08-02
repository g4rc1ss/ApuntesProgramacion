# P/Invoke
La interoperabilidad consiste en la capacidad de poder comunicarse con otro software, por ejemplo, hacer uso de liberias nativas del sistema operativo para la GUI, usar librerias desarrolladas en otros lenguajes, etc.

> Las técnicas de interoperabilidad, al ejecutar librerias externas son recursos no administrados y por tanto, el Garbage Collector no va a actuar sobre ellas.

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
name="rustCallback"
crate-type = ["cdylib"]

[dependencies]
async-std = "1.12.0"
```

```rust
use async_std::task;
use std::{time::Duration};

#[no_mangle]
pub extern "C" fn prueba_callback(callback: extern "C" fn(result: i32)) {
    let std_task = task::spawn(async move {
        let response = 676767;
        
        task::sleep(Duration::from_secs(10)).await;

        // Ejecutamos el Callback
        callback(response);
    });
}
```
En este ejemplo de codigo vamos a crear una funcion asíncrona en `Rust` que ejecuta una operacion que lleva un tiempo(10 segundos) y esta recibe una funcion `Callback` para que, cuando termine, poder avisar a nuestra aplicacion `.net`

```Csharp
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public delegate void Callback(int response);

public class ClaseInteractuaRust
{
    [DllImport("rustCallbackWin.dll")]
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
        prueba_callback(callback);

        using (cancellationToken.UnsafeRegister(static (task, ct) => ((TaskCompletionSource)task!).TrySetCanceled(ct), taskCompletionSource))
        {
            await taskCompletionSource.Task;
            
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
