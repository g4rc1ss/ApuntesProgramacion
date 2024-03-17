# Declaración de una clase abstracta
   Para crear una clase abstracta, utiliza la palabra clave `abstract` antes de la palabra clave `class`.

   ```php
   abstract class FiguraGeometrica {
       abstract public function calcularArea();
   }
   ```

# Métodos abstractos
   Una clase abstracta puede contener métodos abstractos, que no tienen cuerpo en la clase abstracta y deben ser implementados en las subclases.

   ```php
   abstract class FiguraGeometrica {
       abstract public function calcularArea();
   }
   ```

# Herencia de una clase abstracta
   Las subclases de una clase abstracta deben implementar todos los métodos abstractos definidos en la clase base.

   ```php
   class Circulo extends FiguraGeometrica {
       private $radio;

       public function __construct($radio) {
           $this->radio = $radio;
       }

       public function calcularArea() {
           return pi() * pow($this->radio, 2);
       }
   }
   ```

# Uso de clases abstractas
   No puedes crear instancias de una clase abstracta. En cambio, debes crear objetos de sus subclases.

   ```php
   $circulo = new Circulo(5);
   echo "Área del círculo: " . $circulo->calcularArea(); // Imprime el área del círculo
   ```

# Métodos no abstractos en clases abstractas
   Una clase abstracta puede tener métodos no abstractos. Estos métodos se heredan a las subclases pero no necesitan ser implementados en ellas.

   ```php
   abstract class ClaseAbstracta {
       abstract public function metodoAbstracto();

       public function metodoNormal() {
           echo "Este es un método normal en una clase abstracta.";
       }
   }
   ```

# Constructores en clases abstractas
   Las clases abstractas pueden tener constructores que se ejecutan cuando se crea una instancia de una subclase.

   ```php
   abstract class Forma {
       protected $color;

       public function __construct($color) {
           $this->color = $color;
       }

       abstract public function dibujar();
   }
   ```
