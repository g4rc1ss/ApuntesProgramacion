La interoperabilidad consiste en la capacidad de poder comunicarse con otro software, por ejemplo, hacer uso de liberias nativas del sistema operativo para la GUI, usar librerias desarrolladas en otros lenguajes, etc.

> Las técnicas de interoperabilidad, al ejecutar librerias externas son recursos no administrados y por tanto, el Garbage Collector no va a actuar sobre ellas.

# P/Invoke 
Es una libreria que permite acceder a estructuras, devoluciones de llamada y funciones de bibliotecas no administradas desde código administrado.
```rust
#[no_mangle]
pub extern fn add_numbers(number1: i32, number2: i32) -> i32 {
    println!("Hola con Rust");
    number1 + number2
}

/*
> cargo new lib
> cd lib
Creamos el archivo lib.rs
Editamos el archivo cargo.toml y agregamos:
    [lib]
    name="libreriaEjemploRust"
    crate-type = ["dylib"]
> cargo build
```

```Csharp
[DllImport("libreriaEjemploRust.dll")]
private static extern int add_numbers(int number1, int number2);

public static void Main(string[] args)
{
    int suma = add_numbers(1, 2);
    Console.WriteLine(suma);
}
```
