# Structs
1. **Definición de una estructura (struct):**
   
   ```rust
   struct Persona {
       nombre: String,
       edad: u32,
   }
   ```

2. **Implementación de métodos asociados a la estructura:**

   ```rust
   impl Persona {
       // Método asociado que crea una nueva instancia de Persona
       fn nueva(nombre: &str, edad: u32) -> Persona {
           Persona {
               nombre: nombre.to_string(),
               edad,
           }
       }

       // Otro método que muestra información de la persona
       fn mostrar_informacion(&self) {
           println!("Nombre: {}, Edad: {}", self.nombre, self.edad);
       }
   }
   ```

3. **Creación de una instancia y llamada a métodos:**

   ```rust
   fn main() {
       let persona1 = Persona::nueva("Juan", 25);
       persona1.mostrar_informacion();
   }
   ```