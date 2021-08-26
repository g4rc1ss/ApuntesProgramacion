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
## Anulabilidad
Con el mismo marco de las variables de solo lectura y mutables, Kotlin evita que tus tipos acepten el literal constante null (ausencia de valor) como regla general.

Si necesitas un tipo que acepte nulos, defínelo como anulable, ubicando un signo de interrogación de cierre (?) al final del tipo.
```Kotlin
var aceptaNull: String?
aceptaNull = null
```

### Operador de acceso seguro
Si el miembro existe, entonces se retorna el contenido, de lo contrario se obtendrá null del recibidor.

```Kotlin
aceptaNull?.toBigDecimal()
```

### Operador Elvis
En Kotlin, este operador se reduce para comprobar expresiones anulables. Si el operando de la izquierda es null entonces retornará el de la derecha:

```Kotlin
val passwordSize = if (password!=null) password.length else 0
// Esto equivale a:
val passwordSize = password?.length ?: 0
```

### Operador de asercion
También es posible manejar la anulabilidad en Kotlin, usando el operador de aserción not null (`!!`) o __not-null assertion operator__

Este convierte cualquier valor a un tipo no anulable. Si no se puede, se lanza una excepción del tipo `NullPointerException`

```Kotlin
aceptaNull!!
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
class Prueba {
    private var nombre: String
    private var apellidos: String
    public var listaDatos = java.util.ArrayList<String>()
   
    constructor(nombre: String, apellidos: String) {
        this.nombre = nombre
        this.apellidos = apellidos
    }
    
    fun getNombre(): String {
        return nombre
    }
}
```

---
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Kotlin
fun metodo(parametro: Int, parametroTexto: String) {
    // Code
}

fun metodoReturn(): String {
    return ""
}
```

----
## Metodos Estaticos
Sirven para poder acceder a un metodo sin hacer falta instanciar la clase para ello.
```Kotlin
class PruebaClaseStatic {   
    constructor() {
        
    }
    
    companion object MetodosStatic {
        fun getNombre(): String {
            return "Asier"
        }
    }
}
```

----
## Propiedades
Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se ejecutan cuando se tiene acceso a una propiedad o se asigna.
```Kotlin
var propiedad: Int 
        get(){ return propiedad } 
        set(value) { propiedad = value }
```

----
## Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

Imaginemos que podemos crear un método, almacenarlo en un objeto y pasarlo como parámetro de una función, pues en eso consiste.
```Kotlin
val delegado by lazy {
    metodoImprimirPantalla()
}

delegado
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Kotlin
open class ClasePadre {
    constructor() {
        // Code
    }
    
    open fun metodo() {
        // Code
    }
}

class ClaseHija : ClasePadre {
    constructor() : super() {
        // Code
    }
    
    override fun metodo() {
        // Code
    }
}
```

---
## Abstract Class
No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Kotlin
abstract class ClaseAbstracta {
    abstract val propiedadAbstracta: Int

    abstract fun metodoAbstracto()

    fun metodoNoAbstracto() {
        // Cuerpo
    }
}

class PruebaClaseHeredaDeAbstracta : ClaseAbstracta {
    override val propiedadAbstracta: Int = 0
    
    constructor() {
        
    }
    
    override fun metodoAbstracto() {
        
    }
}
```

----
## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Kotlin
sealed class ClaseSellada {
    constructor() {
        
    }
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Kotlin
interface IInterfaz {
    val p1: Int // Propiedad abstracta

    val p2: Boolean // Propiedad regular con accesor
        get() = p1 > 0

    fun m1() // Método abstracto

    fun m2() { // Método regular
        print("Método implementado")
    }
}

class Ejemplo : IInterfaz {
    override val p1: Int  = 0
    
    override fun m1() {
        // Code
    }
}
```

# Conceptos Avanzados

## Liberacion de Memoria
Para evitar que el programa se quede sin memoria, la `JVM` tiene una funcion que se llama Garbage Collector que nos abstrae de la necesidad de tener que liberar la memoria a mano, no obstante, si queremos liberar o borrar la memoria podemos usar el siguiente metodo.

```Kotlin
System.gc()
```

---
## Enumerador
Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Kotlin
enum class TipoCarta {
    ORO,
    BASTO,
    COPA,
    ESPADA
}
```

---
## Indizadores
Son una propiedad que nos permite trabajar con un objeto como si fuera un array pudiendo acceder a los atributos del objeto mediante un `[index]`
```Kotlin
class PruebaIndexer {
    var lista = arrayOf<Int>(1, 2, 3, 4, 5, 6, 7, 8, 9, 0)
    
    operator fun get(index: Int) : Int {
        return lista.get(index)
    }
}

val prueba = PruebaIndexer()
prueba[0]
```

---
## yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común
```Kotlin
val lista = mutableListOf(1, 2, 3, 4, 5, 6, 7, 8, 9, 0)
var secuencia = sequence {
    yield(lista)
}

for(valor in secuencia) {
    println(valor)
}
```

---
## Generics
Los genéricos introducen en el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.
- Puede crear sus propias interfaces, clases, métodos, eventos y delegados genéricos.
- Puede limitar las clases genéricas para habilitar el acceso a métodos en tipos de datos determinados.
- Puede obtener información sobre los tipos que se usan en un tipo de datos genérico en tiempo de ejecución mediante la reflexión

```Kotlin
class ClaseGenerica<T>(t: T) {
    val propiedad: T = t

    fun metodo(param: T) {
        println(param)
    }
}
```

# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Kotlin
try{
    // Code
}catch(ex: Exception){
    println("Excepcion capturada")
}
```

### Provocando una excepcion
```Kotlin
throw NullPointerException("")
```

### Creando excepciones propias
```Kotlin
class MiExcepcion : Exception{
    constructor(message: String) : super(message) {
    }
}

try{
        throw MiExcepcion("")
    }catch(ex: Exception){
        println("Excepcion capturada")
    }
```

# Corrutinas
Una corrutina es un conjunto de sentencias que realizan una tarea específica, con la capacidad suspender o resumir su ejecución sin bloquear un hilo.

Esto permite que tengas diferentes corrutinas cooperando entre ellas, suspendiéndose y resumiéndose en puntos especificados por ti o por Kotlin.

No significa que exista un hilo por cada corrutina, al contrario, puedes ejecutar varias en un solo. Donde podrás crear tu propio procesamiento concurrente.

Este comportamiento de las corrutinas en Kotlin te permite:

- Reducir recursos del sistema al evitar la creación de grandes cantidades de hilos
- Facilitar el retorno de datos de una tarea asíncrona
- Facilitar el intercambio de datos entre tareas asíncronas


## Async/Await
La función `async{}` crea una corrutina y retorna su resultado futuro como una instancia de `Deferred<T>`.

`Deferred<T>` posee una función miembro denominada `await()`, la cual espera hasta que se ejecuten las sentencias (sin bloquear un hilo) y así entregar el valor de la corrutina.
```Kotlin
import kotlinx.coroutines.*

fun main() = runBlocking {
    val totalTime = async {
        val t0 = System.currentTimeMillis()
        (1..5).forEach {
            delay(300)
            println("¡Palabra $it encontrada!")
        }
        System.currentTimeMillis() - t0
    }
    println("Tiempo empleado: ${totalTime.await()}")
}
```

# LINQ
Linq es una API orientada al uso de consultas a diferentes tipos de contenido, como objetos, entidades, XML, etc. De esta manera se resume en una sintaxis sencilla y fácil de leer, tratar y mantener el tratamiento de diferentes tipos de datos.

## From

```Csharp
var cust = new List<Customer>();
//queryAllCustomers is an IEnumerable<Customer>
from cust in customers
select cust;
```
## Join

```Csharp
from category in categories
join prod in products on category.ID equals prod.CategoryID
select new
{
    ProductName = prod.Name,
    Category = category.Name
};

products.Join(categories,
product => product.CategoryID,
category => category.ID,
(product, category) => new
{
    ProductName = product.Name,
    Category = category.Name
});
```

## Let
```Csharp

from sentence in strings
let words = sentence.Split(' ')
from word in words
let w = word.ToLower()
where w[0] == 'a' || w[0] == 'e'
    || w[0] == 'i' || w[0] == 'o'
    || w[0] == 'u'
select word;
```

## Where
```Csharp
from prod in products
where prod.Name == "Producto 2"
select prod;
```                                                                                                                                                       
## Group by
```Csharp
from product in products
group product by new
{
    product.CategoryID,
    product.Name
} into prod
select new
{
    idCategoria = prod.Key.CategoryID,
    nombre = prod.Key.Name
};

products.GroupBy(product => new
{
    product.CategoryID,
    product.Name
}).Select(prod => new
{
    idCategoria = prod.Key.CategoryID,
    nombre= prod.Key.Name
});
```

## Order by
```Csharp
from product in products
orderby product.CategoryID ascending
select product;

products.OrderBy(product => product.CategoryID);

from product in products
orderby product.CategoryID descending
select product;
products.OrderByDescending(product => product.CategoryID);
```

Para poder tratar las consultas, la api de LINQ devuelve objetos del tipo `IEnumerable<>` o `IQueryable<>`.  
Hay diferentes formas de leer los datos, por un lado mediante un `foreach` se pueden iterar un `IEnumerable` y por otro lado, hay metodos que convierten los datos a una coleccion directamente.

## ToList
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToList();
```

## ToArray
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToArray();
```

## ToDictionary
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToDictionary(key => key.CategoryID, value => value.Name);
```

## ToLookup
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).ToLookup(key => key.CategoryID, value => value.Name);
```

## Count
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).Count()
 ```

## FirstOrDefault
```Csharp
(from prod in products
where prod.Name == "Producto 2"
select prod).FirstOrDefault()
 ```
