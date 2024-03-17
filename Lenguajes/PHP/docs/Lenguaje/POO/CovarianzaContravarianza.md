# Covarianza
La covarianza se refiere a la relación entre los tipos de retorno en una jerarquía de herencia. En términos simples, cuando una clase derivada (subclase) devuelve un tipo más específico que la clase base, se considera covariante.

# Contravarianza
La contravarianza, por otro lado, se refiere a la relación entre los tipos de parámetros en una jerarquía de herencia. Si una clase derivada (subclase) acepta parámetros más generales que la clase base, se considera contravariante.

En PHP, las versiones 7.2 y posteriores admiten la covarianza y la contravarianza en los tipos de retorno y en los parámetros de los métodos de una clase, siempre y cuando se cumplan ciertas condiciones. Aquí tienes un ejemplo para cada caso:

# Covarianza (Tipos de retorno)
Supongamos que tienes una clase base `Animal` y una subclase `Perro`, y quieres que el método `obtener()` de la subclase devuelva un tipo más específico que el método `obtener()` de la clase base.

```php
class Animal {
    public function obtener(): Animal {
        // ...
    }
}

class Perro extends Animal {
    public function obtener(): Perro {
        // ...
    }
}
```

En este caso, la covarianza está presente porque el tipo de retorno en la subclase (`Perro`) es más específico que el tipo de retorno en la clase base (`Animal`).

# Contravarianza (Tipos de parámetro)
Supongamos que tienes una clase base `Procesador` y una subclase `ProcesadorEspecial`, y quieres que el método `procesar()` de la subclase acepte un tipo de parámetro más general que el método `procesar()` de la clase base.

```php
class Procesador {
    public function procesar(Procesable $objeto): void {
        // ...
    }
}

class ProcesadorEspecial extends Procesador {
    public function procesar(ObjetoEspecial $objeto): void {
        // ...
    }
}
```
