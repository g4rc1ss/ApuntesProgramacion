# P/Invoke
La interoperabilidad consiste en la capacidad de poder comunicarse con otro software, por ejemplo, hacer uso de liberias nativas del sistema operativo para la GUI, usar librerias desarrolladas en otros lenguajes, etc.

> Las técnicas de interoperabilidad, al ejecutar librerias externas son recursos no administrados y por tanto, el Garbage Collector no va a actuar sobre ellas.

## Ejemplo
Creamos una libreria en Rust con el comando `cargo new --lib rustlib` 

En el archivo `cargo.toml` agregamos el siguiente codigo:

```toml
[package]
name = "rustlib"
version = "0.1.0"
edition = "2021"

# See more keys and their definitions at https://doc.rust-lang.org/cargo/reference/manifest.html
[lib]
name="rustlib"
crate-type = ["cdylib"]

[dependencies]
```

```rust
pub fn prueba_interoperabilidad() {
    println!("Hola dotnet");
}

```
En este ejemplo de codigo vamos a crear una funcion asíncrona en `Rust` que ejecuta una operacion que lleva un tiempo(10 segundos) y esta recibe una funcion `Callback` para que, cuando termine, poder avisar a nuestra aplicacion `.net`

Para compilar la libreria de `Rust` ejecutamos el comando `cargo build --release`

```Csharp
public class ClaseInteractuaRust
{
    [DllImport("rustlib.dylib", CallingConvention = CallingConvention.Cdecl)]
    static extern void prueba_interoperabilidad();

    public EjecutarDll(){
        prueba_interoperabilidad();
    }
}
```

1. Importamos la libreria con el atributo `DllImport` de `dotnet`
1. Llamamos a la funcion, de la misma forma que la funcion de la libreria que estamos usando, en este caso la funcion en `Rust` se llama `prueba_interoperabilidad`
1. Llamamos a la funcion como si de un metodo se tratara y con eso deberia de ejecutar la libreria sin problemas.


> Hay que tener en cuenta el Path de la libreria, el import es desde disco local

