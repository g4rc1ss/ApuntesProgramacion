# Declaración de una clase estática
   Para crear una clase estática, utiliza la palabra clave `class` seguida del nombre de la clase y la palabra clave `static`.

   ```php
   class Utilidades {
       public static $version = "1.0";

       public static function saludar() {
           echo "¡Hola desde Utilidades!";
       }
   }
   ```

# Acceso a propiedades y métodos estáticos
   Puedes acceder a propiedades y métodos estáticos usando el operador de resolución de ámbito `::`.

   ```php
   echo Utilidades::$version; // Imprime "1.0"
   Utilidades::saludar();     // Imprime "¡Hola desde Utilidades!"
   ```

# Beneficios de las clases estáticas
   Las clases estáticas son útiles cuando tienes propiedades o métodos que pertenecen a la clase en sí, en lugar de instancias individuales. Algunos casos de uso comunes son:

   - Crear utilidades o funciones auxiliares.
   - Definir constantes globales para una clase.
   - Implementar patrones de diseño como el Singleton.

# Uso de constantes estáticas
   Puedes definir constantes estáticas dentro de una clase para tener valores que no cambian y son accesibles sin crear una instancia.

   ```php
   class Matematicas {
       public const PI = 3.14159;
   }

   echo Matematicas::PI; // Imprime el valor de PI
   ```

# Métodos estáticos en herencia
   Los métodos estáticos pueden ser heredados por las subclases, pero no se pueden sobrescribir.

   ```php
   class Subclase extends Utilidades {
   }

   Subclase::saludar(); // Imprime "¡Hola desde Utilidades!"
   ```

# Singleton con una clase estática
   El patrón de diseño Singleton garantiza que solo exista una instancia de una clase en todo el ciclo de vida de una aplicación.

   ```php
   class Database {
       private static $instance;

       private function __construct() {
           // Constructor privado para evitar instanciación directa
       }

       public static function getInstance() {
           if (!self::$instance) {
               self::$instance = new self();
           }
           return self::$instance;
       }
   }

   $db = Database::getInstance(); // Obtener la instancia única de la base de datos
   ```
