# Estructura del código

```Csharp
using System;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }
}
```
- ``using`` -> Para importar librerías y módulos

- ``namespace`` -> indica la ubicación del programa

- ``class`` -> Creamos una clase, que es un modulo que se usa para declarar objetos y tratarlos añadiendo funciones.

- ``Main(string[] args)`` -> el método main es el método principal de donde parte la aplicación siempre, no puede haber dos main en el mismo proyecto

---
## Declaración de variables
```Csharp
string a = "hoa";
int b = 2;
double c = 2.0;
bool d = false;
var x = "h";
const int CONSTANTE = 2;
```
- `var` Se usa para no tener que indicar el tipo de la variable, lo detecta automaticamente
- `const` Se usa para establecer un valor que no puede ser modificado

---
## Convertir tipos
```Csharp
Convert.ToInt32(2.0); // 2
Convert.ToBoolean(1); // true
```
Para convertir a otros tipos se puede hacer uso de la clase estatica `Convert` como el ejemplo de arriba

----
## Sentencias de flujo
```Csharp
if (true)
{
}
else if (true)
{
}
else
{
}

switch (opt)
{
    case var option when option.Equals(Opt.Adios):
        break;
    case "Hola":
        break;
    default:
        break;
}
```

---
## Operador ternario
````Csharp
"x".StartsWith('d') ? "Empieza por D" : "Pues no, no empieza por d";
lista?.Count; lista[0]?.Trim();
lista ?? new List<string>();

````
- En el operador ternario se realiza la comprobacion de un `bool` y se agregan dos simbolos, el `?` cuando se cumple la condicion y los `:` si no se cumple dicha condicion
- El uso de `?.` o `[0]?` Se usa para comprobar si el contenido es null y si es asi, se va "arrastrando" el null, osea que en este caso, si `lista` es null, no se comprobaria `.count` y se devolveria null
- El uso de `??` es una comprobacion resumida de un operador ternario para comprobar null, la instruccion es que si `list` es null, se ejecute `new List<string>`

----
## Bucles
```Csharp
while (true)
{
}

do
{
} while (true);

for (int i = 0; i < 90; i++)
{
}

foreach (var item in new List<string>())
{
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
| \a | Alerta | 0x0007
| \b | Retroceso | 0x0008
| \f | Avance de página | 0x000C
| \n | Nueva línea | 0x000A
| \r | Retorno de carro | 0x000D
| \t | Tabulación horizontal | 0x0009
| \U | Secuencia de escape Unicode para pares suplentes. | \Unnnnnnnn
| \u | Secuencia de escape Unicode | \u0041 = "A"
| \v | Tabulación vertical | 0x000B
| \x | Secuencia de escape Unicode similar a "\u" | \x0041 o \x41 = "A"

### Interpolacion de Cadenas
---
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con el método `String.Format`, pero mejora la facilidad de uso y la claridad en línea.
```csharp
var saludo = "Hola";
Console.WriteLine($"{saludo} terricola");
```

### Métodos habituale
---

```csharp
var cadena = "Hola, yo me llamo Ralph, que tal estamos?";

// Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
var cadenaReplace = cadena.Replace(',', '\n');

// Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
var cadenaSplit = cadena.Split('m');

// Devuelve el indice donde se encuentra el caracter indicado
var cadenaIndex = cadena.IndexOf('m');

// Compara el string con otro objeto, como por ejemplo, otra cadena
var cadenaCompare = cadena.CompareTo("Hola, yo me llamo Ralph");

// Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial
var cadenaSubString = cadena.Substring(3, 5);
```

---
## StringBuilder
StringBuilder es una clase de cadena mutable. Mutabilidad significa que una vez creada una instancia de la clase, se puede modificar anexando, quitando, reemplazando o insertando caracteres. 

StringBuilder mantiene un búfer para alojar las modificaciones en la cadena.

Los datos nuevos se anexan al búfer si hay espacio disponible; de lo contrario, se asigna un búfer nuevo y mayor, los datos del búfer original se copian en el nuevo búfer y, a continuación, los nuevos datos se anexan al nuevo búfer.

```Csharp
var stringBuilder = new StringBuilder();
stringBuilder.Append(true);
stringBuilder.Append("Terminado");
stringBuilder.Replace("Hola", "Adios");
var cadenaCompleta = stringBuilder.ToString();
```

---
# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas:

Una lista es un tipo de colección ordenada(un array)

### Métodos habituales

```Csharp
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
## Diccionarios:

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede 
tener como máximo un valor en el diccionario

### Métodos habituales

```Csharp
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

```Csharp
var tupla = new Tuple<string, bool, int, double>("cadena", false, 500, 578.98);

tupla.Item1;
tupla.Item2;
tupla.Item3;
tupla.Item4;
```

----
## Tablas Hash
Representa una colección de pares de clave y valor que se organizan por código hash de la clave

### Métodos habituales

```Csharp
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

### Métodos habituales
```Csharp
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

### Métodos habituales
```Csharp
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

---
# Programación Orientada a Objetos

## Class

Una clase es una estructura de datos que combina estados (campos) y acciones (métodos y otros miembros de función) en una sola unidad. 

De una clase se pueden hacer instancias de objetos para usar sus metodos, propiedades, etc. Y de esta forma, poder reutilizar codigo.

Las clases admiten herencia y polimorfismo, mecanismos por los que las clases derivadas pueden extender y especializar clases base.

```Csharp
//[access modifier] - [class] - [identifier]
public class Customer 
{
   // Fields, properties, methods and events go here...
}
```

---
## Static Class

La instruccion `static` se usa cuando se quiere el acceso a un metodo o propiedad sin que tenga que ser instanciada la clase.

Las clases estaticas estan bien usarlas cuando los datos almacenados no requieren de ser unicos o la clase no requiere de almacenar datos en si.
por ejemplo, la libreria `Convert` de .Net solo realiza conversion de tipos, no requiere de almacenar dicha conversion.

```Csharp
public static class A 
{
    public static void Metodo()
    {
    }
}
```

---
## Abstract Class

No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base completamente funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase que herede de la abstracta.

```Csharp
internal abstract class A
{
    private void MetodoFuncional() => Console.WriteLine("");

    internal abstract void MetodoNoFuncional(string parametro);
}

internal class B : A
{
    internal override void MetodoNoFuncional(string parametro) => throw new NotImplementedException();
}
```

----
## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Csharp
sealed class SealedClass
{
}

```

----
## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Csharp
//[access modifier] - [type] - [identifier]
private void Metodo()
{
    _ = Console.WriteLine("");
}

private string MetodoConReturn()
{
    return string.Empty;
}
```

----
## Propiedades
Las propiedades se comportan como campos cuando se obtiene acceso a ellas. Pero, a diferencia de los
campos, las propiedades se implementan con descriptores de acceso que definen las instrucciones que se
ejecutan cuando se tiene acceso a una propiedad o se asigna.
```Csharp
// Propiedad automatica
public string propiedad { get; set; }
// Definiendo el propio almacenamiento
private string _propiedadDos;
public string propiedadDos {
    get { return _propiedadDos; }
    set { _propiedadDos = value; }
}
```

----
## Delegados
Un delegate es un tipo de referencia que puede utilizarse para encapsular un método con nombre o anónimo.

Imaginemos que podemos crear un método, almacenarlo en un objeto y pasarlo como parámetro de una función, pues en eso consiste.
```Csharp

internal void MetodoDelegado(List<string> coleccion, Action<string> delegado)
{
    foreach (var item in coleccion)
    {
        delegado?.Invoke(item);
    }
}

clase.MetodoDelegado(new List<string>() { "Hola", "Adios" }, (x) =>
{
    Console.WriteLine(x.Contains("Ho"));
});
```

---
## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Csharp
public class Clase : SuperClase 
{
}
```

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

```Csharp
interface IMiInterfaz
{
    void MiMetodo();
}

public class PruebaInterfazImplícita : IMiInterfaz 
{
    public void MiMetodo() 
    {    
    }
}
```

---
# Conceptos Avanzados

## Liberacion de Memoria



---
## Enumerador

Una enumeración es un conjunto de constantes enteras que tienen asociado un nombre para cada valor.

El objetivo fundamental de implementar una enumeración es facilitar la legibilidad de un programa.
Supongamos que necesitamos almacenar en un juego de cartas el tipo de carta actual (oro, basto, copa o espada), podemos definir una variable entera y almacenar un 1 si es oro, un 2 si es basto y así sucesivamente.
Luego mediante if podemos analizar el valor de esa variable y proceder de acuerdo al valor existente.

```Csharp
public enum EnumeradorCartas {
    oro,
    basto,
    copa,
    espada
}
```

---
## Indizadores

```Csharp
```

---
## Boxing y Unboxing

```Csharp
```

---
## Generics

```Csharp
```

---
# Tratamiento de Excepciones

## Excepciones
Las excepciones son errores durante la ejecución del programa y lo que se hace es intentar solucionar el error o mostrar un mensaje mas claro sobre el problema al usuario, por ejemplo: se necesita ser super usuario, se esta dividiendo entre 0, no hay conexión a internet...

```Csharp

```

---
# Programación Asincrona & MultiThreading

## Async & Await

```Csharp
```

---
## Parallel

```Csharp
```

---
# LINQ