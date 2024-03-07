# Error
Rust maneja errores de manera diferente a otros lenguajes que utilizan excepciones. En lugar de excepciones, Rust utiliza el sistema de Resultados (Result) y el manejo de errores mediante el tipo `Result` y el trait `std::error::Error`.

### **Definición de un tipo Result para representar un resultado exitoso o un error:**

   ```rust
   use std::fs::File;
   use std::io::{self, Read};

   fn leer_archivo() -> Result<String, io::Error> {
       let mut archivo = File::open("ejemplo.txt")?;
       let mut contenido = String::new();
       archivo.read_to_string(&mut contenido)?;

       Ok(contenido)
   }
   ```

### **Manejo de Result en la función principal:**

   ```rust
   fn main() {
       match leer_archivo() {
           Ok(contenido) => println!("Contenido del archivo: {}", contenido),
           Err(error) => eprintln!("Error al leer el archivo: {}", error),
       }
   }
   ```

### **Creación de un nuevo tipo de error personalizado:**

   ```rust
   #[derive(Debug)]
   enum MiError {
       ArchivoNoEncontrado,
       ErrorDeLectura(io::Error),
   }

   impl std::fmt::Display for MiError {
       fn fmt(&self, f: &mut std::fmt::Formatter<'_>) -> std::fmt::Result {
           match self {
               MiError::ArchivoNoEncontrado => write!(f, "El archivo no fue encontrado."),
               MiError::ErrorDeLectura(e) => write!(f, "Error de lectura: {}", e),
           }
       }
   }

   impl std::error::Error for MiError {}
   ```

### **Uso del nuevo tipo de error en la función que lee el archivo:**

   ```rust
   fn leer_archivo() -> Result<String, MiError> {
       let mut archivo = File::open("ejemplo.txt").map_err(|_| MiError::ArchivoNoEncontrado)?;
       let mut contenido = String::new();
       archivo.read_to_string(&mut contenido).map_err(|e| MiError::ErrorDeLectura(e))?;

       Ok(contenido)
   }
   ```

### **Manejo del nuevo tipo de error en la función principal:**

   ```rust
   fn main() {
       match leer_archivo() {
           Ok(contenido) => println!("Contenido del archivo: {}", contenido),
           Err(error) => eprintln!("Error al leer el archivo: {}", error),
       }
   ```

# Panic
La macro `panic!` en Rust se utiliza para señalar situaciones en las que el programa se encuentra en un estado crítico y no puede recuperarse de manera segura.

### 1. **Identificación de situaciones críticas:**

   - **Errores Irrecuperables:** Utiliza `panic!` cuando encuentres un error que no puedas manejar de manera razonable y que haga que la continuación del programa sea insegura.

   - **Invariantes Violadas:** Si las invariantes de tu programa (propiedades fundamentales que deben mantenerse) han sido violadas y no puedes recuperarte de manera segura, considera el uso de `panic!`.

### 2. **Importación de la macro `panic!`:**

   Asegúrate de que la macro `panic!` esté disponible en tu programa. Esto se hace automáticamente en el preámbulo de un programa Rust:

   ```rust
   fn main() {
       // ...
   }
   ```

### 3. **Uso de `panic!`:**

   Cuando te encuentres en una situación crítica, llama a `panic!` con un mensaje descriptivo. Esto proporcionará información útil al usuario o al desarrollador cuando el programa se detenga.

   ```rust
   fn funcion_critica() {
       // Algo va mal, y no podemos continuar de manera segura
       panic!("¡Error crítico! No se puede continuar.");
   }

   fn main() {
       funcion_critica();
   }
   ```

### 4. **Proporcionar información detallada:**

   Es buena práctica proporcionar información detallada sobre el motivo del pánico. Puedes incluir variables, mensajes de error específicos u otra información relevante.

   ```rust
   fn verificar_condicion(valor: i32) {
       if valor < 0 {
           panic!("¡Pánico! El valor {} no puede ser negativo.", valor);
       }
   }

   fn main() {
       let mi_valor = -5;
       verificar_condicion(mi_valor);
   }
   ```

### 5. **Alternativas al pánico:**

   Considera el uso de manejo de errores convencional (Result y Option) en lugar de `panic!` cuando sea posible. El pánico debe ser reservado para situaciones realmente excepcionales y críticas.

   ```rust
   fn funcion_resultado(valor: i32) -> Result<(), String> {
       if valor < 0 {
           return Err(format!("¡Error! El valor {} no puede ser negativo.", valor));
       }
       // Hacer algo con el valor positivo aquí
       Ok(())
   }

   fn main() {
       let mi_valor = -5;
       if let Err(error) = funcion_resultado(mi_valor) {
           println!("Error: {}", error);
           // Manejo de errores aquí
       }
   }
   ```
