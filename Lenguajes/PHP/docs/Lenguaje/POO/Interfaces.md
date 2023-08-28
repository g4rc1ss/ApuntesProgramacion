# Declaración de una interfaz
   Para crear una interfaz, utiliza la palabra clave `interface` seguida del nombre de la interfaz y las llaves que delimitan su contenido.

   ```php
   interface FiguraGeometrica {
       public function calcularArea();
   }
   ```

# Implementación de una interfaz en una clase
   Las clases que implementan una interfaz deben proporcionar una implementación para todos los métodos definidos en la interfaz.

   ```php
   class Circulo implements FiguraGeometrica {
       private $radio;

       public function __construct($radio) {
           $this->radio = $radio;
       }

       public function calcularArea() {
           return pi() * pow($this->radio, 2);
       }
   }
   ```

# Uso de interfaces
   Una clase puede implementar múltiples interfaces, lo que le obliga a definir la implementación para todos los métodos requeridos por esas interfaces.

   ```php
   interface Dibujable {
       public function dibujar();
   }

   class Cuadrado implements FiguraGeometrica, Dibujable {
       private $lado;

       public function __construct($lado) {
           $this->lado = $lado;
       }

       public function calcularArea() {
           return pow($this->lado, 2);
       }

       public function dibujar() {
           echo "Dibujando un cuadrado.";
       }
   }
   ```

# Herencia y interfaces
   Las clases pueden implementar interfaces mientras también heredan de una clase base.

   ```php
   abstract class Forma {
       abstract public function getNombre();
   }

   class Rectangulo extends Forma implements FiguraGeometrica {
       private $base;
       private $altura;

       public function __construct($base, $altura) {
           $this->base = $base;
           $this->altura = $altura;
       }

       public function calcularArea() {
           return $this->base * $this->altura;
       }

       public function getNombre() {
           return "Rectángulo";
       }
   }
   ```
