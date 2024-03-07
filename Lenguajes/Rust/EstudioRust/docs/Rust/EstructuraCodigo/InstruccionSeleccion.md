# Instrucciones de Seleccion
Aquí tienes una guía básica sobre el uso de condicionales en Rust:

1. **if-else básico:**
   - Utiliza `if` para realizar una condición y `else` para manejar el caso contrario.

```rust
let numero = 42;

if numero > 0 {
    println!("Es un número positivo");
} else {
    println!("Es cero o negativo");
}
```

2. **if-else if-else:**
   - Puedes encadenar múltiples condiciones con `else if`.

```rust
let numero = 42;

if numero > 0 {
    println!("Es un número positivo");
} else if numero < 0 {
    println!("Es un número negativo");
} else {
    println!("Es cero");
}
```

3. **Match:**
   - Utiliza `match` para manejar múltiples casos de manera más expresiva.

```rust
let dia = "lunes";

match dia {
    "lunes" | "martes" | "miércoles" | "jueves" | "viernes" => {
        println!("Es un día laborable");
    }
    "sábado" | "domingo" => {
        println!("Es fin de semana");
    }
    _ => {
        println!("Día no reconocido");
    }
}
```

4. **Expresiones condicionales en una línea:**
   - Puedes usar la expresión condicional en una línea para asignaciones concisas.

```rust
let resultado = if condicion { valor1 } else { valor2 };
```

5. **Comprobación de patrones:**
   - Usa patrones en `if let` para desestructurar y verificar valores.

```rust
let opcion = Some(42);

if let Some(valor) = opcion {
    println!("Valor encontrado: {}", valor);
} else {
    println!("Ningún valor");
}
```

Estas son algunas formas comunes de utilizar condicionales en Rust. ¡Espero que te sean útiles!