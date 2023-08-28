# Declaración de una clase
   Para crear una clase, utiliza la palabra clave `class`, seguida del nombre de la clase y las llaves que delimitan su contenido.

   ```php
   class Persona {
       // Propiedades
       public $nombre;
       public $edad;

       // Métodos
       public function saludar() {
           echo "Hola, mi nombre es {$this->nombre} y tengo {$this->edad} años.";
       }
   }
   ```

# Creación de objetos
   Una vez que tienes una clase, puedes crear objetos de esa clase utilizando el operador `new`.

   ```php
   $persona1 = new Persona();
   $persona1->nombre = "Juan";
   $persona1->edad = 30;
   ```

# Acceso a propiedades y métodos
   Puedes acceder a las propiedades y métodos de un objeto utilizando la sintaxis de flecha `->`.

   ```php
   echo $persona1->nombre; // Imprime "Juan"
   $persona1->saludar();   // Imprime "Hola, mi nombre es Juan y tengo 30 años."
   ```

# Constructores y destructores
   Un constructor es un método especial que se llama automáticamente cuando se crea un objeto de una clase. Puedes usarlo para inicializar propiedades.

   ```php
   class Persona {
       public $nombre;
       public $edad;

       public function __construct($nombre, $edad) {
           $this->nombre = $nombre;
           $this->edad = $edad;
       }
   }
   ```

# Encapsulación
   Puedes controlar la visibilidad de las propiedades y métodos usando los modificadores `public`, `protected` y `private`.

   - `public`: Accesible desde cualquier lugar.
   - `protected`: Accesible solo desde la clase y sus subclases.
   - `private`: Accesible solo desde la clase.

   ```php
   class Persona {
       private $nombre;

       public function setNombre($nuevoNombre) {
           $this->nombre = $nuevoNombre;
       }

       public function getNombre() {
           return $this->nombre;
       }
   }
   ```
