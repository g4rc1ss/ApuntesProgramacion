# Declaración de un enumerador
   Puedes crear un enumerador utilizando la palabra clave `enum`. Define los valores posibles dentro del enumerador como constantes.

   ```php
   enum DiaSemana {
       case LUNES;
       case MARTES;
       case MIERCOLES;
       // ... otros días de la semana
   }
   ```

# Uso de enumeradores
   Una vez que has definido un enumerador, puedes crear variables que tomen esos valores.

   ```php
   $dia = DiaSemana::LUNES;
   ```

# Comparación de enumeradores
   Puedes comparar valores de enumeradores utilizando el operador `==`.

   ```php
   if ($dia == DiaSemana::LUNES) {
       echo "Es lunes.";
   }
   ```

# Switch con enumeradores
   Los enumeradores son especialmente útiles con instrucciones `switch`, ya que permiten una comparación más legible.

   ```php
   switch ($dia) {
       case DiaSemana::LUNES:
           echo "Es lunes.";
           break;
       case DiaSemana::MARTES:
           echo "Es martes.";
           break;
       // ... otros casos
   }
   ```

# Valores y métodos personalizados en enumeradores
   Puedes asociar valores personalizados a cada constante y definir métodos dentro de un enumerador.

   ```php
   enum EstadoCivil {
       case SOLTERO = 'S';
       case CASADO = 'C';

       public function descripcion(): string {
           return match ($this) {
               self::SOLTERO => "Soltero",
               self::CASADO => "Casado",
           };
       }
   }
   ```

   ```php
   $estado = EstadoCivil::CASADO;
   echo $estado->descripcion(); // Imprimirá "Casado"
   ```
