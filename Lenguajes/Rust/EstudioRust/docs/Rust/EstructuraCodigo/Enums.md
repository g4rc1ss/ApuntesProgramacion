# Enumerador
1. **Definición de Enum:**
   - Define un enum con valores asociados.

```rust
enum Estado {
    Activo,
    Inactivo,
    Pendiente,
}
```

2. **Valores asociados:**
   - Asocia datos a los valores del enum.

```rust
enum Resultado {
    Ok(i32),
    Err(String),
}

let exito = Resultado::Ok(42);
let error = Resultado::Err("Algo salió mal".to_string());
```

3. **Coincidencia de patrones (match):**
   - Utiliza `match` para manejar diferentes casos de valores enum.

```rust
match mi_estado {
    Estado::Activo => println!("Está activo"),
    Estado::Inactivo => println!("Está inactivo"),
    Estado::Pendiente => println!("Está pendiente"),
}
```

4. **Valores por defecto y "_":**
   - Puedes usar `_` para manejar todos los demás casos no especificados.

```rust
match valor {
    1 => println!("Es uno"),
    2 => println!("Es dos"),
    _ => println!("Es otro valor"),
}
```

5. **Enum con datos estructurados:**
   - Asocia estructuras a los valores del enum.

```rust
enum Coordenada {
    Punto { x: f64, y: f64 },
    Origen,
}
```

6. **Implementación de métodos:**
   - Añade métodos a tu enum.

```rust
impl Estado {
    fn mostrar(&self) {
        match self {
            Estado::Activo => println!("Está activo"),
            Estado::Inactivo => println!("Está inactivo"),
            Estado::Pendiente => println!("Está pendiente"),
        }
    }
}

mi_estado.mostrar();
```

7. **Uso de `if let`:**
   - Utiliza `if let` para manejar casos específicos de valores enum.

```rust
if let Estado::Activo = mi_estado {
    println!("Está activo");
}
```

8. **Enums con atributos:**
   - Añade atributos a los valores del enum.

```rust
#[derive(Debug)]
enum MiEnum {
    Valor1,
    Valor2(i32),
    Valor3 { x: f64, y: f64 },
}
```
