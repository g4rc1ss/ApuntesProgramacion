# Declaración de una clase base
   La clase base, también conocida como clase padre o superclase, es la clase de la cual se derivarán otras clases.

   ```php
   class Vehiculo {
       public $marca;
       public $modelo;

       public function __construct($marca, $modelo) {
           $this->marca = $marca;
           $this->modelo = $modelo;
       }

       public function mostrarDetalles() {
           echo "Marca: {$this->marca}, Modelo: {$this->modelo}";
       }
   }
   ```

# Declaración de una subclase
   La subclase hereda las propiedades y métodos de la clase base utilizando la palabra clave `extends`.

   ```php
   class Automovil extends Vehiculo {
       public $puertas;

       public function __construct($marca, $modelo, $puertas) {
           parent::__construct($marca, $modelo);
           $this->puertas = $puertas;
       }

       public function mostrarDetalles() {
           parent::mostrarDetalles();
           echo ", Puertas: {$this->puertas}";
       }
   }
   ```

# Creación y uso de objetos
   Puedes crear objetos de la subclase y acceder a los métodos y propiedades heredados.

   ```php
   $auto = new Automovil("Toyota", "Corolla", 4);
   $auto->mostrarDetalles(); // Imprime "Marca: Toyota, Modelo: Corolla, Puertas: 4"
   ```

# Llamada a métodos de la clase base
   Si la subclase redefine un método de la clase base, puedes usar la palabra clave `parent` para llamar al método de la clase base desde la subclase.

   ```php
   class Motocicleta extends Vehiculo {
       public function mostrarDetalles() {
           parent::mostrarDetalles();
           echo ", Tipo: Motocicleta";
       }
   }

   $moto = new Motocicleta("Harley", "Sportster");
   $moto->mostrarDetalles(); // Imprime "Marca: Harley, Modelo: Sportster, Tipo: Motocicleta"
   ```

# Herencia múltiple y conflicto de nombres
   En PHP, una clase puede heredar de una sola clase base. Sin embargo, puedes implementar interfaces para simular herencia múltiple.

   ```php
   interface PuedeVolar {
       public function volar();
   }

   class Ave implements PuedeVolar {
       public function volar() {
           echo "El ave está volando.";
       }
   }
   ```
