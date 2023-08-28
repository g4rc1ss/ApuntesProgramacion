1. **Declaración de atributos:**
   Los atributos se definen utilizando la sintaxis `#[NombreAtributo(Argumentos)]`. Puedes aplicar atributos a clases, propiedades y métodos.

   ```php
   #[Atributo]
   class MiClase {
       #[Atributo]
       public $propiedad;

       #[Atributo]
       public function miMetodo() {
           // ...
       }
   }
   ```

2. **Atributos predefinidos:**
   PHP 8 introduce varios atributos predefinidos, como `@var`, `@param`, `@return` y más. Estos atributos son útiles para proporcionar información adicional en tu código.

   ```php
   class Calculadora {
       #[Pure]
       public function sumar(int $a, int $b): int {
           return $a + $b;
       }
   }
   ```

3. **Creación de atributos personalizados:**
   También puedes crear tus propios atributos personalizados definiendo clases para ellos.

   ```php
   #[Attribute]
   class MiAtributo {
       public function __construct(public $valor) {
       }
   }

   #[MiAtributo("Hola, soy un atributo personalizado")]
   class MiClase {
   }
   ```

4. **Acceso a atributos en tiempo de ejecución:**
   Puedes acceder a los atributos aplicados a una clase, propiedad o método en tiempo de ejecución utilizando la función `get_attributes()`.

   ```php
   $claseAtributos = ReflectionAttribute::getAttributes(MiClase::class);
   $propiedadAtributos = ReflectionAttribute::getAttributes(MiClase::class, 'propiedad');
   $metodoAtributos = ReflectionAttribute::getAttributes(MiClase::class, 'miMetodo');
   ```

5. **Uso de atributos para validación:**
   Los atributos pueden usarse para validar valores y propiedades en tiempo de compilación o ejecución.

   ```php
   #[Attribute]
   class ValorPositivo {
       public function __construct(public string $mensaje = "Debe ser un valor positivo") {
       }
   }

   class Producto {
       public function __construct(#[ValorPositivo] public float $precio) {
       }
   }
   ```