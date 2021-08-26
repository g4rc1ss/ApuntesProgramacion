# Estructura del código

```Kotlin
package prueba

import prueba.PruebaClase

fun main(args: Array<String>) {
    println("Hello World!")
}
```
- ``package`` -> indica la ubicación del programa

- ``import`` -> Para importar librerías y módulos

- ``main`` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

---
## Declaración de variables
```Kotlin
var cadena: String = ""
var numero: Int = 0
var flotante: Float = 1.5f
var booleana: Boolean = false
val constante: String = "Constante"
```
- `val` -> La palabra reservada val se utiliza indicar una variable que es de solo lectura, por tanto no puede ser modificada.

---
## Tipos Nullables
Con el mismo marco de las variables de solo lectura y mutables, Kotlin evita que tus tipos acepten el literal constante null (ausencia de valor) como regla general.

Si necesitas un tipo que acepte nulos, defínelo como anulable, ubicando un signo de interrogación de cierre (?) al final del tipo.
```Kotlin
var aceptaNull: String?
aceptaNull = null
```

---
## Convertir tipos
```Kotlin
flotante.toInt()
numero.toFloat()
cadena.toByte()
```

---
## Sentencias de flujo
```Kotlin
if (true) {

} else if (true) {

} else {

}

when (numero) {
    1 -> println("Numero 1")
    2, 3 -> println("Numero 2 o 3")
    else -> "Otro numero"
}
```

---
## Operador ternario
````Kotlin
if (prueba.listaDatos.size > 0) prueba.listaDatos.get(0) else java.util.ArrayList<String>()
````

----
## Bucles
```Kotlin
for(dato in prueba.listaDatos){
    println(dato)
}

var x: Int = 0
while(x < prueba.listaDatos.size){
    if(x == 1){
        continue
    }
}

x = 0
do{
    if(x == 1){
        break
    }
    x ++
} while(x < prueba.listaDatos.size)
    
    println(sets)
}
```
- `continue` -> La expresión continue un una expresión de salto que solo se permite dentro de los cuerpos de los bucles. Su funcionalidad es saltar las sentencias de una iteración y pasar a la siguiente.
- `break` -> La expresión break es una expresión de salto que se permite solo al interior de los bucles. Su objetivo es pasar el control al siguiente punto del programa luego del bucle, es decir, finalizar el bucle.


# Cadenas

```Kotlin
val variableTexto: String = "Variable con Texto"
// raw string
val textoMultilinea = """
    Hola, este es un comentario
    de muchas lineas juntas
    en el lenguaje Kotlin
"""
```

## Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\' | Comilla simple | 0x0027
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\b | Retroceso | 0x0008
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009

## Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con las concatenaciones, pero es mas claro y mejor.
```Kotlin
var cadena: String = "$nombreVariable"
```

---
# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas mutables
Una lista es una colección genérica de elementos que se caracteriza por almacenarlos de forma ordenada, donde pueden existir duplicados (incluso un ítem `null`) y se indexan los elementos con base `0`.

### Métodos de listas

```Kotlin
val lista = mutableListOf("Dato 1", "Dato 2", "Dato 3") 

// Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
lista.add("Dato 4")

// Devuelve la posicion de la lista donde se ubica el objeto a buscar
lista.indexOf("Dato 0")

// Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
lista.add(0, "Dato 0")

// Eliminar de la lista el objeto indicado
lista.remove("Dato 3")

// Ordenas la lista al contra
lista.reverse()

```

---
## Mapas
Un mapa es una colección que almacena sus elementos (entradas) en forma de pares clave-valor.

Esto quiere decir que a cada clave le corresponde un solo valor y será única como si se tratase de un identificador.

### Métodos de Mapas

```Kotlin
var diccionario = mutableMapOf<String, String>(
    "Clave 1" to "Valor 1",
    "Clave 2" to "Valor 2",
    "Clave 3" to "Valor 3"
)

// Devuelve una lista con las claves del diccionario
diccionario.keys

// Devuelve una lista con los valores del diccionario
diccionario.values;

// Devuelve un bool indicando si la clave existe en el diccionario
diccionario.containsKey("Clave 4")

// Elimina la Key del diccionario y por tanto, los valores asociados a la misma
diccionario.remove("Clave 4");

// Metodo para obtener el valor asociado a la clave indicada
diccionario.get("Clave 4");

```

----
## Sets
Un conjunto o set es una colección de elementos sin ordenar que no soporta duplicados. Puedes ver este diseño conceptual como el modelo de los conjuntos matemáticos.

La interfaz genérica `Set<E>` es la que representa a los conjuntos de solo lectura en el paquete `kotlin.collections`. Al igual que List, Set extiende de `Collection<E>`:

```Kotlin
val sets = setOf<Int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0)

// Agrega al ultimo elemento de la coleccion el objeto que se le pasa por parametro
sets.add(10)

// Devuelve la posicion de la coleccion donde se ubica el objeto a buscar
sets.indexOf(20)

// Eliminar de la coleccion el objeto indicado
sets.remove(3)
```

# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Kotlin

```

---
## Static Class

La instruccion `static` se usa cuando se quiere el acceso a un metodo o propiedad sin que tenga que ser instanciada la clase.

Las clases estaticas estan bien usarlas cuando los datos almacenados no requieren de ser unicos o la clase no requiere de almacenar datos en si.
por ejemplo, la libreria `Convert` de .Net solo realiza conversion de tipos, no requiere de almacenar dicha conversion.

```Kotlin

```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Kotlin

```

----
## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Kotlin

```

----
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Kotlin

```

----
## Propiedades
Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los
campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se
ejecutan cuando se tiene acceso a una propiedad o se asigna.
```Kotlin

```

----
## Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

Imaginemos que podemos crear un método, almacenarlo en un objeto y pasarlo como parámetro de una función, pues en eso consiste.
```Kotlin

```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Kotlin

```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Kotlin

```

---
# Conceptos Avanzados

## Liberacion de Memoria


```Kotlin

```

---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Kotlin

```

---
## Indizadores
Son una propiedad que nos permite trabajar con un objeto como si fuera un array pudiendo acceder a los atributos del objeto mediante un `[index]`
```Kotlin

```

---
## yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común
```Kotlin

```

---
## Boxing y Unboxing
Todos los tipos de C# directa o indirectamente se derivan del tipo de clase object, y object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Kotlin

```

---
## Dynamic
Cuando creamos una variable debemos indicar el tipo de variable que va a ser, o podemos utilizar la palabra clave var, la cual se convertirá en tiempo de compilación en el tipo de variable - la cual denominamos variable implícita -

En el caso de las variables dinámicas, en vez de determinar su valor en tiempo de compilación se determina durante el tiempo de ejecución, o runtime.

Cuando el compilador pasa por la variable lo que hace es convertir en tipo en un tipo Object en la gran mayoría de los casos. 

Lo que quiere decir que cada vez que le asignamos un valor, cambiará también el tipo de variable que es el objeto, podemos verlo utilizando la siguiente línea de código:
```Kotlin

```


---
## Generics
Los genéricos introducen en .NET el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.
La biblioteca de clases .NET Framework contiene varias clases de colección genéricas nuevas en el espacio de nombres System.Collections.Generic. Estas se deberían usar siempre que sea posible en lugar de clases como ArrayList en el espacio de nombres System.Collections.
- Puede crear sus propias interfaces, clases, métodos, eventos y delegados genéricos.
- Puede limitar las clases genéricas para habilitar el acceso a métodos en tipos de datos determinados.
- Puede obtener información sobre los tipos que se usan en un tipo de datos genérico en tiempo de ejecución mediante la reflexión

```Kotlin

```

### Constraints
Los constraints son condiciones que deben de cumplir el parametro que se le pasa al generic para que funcione.

| Constraint | Descripción |
| ---------- | ----------- |
| | |

---
## Eventos
Un evento es un mensaje que envía un objeto cuando ocurre una acción.

Los eventos se realizan a mano en el codigo y son contenedores de un metodo Delegado que es el que se va a invocar.

Por ejemplo al interactuar con una interfaz de escritorio, se crea un objeto Button y se agrega al evento para detectar el click y se vincula a un metodo que se ha de ejecutar `Button_Click()`  
Por debajo lo que hace el codigo es detectar cuando se pulsa el boton y entonces, invoca el evento el cual tiene agregar como delegado el metodo que hemos escrito.

Para crear y controlar un evento se realiza el siguiente codigo:

```Kotlin

```

---
## Codigo no Administrado
El codigo no administrado es un tipo de codigo al que no puede acceder el `Garbage Collector` para realizar el proceso de limpieza de memoria, por tanto hay que hacerlo manualmente.

### 
Es una tecnologia que permite hacer uso de librerias compiladas de forma nativa con Kotlins como `Rust`, `Cpp`, etc.  
De esta forma permite realizar interoperabilidad con librerias de los diferentes sitemas como Windows, por ejemplo se puede hacer uso de esto para ejecutar librerias como el diseño de las GUi nativas.

```rust
#[no_mangle]
pub extern fn add_numbers(number1: i32, number2: i32) -> i32 {
    println!("Hola con Rust");
    number1 + number2
}

/*
> cargo new lib
> cd lib
Creamos el archivo lib.rs
Editamos el archivo cargo.toml y agregamos:
    [lib]
    name="libreriaEjemploRust"
    crate-type = ["dylib"]
> cargo build
```

```Kotlin

```

### Codigo inseguro
La mayor parte del código que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas del Kotlin pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

Este modo es un tipo de [Codigo no Administrado](#codigo-no-administrado) puesto que a este codigo no acceden las herramientas para liberar el espacio de memoria que ocupan por ejemplo.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

#### Punteros

```Kotlin

```

En la tabla siguiente se muestran los operadores e instrucciones que pueden funcionar en punteros en un contexto no seguro:

| Operador/Instrucción | Usar |
| -------------------- | ---- |
| | | |

---
# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Kotlin

```

### Provocando una excepcion
```Kotlin

```

### Creando excepciones propias
```Kotlin

```

---
# Programación Asincrona & MultiThreading

## 


```Kotlin

```

---
## Paralelismo
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer uso de la clase Parallel para realizar esas consultas de forma paralelizada y reducir los tiempos.

### Ejecucion de metodos paralelamente
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Kotlin

```

### Recorrer un bucle de forma paralela
Permite la ejecucion paralelizada de la lectura de una coleccion

```Kotlin

```

---
# Comprension de Listas


## 

```Kotlin

```
