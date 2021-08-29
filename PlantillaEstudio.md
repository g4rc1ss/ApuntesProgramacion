# Estructura del código

```Lenguaje

```
- `` `` -> Para importar librerías y módulos

- `` `` -> indica la ubicación del programa

- `` `` -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.

- `` `` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

---
## Declaración de variables
```Lenguaje

```

---
## Tipos Nullables
Los tipos primitivos no pueden ser `null` por defecto, no obstante, si se requiere de hacer uso de null en dichos tipos, se pueden definir de la siguiente forma.
```Lenguaje

```

---
## Convertir tipos
```Lenguaje

```

----
## Sentencias de flujo
```Lenguaje

```

---
## Operador ternario
````Lenguaje

````

----
## Bucles
```Lenguaje

```

# Cadenas

## String


### Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| \\' | Comilla simple | 0x0027
| \\" | Comilla doble  | 0x0022
| \\\\ | Barra diagonal inversa | 0x005C
| \\0 | Null | 0x0000
| \\a | Alerta | 0x0007
| \\b | Retroceso | 0x0008
| \\f | Avance de página | 0x000C
| \\n | Nueva línea | 0x000A
| \\r | Retorno de carro | 0x000D
| \\t | Tabulación horizontal | 0x0009
| \\U | Secuencia de escape Unicode para pares suplentes. | \\Unnnnnnnn
| \\u | Secuencia de escape Unicode | \\u0041 = "A"
| \\v | Tabulación vertical | 0x000B
| \\x | Secuencia de escape Unicode similar a "\\u" | \\x0041 o \\x41 = "A"

### Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con las concatenaciones, pero es mas claro y mejor.
```Lenguaje

```

### Métodos de string
---

```Lenguaje
// Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
cadena.Replace(',', '\n');

// Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
cadena.Split('m');

// Devuelve el indice donde se encuentra el caracter indicado
cadena.IndexOf('m');

// Compara el string con otro objeto, como por ejemplo, otra cadena
cadena.CompareTo("Hola, yo me llamo Ralph");

// Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial
cadena.Substring(3, 5);
```

---
## StringBuilder
StringBuilder es una clase de cadena mutable. Mutabilidad significa que una vez creada una instancia de la clase, se puede modificar anexando, quitando, reemplazando o insertando caracteres. 

StringBuilder mantiene un búfer para alojar las modificaciones en la cadena.

Los datos nuevos se anexan al búfer si hay espacio disponible; de lo contrario, se asigna un búfer nuevo y mayor, los datos del búfer original se copian en el nuevo búfer y, a continuación, los nuevos datos se anexan al nuevo búfer.

```Lenguaje

```

# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas

Una lista es un tipo de colección ordenada(un array)

### Métodos de listas

```Lenguaje
var lista = new List<string>() { "Hola" };

// Agrega al ultimo elemento de la lista el objeto que se le pasa por parametro
lista.Add("me llamo Ralph");

// Devuelve la posicion de la lista donde se ubica el objeto a buscar
lista.IndexOf("Hola");

// Insertas en la posicion 1 el objeto que se quiere, si hay elementos en dicha posicion se mueven hacia la derecha, por tanto el de la 1 pasaria a la posicion 2
lista.Insert(1, "jajajajaja");

// Eliminar de la lista el objeto indicado
lista.Remove("me llamo Ralph");

// Ordenas la lista al contra
lista.Reverse();
```

---
## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede tener como máximo un valor en el diccionario

### Métodos de diccionarios

```Lenguaje
var diccionario = new Dictionary<string, string>()
{
    { "Clave", "Valor" },
    {"Key", "Value" }
};

// Devuelve una lista con las claves del diccionario
Dictionary<string, string>.KeyCollection claves = diccionario.Keys;

// Devuelve una lista con los valores del diccionario
Dictionary<string, string>.ValueCollection valores = diccionario.Values;

// Devuelve un bool indicando si la clave existe en el diccionario
diccionario.ContainsKey("Clave");

// Elimina la Key del diccionario y por tanto, los valores asociados a la misma
diccionario.Remove("Key");

// Metodo para obtener el valor asociado a la clave indicada
diccionario.TryGetValue("Key", out string valor);

```

----
## Tuplas
Una tupla es una estructura de datos que contiene una secuencia de elementos de diferentes tipos, esta estructura es de solo lectura, por tanto se usa para almacenar objetos que no van a ser modificados después.

```Lenguaje
var tupla = new Tuple<string, bool, int, double>("cadena", false, 500, 578.98);

tupla.Item1;
tupla.Item2;
tupla.Item3;
tupla.Item4;
```

----
## Tablas Hash
Representa una colección de pares de clave y valor que se organizan por código hash de la clave

### Métodos de tablas hash

```Lenguaje
var tablaHash = new Hashtable();

// Agrega un nuevo elemento con el par clave-valor
tablaHash.Add("Key", "Value");

// Elimina la Clave y el valor asociado a la misma
tablaHash.Remove("Key");

// Devuelve un bool para saber si contiene la clave
tablaHash.ContainsKey("Key");

// Limpia todos los elementos de la tabla
tablaHash.Clear();

// Para acceder al valor asociado a la clave mediante el inidizador
tablaHash["Key"];
```

----
## Pilas
El Stack es una coleccion LIFO(Last in, First Out) sin tamaño fijo de los objetos indicados.

Al usar la forma de almacenamiento LIFO, en la coleccion se trabaja todo el rato sobre los primeros elementos, osea que cuando agregas un elemento nuevo por ejemplo, no se guardaria en el ultimo indice, sino que se almacenaria en el indice 0, al principio de la coleccion.

### Métodos de pilas
```Lenguaje
var pila = new Stack<string>();
pila.Push("prueba de push");

// Agrega un nuevo elemento en la parte superior de Stack<T>
pila.Push("Elemento");

// Elimina un elemento de la parte superior
pila.Pop();

// Devuelve un eleemnto de la parte superior
pila.Peek();

// Limpia todos los elementos de la coleccion
pila.Clear();

// Convierte la pila en un array del tipo indicado
pila.ToArray();

pila.Contains("objeto");
```

----
## Colas
La Queue es una coleccion FIFO(First In, First Out).

Al usar la forma de almacenamiento FIFO, a la hora de agregar elementos se tendran que ir agregando al final de la coleccion y a la hora de trabajar con ellos, se iran extrayendo del mas antiguo al mas nuevo, por tanto, se accedera a los primeros.

### Métodos de colas
```Lenguaje
var cola = new Queue<string>();
cola.Enqueue("prueba de push");

// Agrega un nuevo elemento al final de la coleccion
cola.Enqueue("Elemento");

// Elimina el elemento mas antiguo, por tanto el primer elemento de la coleccion
cola.Dequeue();

// Devuelve el elemento mas antiguo de la coleccion
cola.Peek();

// Limpia todos los elementos de la coleccion
cola.Clear();

// Convierte la cola en un array del tipo indicado
cola.ToArray();

// Comprobamos si la coleccion contiene un objeto especifico
cola.Contains("objeto");
```

# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Lenguaje

```

---
## Static Class

La instruccion `static` se usa cuando se quiere el acceso a un metodo o propiedad sin que tenga que ser instanciada la clase.

```Lenguaje

```

## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Lenguaje

```

----
## Propiedades
Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los
campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se
ejecutan cuando se tiene acceso a una propiedad o se asigna.
```Lenguaje

```

----
## Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

Imaginemos que podemos crear un método, almacenarlo en un objeto y pasarlo como parámetro de una función, pues en eso consiste.
```Lenguaje

```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Lenguaje

```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Lenguaje

```

----
## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Lenguaje

```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

```Lenguaje

```

# Conceptos Avanzados

## Liberacion de Memoria
Para evitar que el programa se quede sin memoria, la `JVM` tiene una funcion que se llama Garbage Collector que nos abstrae de la necesidad de tener que liberar la memoria a mano, no obstante, si queremos liberar o borrar la memoria podemos usar el siguiente metodo.

```Lenguaje

```

---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Lenguaje

```

---
## Indizadores
Son una propiedad que nos permite trabajar con un objeto como si fuera un array pudiendo acceder a los atributos del objeto mediante un `[index]`
```Lenguaje

```

---
## yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común
```Lenguaje

```

---
## Boxing y Unboxing
Todos los tipos de C# directa o indirectamente se derivan del tipo de clase object, y object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Lenguaje

```

---
## Dynamic
Cuando creamos una variable debemos indicar el tipo de variable que va a ser, o podemos utilizar la palabra clave var, la cual se convertirá en tiempo de compilación en el tipo de variable - la cual denominamos variable implícita -

En el caso de las variables dinámicas, en vez de determinar su valor en tiempo de compilación se determina durante el tiempo de ejecución, o runtime.

Cuando el compilador pasa por la variable lo que hace es convertir en tipo en un tipo Object en la gran mayoría de los casos. 

Lo que quiere decir que cada vez que le asignamos un valor, cambiará también el tipo de variable que es el objeto, podemos verlo utilizando la siguiente línea de código:
```Lenguaje

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

```Lenguaje

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

```Lenguaje

```

---
## Codigo no Administrado
El codigo no administrado es un tipo de codigo al que no puede acceder el `Garbage Collector` para realizar el proceso de limpieza de memoria, por tanto hay que hacerlo manualmente.

### 
Es una tecnologia que permite hacer uso de librerias compiladas de forma nativa con lenguajes como `Rust`, `Cpp`, etc.  
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

```Lenguaje

```

### Codigo inseguro
La mayor parte del código que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas del lenguaje pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

Este modo es un tipo de [Codigo no Administrado](#codigo-no-administrado) puesto que a este codigo no acceden las herramientas para liberar el espacio de memoria que ocupan por ejemplo.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

#### Punteros

```Lenguaje

```

En la tabla siguiente se muestran los operadores e instrucciones que pueden funcionar en punteros en un contexto no seguro:

| Operador/Instrucción | Usar |
| -------------------- | ---- |
| | | |


# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Lenguaje

```

### Provocando una excepcion
```Lenguaje

```

### Creando excepciones propias
```Lenguaje

```

---
# Programación Asincrona & MultiThreading

## 


```Lenguaje

```

---
## Paralelismo
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer uso de la clase Parallel para realizar esas consultas de forma paralelizada y reducir los tiempos.

### Ejecucion de metodos paralelamente
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Lenguaje

```

### Recorrer un bucle de forma paralela
Permite la ejecucion paralelizada de la lectura de una coleccion

```Lenguaje

```

# Comprension de Listas


## 

```Lenguaje

```
