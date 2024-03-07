# Instrucciones de Iteracion
Aquí tienes una guía básica sobre el uso de bucles en Rust:

1. **Bucle `loop`:**
   - Crea un bucle infinito con `loop`.

```rust
loop {
    // Código que se ejecutará repetidamente
}
```

2. **Bucle `while`:**
   - Usa `while` para ejecutar código mientras una condición sea verdadera.

```rust
let mut contador = 0;

while contador < 5 {
    // Código que se ejecutará mientras la condición sea verdadera
    contador += 1;
}
```

3. **Bucle `for`:**
   - Utiliza `for` para iterar sobre una secuencia, como un rango.

```rust
for i in 0..5 {
    // Código que se ejecutará en cada iteración
    println!("Iteración: {}", i);
}
```

4. **Iteradores:**
   - Utiliza métodos de iteradores para operar sobre colecciones.

```rust
let numeros = vec![1, 2, 3, 4, 5];

for numero in numeros.iter() {
    // Código que se ejecutará para cada elemento de la colección
    println!("Número: {}", numero);
}
```

5. **Bucle `for` con patrones:**
   - Desestructura elementos en un bucle `for` usando patrones.

```rust
let tuplas = vec![(1, 'a'), (2, 'b'), (3, 'c')];

for (numero, caracter) in tuplas {
    // Código que utiliza los elementos desestructurados
    println!("Número: {}, Caracter: {}", numero, caracter);
}
```

6. **Bucle `for` con `enumerate`:**
   - Usa `enumerate` para obtener índices y valores en un bucle `for`.

```rust
let palabras = vec!["hola", "mundo", "!"];

for (indice, palabra) in palabras.iter().enumerate() {
    // Código que utiliza el índice y el valor
    println!("Índice: {}, Palabra: {}", indice, palabra);
}
```

7. **Bucle `for` con `for...in`:**
   - Itera directamente sobre elementos en un bucle `for...in`.

```rust
for elemento in iterable {
    // Código que se ejecutará para cada elemento
}
```

Estas son algunas formas comunes de utilizar bucles en Rust. ¡Espero que te sean útiles!