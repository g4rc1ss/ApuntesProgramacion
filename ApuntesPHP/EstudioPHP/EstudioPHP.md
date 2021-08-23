1. [Estructura del código](#estructura-del-código)

	 1. [Declaración de variables](#declaración-de-variables)

	 1. [Convertir tipos](#convertir-tipos)

	 1. [Sentencias de flujo](#sentencias-de-flujo)

	 1. [Operador ternario](#operador-ternario)

	 1. [Bucles](#bucles)

1. [Cadenas](#cadenas)

	 1. [String](#string)

		 1. [Literales](#literales)

		 1. [Interpolacion de Cadenas](#interpolacion-de-cadenas)

		 1. [Métodos de string](#métodos-de-string)

1. [Colecciones](#colecciones)

	 1. [Array](#array)

		 1. [Métodos de Array](#métodos-de-array)

	 1. [Diccionarios](#diccionarios)

		 1. [Métodos de diccionarios](#métodos-de-diccionarios)

1. [Programación Orientada a Objetos](#programación-orientada-a-objetos)

	 1. [Class](#class)

	 1. [Abstract Class](#abstract-class)

	 1. [Final Class](#final-class)

	 1. [Metodos](#metodos)

	 1. [Metodos estaticos](#metodos-estaticos)

	 1. [Propiedades](#propiedades)

	 1. [Herencia](#herencia)

	 1. [Interface](#interface)

1. [Conceptos Avanzados](#conceptos-avanzados)

	 1. [Liberacion de Memoria](#liberacion-de-memoria)

1. [Tratamiento de Excepciones](#tratamiento-de-excepciones)

	 1. [Excepciones](#excepciones)

		 1. [Capurando las excepciones](#capurando-las-excepciones)

		 1. [Provocando una excepcion](#provocando-una-excepcion)

		 1. [Creando excepciones propias](#creando-excepciones-propias)


# Estructura del código

```php
<?php
$lista = array(
    'Lunes' => '1',
    'Martes' => '2',
    'Miercoles' => '3',
    'Jueves' => '4',
    'Viernes' => '5',
    'Sabado' => '6',
    'Domingo' => '7',
);
?>

<!DOCTYPE html>
<html>

<head>

</head>

<body>

    <?php foreach ($lista as $key => $value) : ?>
        <p><?php echo "{$key} - {$value}"; ?></p>
    <?php endforeach; ?>

</body>

</html>
```
- ``include_once`` -> Para importar archivos y librerias php

---
## Declaración de variables
```php
<?php
$cadena = "";
$numero = 2;
$numeroFlotante = 2.5;
$booleana = true;
```

---
## Convertir tipos
```php
<?php
intval($cadena);
boolval($numero);
intval($numeroFlotante);
intval($booleana);
```

----
## Sentencias de flujo
```php
<?php
if (condition) {
    # code...
} elseif (condition) {
    # code...
} else {
    # code...
}

switch ($variable) {
    case 'value':
        # code...
        break;
    
    default:
        # code...
        break;
}
```

---
## Operador ternario
````php
<?php
$variable = $booleana ? "true" : "false";
````

----
## Bucles
```php
<?php
while ($a <= 10) {
    # code...
}

do {
    # code...
} while ($a <= 10);


for ($i=0; $i < $coleccion; $i++) { 
    # code...
}

foreach ($coleccion as $key => $value) {
    # code...
}
```

---
# Cadenas

## String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

### Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009
| \\v | Tabulación vertical | 0x000B

### Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con las concatenaciones, pero es mas claro y mejor.
```php
<?php
echo "{$variable}";
```

### Métodos de string
---

```php
<?php
// Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
str_replace("h", " ", $cadena);

// Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
explode(" ", $cadena);

// Devuelve el indice donde se encuentra el caracter indicado
strpos($cadena, "g");

// Compara el string con otro objeto, como por ejemplo, otra cadena
strcmp($cadena, "Hola, yo me llamo Ralph");

// Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial
substr($cadena, 3, 5);
```

# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Array
Un array es un conjunto de objetos almacenados en una variable que puede ser recorrido para obtener los resultados.

### Métodos de Array

```php
<?php
$lista = array("Valor 1", "Valor 2");

// Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
$lista[] = "me llamo Ralph";

// Devuelve la posicion de la lista donde se ubica el objeto a buscar
array_search("Valor 2", $lista);

// Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
array_splice($lista, 0, 0, "jajajaja")

// Eliminar de la lista el objeto indicado
unset($lista[1]);

// Ordenas la lista al contra
array_reverse($lista)
```

## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede tener como máximo un valor en el diccionario

### Métodos de Diccionarios

```php
<?php
$diccionario = array(
    "Clave 1" => "Valor 1",
    "Clave 2" => "Valor 2"
);

// Devuelve una lista con las claves del diccionario
array_keys($diccionario);

// Devuelve una lista con los valores del diccionario
array_values($diccionario);

// Devuelve un bool indicando si la clave existe en el diccionario
array_key_exists("Clave 1", $diccionario);

// Elimina la Key del diccionario y por tanto, los valores asociados a la misma
unset($diccionario["Clave 2"]);

// Metodo para obtener el valor asociado a la clave indicada
$diccionario["Clave 1"];

```

# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```php
<?php
class ClasePhp
{
    private $var = "";
    public function __construct(String $var = null)
    {
        $this->var = $var;
    }
}
```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```php
<?php
abstract class ClaseAbstracta
{
    abstract protected function FunctionName(int $variable);
}

class ClaseNormal extends ClaseAbstracta
{
    protected function FunctionName(int $variable)
    {
        
    }
}
```

----
## Final Class
El modificador `final` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```php
<?php
final class BaseClass {
   public function test() {
       echo "llamada a BaseClass::test()\n";
   }

   // Aquí no importa si definimos una función como final o no
   final public function moreTesting() {
       echo "llamada a BaseClass::moreTesting()\n";
   }
}

class ChildClass extends BaseClass {
}
// Devuelve un error Fatal: Class ChildClass may not inherit from final class (BaseClass)
```

----
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```php
<?php
public function FunctionName(Type $var = null)
{
    # code...
}
```

----
## Metodos estaticos
Un método es un bloque de código que contiene una serie de instrucciones.
```php
class Estatico {
    public static function unMetodoEstatico() {
        // ...
    }
}

Estatico::unMetodoEstatico();
```

----
## Propiedades
La encapsulacion se utiliza para no dar demasiada información sobre la implementacion de las clases y los atributos que contiene, para ello se hace uso de las funciones.  
```php
<?php
private $var = "";

public function get_var()
{
    return $this->var;
}

public function set_var(string $var)
{
    $this->var = $var;
}
```

## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```php
<?php
class ClasePadre
{
}

class ClaseHija extends ClasePadre
{
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```php
<?php
interface IInterfaz
{
    public function metodo(string $var);
}

class ImplementoInterfaz implements IInterfaz
{
    public function metodo(string $var)
    {
        
    }
}
```

---
# Conceptos Avanzados

## Liberacion de Memoria
El objetivo del recolector de basuras es reducir el uso de memoria limpiando las variables de referencias circulares. En PHP esto ocurre cuando el root buffer está lleno o cuando se llama a la función `gc_collect_cycles()`. El siguiente es un ejemplo con diferentes usos de memoria en función de las variables creadas:

```php
gc_collect_cycles();
```

En Php se puede liberar espacio de memoria de las variables con el metodo `unset()`;
Un uso de ejemplo para esta instruccion sera la eliminacion de una lista muy grande en memoria por ejemplo, de esta forma liberariamos ese espacio.

```php
$diccionario = array(
    "Clave 1" => "Valor 1",
    "Clave 2" => "Valor 2"
);

unset($diccionario);
```
# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```php
<?php
try {
    throw new Exception('foo!');
} catch (Exception $e) {
    // Codigo del catch
}
```

### Provocando una excepcion
```php
<?php
throw new Exception('foo!');
```

### Creando excepciones propias
```php
<?php
class MiExcepción extends Exception
{
}

try {
    throw new MiExcepcion('foo!');
} catch (MiException $e) {
    // Codigo del catch
}
```
