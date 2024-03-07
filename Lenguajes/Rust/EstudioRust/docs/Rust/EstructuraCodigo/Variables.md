# Declaración de variables

1. **Declaración y asignación:**
   - Usa `let` para declarar e inicializar variables.

```rust
let mi_variable = 42;
```

2. **Mutabilidad:**
   - Por defecto, las variables son inmutables. Usa `mut` para hacerlas mutables.

```rust
let mut variable_mut = 10;
variable_mut = 20; // Válido porque la variable es mutable
```

3. **Tipos de datos:**
   - Rust es de tipado estático, pero puede inferir el tipo.

```rust
let entero: i32 = 42; // Entero de 32 bits con signo
let flotante: f64 = 3.14; // Punto flotante de 64 bits
let caracter: char = 'a'; // Carácter Unicode
let booleano: bool = true; // Valor booleano
```

4. **Sombra (Shadowing):**
   - Puedes declarar una nueva variable con el mismo nombre.

```rust
let x = 5;
let x = x + 1; // La nueva variable x sombrea la anterior
```

5. **Constantes:**
   - Usa `const` para declarar constantes con un tipo específico.

```rust
const MI_CONSTANTE: i32 = 100;
```

6. **Referencias y préstamos:**
   - Usa `&` para obtener una referencia y `&mut` para obtener una referencia mutable.

```rust
let referencia = &mi_variable;
let referencia_mut = &mut variable_mut;
```

7. **Desestructuración:**
   - Desestructura tuplas y estructuras para acceder a sus elementos.

```rust
let tupla = (1, "hola");
let (x, y) = tupla;
```

8. **Alcance (Scope):**
   - Las variables tienen un alcance definido.

```rust
{
    let dentro_del_scope = 42;
} // La variable se sale de alcance y no se puede acceder aquí
```

9. **Caducidad (Lifetime):**
   - Define caducidades para las referencias cuando sea necesario.

```rust
fn ejemplo<'a>(dato: &'a Tipo) {
    // Función con caducidad 'a
}
```
