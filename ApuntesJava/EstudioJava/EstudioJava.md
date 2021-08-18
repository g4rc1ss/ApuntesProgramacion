# Estructura del código
```Java
package com.company;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        
    }
}
```
- ``import`` -> Para importar librerías y módulos

- ``package`` -> indica la ubicación del programa

- ``class`` -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.

- ``Main(string[] args)`` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

---
## Declaración de variables
```Java
String a = "hoa";
int b = 2;
double c = 2.0;
Boolean d = false;
var x = "h";
final int CONSTANTE = 2;
```
- `var` Se usa para no tener que indicar el tipo de la variable, lo detecta automaticamente
- `final` Se usa para establecer un valor que no puede ser modificado

---
## Convertir tipos
```Java
System.out.println((int)2.4f); // 2
int x = 1;
boolean bol = (x != 0); // true
System.out.println(bol);
```
Para convertir los tipos de datos se pueden usa el metodo `valueOf()` de los tipos habituales como Integer, String, etc.  
En general se realizan casteos como arriba explicado

----
## Sentencias de flujo
```Java
if (true) {

} else if (true) {

} else {

}

switch (opt) {
    case "Hola":
        break;
    default:
        break;
}
```

---
## Operador ternario
````Java
ArrayList<String> lista = null;
"x".startsWith('d') ? "Empieza por D" : "Pues no, no empieza por d";
assert lista != null;
````
- En el operador ternario se realiza la comprobacion de un `bool` y se agregan dos simbolos, el `?` cuando se cumple la condicion y los `:` si no se cumple dicha condicion
- El uso de `assert` se usa para comprobar el estado de un objeto, generalmente si este es null, la comprobacion se realiza y si es `false` lanzara una excepcion.

----
## Bucles
```Java
while (true) {
}

for (int i = 0; i < 90; i++) {
}

for (var item : list) {
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
| \' | Comilla simple | 0x0027
| \" | Comilla doble  | 0x0022
| \\ | Barra diagonal inversa | 0x005C
| \0 | Null | 0x0000
| \b | Retroceso | 0x0008
| \f | Avance de página | 0x000C
| \n | Nueva línea | 0x000A
| \r | Retorno de carro | 0x000D
| \t | Tabulación horizontal | 0x0009

### Concatenar Cadenas
---
La concatenacion de cadenas se utiliza para, en un String, agregar el contenido de una variable.
```Java
var saludo = "Hola";
System.out.println((saludo + " terricola");
```

### Métodos de string
---

```Java
var cadena = "Hola, yo me llamo Ralph, que tal estamos?";

// Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
var cadenaReplace = cadena.replace(',', '\n');

// Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
var cadenaSplit = cadena.split("m");

// Devuelve el indice donde se encuentra el caracter indicado
var cadenaIndex = cadena.indexOf('m');

// Compara el string con otro objeto, como por ejemplo, otra cadena
var cadenaCompare = cadena.compareTo("Hola, yo me llamo Ralph");

// Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial
var cadenaSubString = cadena.substring(3, 5);
```

---
## StringBuilder
StringBuilder es una clase de cadena mutable. Mutabilidad significa que una vez creada una instancia de la clase, se puede modificar anexando, quitando, reemplazando o insertando caracteres. 

StringBuilder mantiene un búfer para alojar las modificaciones en la cadena.

Los datos nuevos se anexan al búfer si hay espacio disponible; de lo contrario, se asigna un búfer nuevo y mayor, los datos del búfer original se copian en el nuevo búfer y, a continuación, los nuevos datos se anexan al nuevo búfer.

```Java
var stringBuilder = new StringBuilder();
stringBuilder.append(true);
stringBuilder.append("Terminado");
var cadenaCompleta = stringBuilder.toString();
```

---
# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas

Una lista es un tipo de colección ordenada(un array)

### Métodos de ArrayList

```Java
// Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
lista.add("me llamo Ralph");

// Devuelve la posicion de la lista donde se ubica el objeto a buscar
lista.indexOf("Hola");

// Eliminar de la lista el objeto indicado
lista.remove("me llamo Ralph");
```

---
## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede 
tener como máximo un valor en el diccionario

### Métodos de diccionarios

```Java
var diccionario = new HashMap<String, String>();
diccionario.put("Clave", "Valor");
diccionario.put("Key", "Value");

// Devuelve una lista con los valores del diccionario
var valores = diccionario.values();

// Devuelve un bool indicando si la clave existe en el diccionario
diccionario.containsKey("Clave");

// Elimina la Key del diccionario y por tanto, los valores asociados a la misma
diccionario.remove("Key");

// Metodo para obtener el valor asociado a la clave indicada
diccionario.get("Clave");
```

----
## Pilas
El Stack es una coleccion LIFO(Last in, First Out) sin tamaño fijo de los objetos indicados.

Al usar la forma de almacenamiento LIFO, en la coleccion se trabaja todo el rato sobre los primeros elementos, osea que cuando agregas un elemento nuevo por ejemplo, no se guardaria en el ultimo indice, sino que se almacenaria en el indice 0, al principio de la coleccion.

### Métodos de pilas
```Java
 var pila = new Stack<String>();
pila.push("prueba de push");

// Agrega un nuevo elemento en el ultimo indice
pila.push("Elemento");

// Elimina un elemento en el ultimo indice
pila.pop();

// Devuelve un eleemnto en el ultimo indice
pila.peek();

// Limpia todos los elementos de la coleccion
pila.clear();

// Convierte la pila en un array del tipo indicado
pila.toArray();

pila.contains("objeto");
```

----
## Colas
La Queue es una coleccion FIFO(First In, First Out).

Al usar la forma de almacenamiento FIFO, a la hora de agregar elementos se tendran que ir agregando al final de la coleccion y a la hora de trabajar con ellos, se iran extrayendo del mas antiguo al mas nuevo, por tanto, se accedera a los primeros.

### Métodos de colas
```Java
Queue<String> cola = new LinkedList<>();
cola.add("prueba de push");

// Agrega un nuevo elemento al final de la coleccion
cola.add("Elemento");

// Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
cola.remove();

// Devuelve el elemento mas antiguo de la coleccion
cola.peek();

// Limpia todos los elementos de la coleccion
cola.clear();

// Convierte la cola en un array del tipo indicado
cola.toArray();

// Comprobamos si la coleccion contiene un objeto especifico
cola.contains("objeto");
```

---
# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Java
//[access modifier] - [class] - [identifier]
public class Customer {
   // Fields, properties, methods and events go here...
}
```

---
## Static Class

La instruccion `static` se usa cuando se quiere el acceso a un metodo o propiedad sin que tenga que ser instanciada la clase.

Las clases estaticas estan bien usarlas cuando los datos almacenados no requieren de ser unicos o la clase no requiere de almacenar datos en si.
por ejemplo, la libreria `String` de Java realiza solo gestion sobre cadenas y las devuelve, no almacena nada de ellas.

```Java
public class A {
    public static void Metodo() {
    }
}
```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Java
abstract class A {
    private void MetodoFuncional() {
        System.out.println("");
    }

    abstract void MetodoNoFuncional(String parametro);
}

class B extends A {
    @Override
    void MetodoNoFuncional(String parametro) {
        System.out.println("");
    }
}
```

----
## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Java
final class FinalClass {
}
```

----
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Java
//[access modifier] - [type] - [identifier]
private void Metodo() {
    System.out.println("");
}

private String MetodoConReturn() {
    return "";
}
```

----
## Propiedades
Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se ejecutan cuando se tiene acceso a una propiedad o se asigna.
```Java
private String nombre;

public String getNombre() {
    return nombre;
}

public void setNombre(String nombre) {
    this.nombre = nombre;
}
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Java
class Clase extends SuperClase {
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Java
interface MiInterfaz {
    void MiMetodo();
}

class PruebaInterfazImplícita implements MiInterfaz {
    public void MiMetodo() {
    }
}
```

---
# Conceptos Avanzados

## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Java
public enum EnumeradorCartas {
    oro,
    basto,
    copa,
    espada
}
```

---
## Boxing y Unboxing
Todos los tipos de Java directa o indirectamente se derivan del tipo de clase Object, y Object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Java
int i = 123;
Object o = i; // Boxing
int j = (int)o; // Unboxing
```

---
## Generics
Los genéricos introducen en Java el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.  
En Java la Clase `ArrayList<>` o `HashMap<String, String>` se utilizan genericos para poder crear un array o un diccionario respectivamente, permitiendo la reutilizacion de código
- Puede crear sus propias interfaces, clases, métodos... Genéricos.
- Puede limitar las clases genéricas para habilitar el acceso a métodos en tipos de datos determinados.
- Puede obtener información sobre los tipos que se usan en un tipo de datos genérico en tiempo de ejecución mediante la reflexión

```Java
class ClaseGenerica<T extends ArrayList & List> {
    public void Add(T input) {
    }
}

class ClaseIEnumerable implements List {
    @Override
    public int size() {
        return 0;
    }

    @Override
    public boolean isEmpty() {
        return false;
    }

    @Override
    public boolean contains(Object o) {
        return false;
    }
}
```

# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Java
try {
    // Ejecucion del codigo que puede llegar a tener una excepcion
} catch (Exception ex) {
    // Se ha producido la excepcion y se obtiene un objeto de tipo Exception
    // Este objeto contiene unos valores para rastrear el motivo del error
} finally {
    // Esta es una parte del codigo que se ejecuta siempre aunque se produzca la excepcion
    // Y generalmente se usa para cerrar recursos, por ejemplo, abres una conexion con
    // la base de datos y a la hora de recibir los datos se produce la excepcion,
    // pues pasara por aqui para cerrar la conexion con la base de datos.
}
```

### Provocando una excepcion
```Java
public static void main(String[] args) {
    throw new IllegalArgumentException("El parametro es nulo");
}
```

### Creando excepciones propias
```Java
class MyException extends Exception {
    public MyException() {
    }

    public MyException(String message) {
        super(message);
    }

    public MyException(String message, Throwable cause) {
        super(message, cause);
    }

    public MyException(Throwable cause) {
        super(cause);
    }

    public MyException(String message, Throwable cause, boolean enableSuppression, boolean writableStackTrace) {
        super(message, cause, enableSuppression, writableStackTrace);
    }
}
```

---
# Programación MultiThreading

## Thread
Thread (hilo, tarea) es la clase base de Java para definir hilos de ejecución concurrentes dentro de un mismo programa.

### Implement Runnable
Se puede implementar el multithreading a traves de la interfaz Runnable:

```Java
public class HiloConInterface implements Runnable {
    int x;
    // Constructor
    public HiloConInterface(int x) {
        this.x = x;
    }

    // Metodo que hay que implementar
    public void run() {
        for (int i = 0; i < x; i++)
            System.out.println("En hilo " + x + ". Paso numero " + i);
    }
}
```

### Extends Thread
La clase thread se puede heredar para hacer uso de ella:

```Java
public class HiloConHerencia extends Thread {
    private int c; // Contador de cada hilo
    private int hilo;

    // Constructor
    public HiloConHerencia(int hilo) {
        this.hilo = hilo;
        System.out.println("CREANDO HILO: " + hilo);
    }

    // Metodos
    /* el metodo run se ejecuta tras el start del objeto en el main */
    public void run() {
        c = 0;
        while (c <= 5) {
            System.out.println("el hilo " + hilo + ", C = " + c);
            c++;
        }
    }
}
```

## Executor
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer esas consultas de forma paralelizada y reducir los tiempos.

```Java
ExecutorService task = Executors.newCachedThreadPool();

var taskToExecute = new ArrayList<Callable<Object>>();
for (int x = 0; x < 10; x++) {
    int finalX = x;
    taskToExecute.add(() -> {
        Thread.sleep(1000);
        return finalX;
    });
}
var resultados = task.invokeAll(taskToExecute);
for (var result : resultados) {
    System.out.println(result.get());
}
task.shutdown();
```

## Parallel Stream ForEach
Permite la ejecucion paralelizada de la lectura de una coleccion que implemente `List`

```Java
 var lista = new ArrayList<Integer>();
for (int x = 0; x < 1000; x++) {
    lista.add(x);
}

//Para paralelizar una lista mediante una funcion automatizada pasandole una lambda
lista.parallelStream().forEach((x) -> {
    System.out.println(x);
});
```
- El parámetro `x` contiene un objeto del tipo de la lista y solo 1 elemento de dicha lista, es lo mismo que si a un array le hacemos un `objetoArray[x]` con un for normal.
