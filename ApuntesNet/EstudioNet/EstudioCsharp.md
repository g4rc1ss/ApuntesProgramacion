# Estructura del código

```Csharp
using System;

namespace ProgramNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            // Code...
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
## Tipos Nullables
Los tipos primitivos no pueden ser `null` por defecto, no obstante, si se requiere de hacer uso de null en dichos tipos, se pueden definir de la siguiente forma.
```Csharp
int? numero = null;
Nullable<int> = null;
```

---
## Convertir tipos
Para convertir a otros tipos se puede hacer uso de la clase estatica `Convert` como el ejemplo de arriba
```Csharp
Convert.ToInt32(2.0); // 2
Convert.ToBoolean(1); // true
```

---
## Boxing y Unboxing
Todos los tipos de C# directa o indirectamente se derivan del tipo de clase object, y object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Csharp
int i = 123;
object o = i; // Boxing
int j = (int)o; // Unboxing
```

---
## Dynamic
Cuando creamos una variable debemos indicar el tipo de variable que va a ser, o podemos utilizar la palabra clave var, la cual se convertirá en tiempo de compilación en el tipo de variable - la cual denominamos variable implícita -

En el caso de las variables dinámicas, en vez de determinar su valor en tiempo de compilación se determina durante el tiempo de ejecución, o runtime.

Cuando el compilador pasa por la variable lo que hace es convertir en tipo en un tipo Object en la gran mayoría de los casos. 

Lo que quiere decir que cada vez que le asignamos un valor, cambiará también el tipo de variable que es el objeto, podemos verlo utilizando la siguiente línea de código:
```Csharp
// Se inicializa tipo int
dynamic variableDinamica = 1;
// Se le asigna tipo string
variableDinamica = "test";

// Para obtener el tipo de la variable
variableDinamica.GetType().ToString();
```

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

---
## Sobreescribir Operadores
Un tipo definido por el usuario puede sobrecargar un operador de C# predefinido. Es decir, un tipo puede proporcionar la implementación personalizada de una operación cuando uno o los dos operandos son de ese tipo
````Csharp
class ClaseConOperadores
{
    public decimal NumeroOperar { get; set; }
    public ClaseConOperadores(decimal numeroOperar)
    {
        NumeroOperar = numeroOperar;
    }

    public static ClaseConOperadores operator +(ClaseConOperadores a, ClaseConOperadores b)
    {
        return new ClaseConOperadores(a.NumeroOperar + b.NumeroOperar);
    }

    public static ClaseConOperadores operator -(ClaseConOperadores a, ClaseConOperadores b)
    {
        return new ClaseConOperadores(a.NumeroOperar - b.NumeroOperar);
    }

    public static ClaseConOperadores operator *(ClaseConOperadores a, ClaseConOperadores b)
    {
        return new ClaseConOperadores(a.NumeroOperar * b.NumeroOperar);
    }

    public static ClaseConOperadores operator /(ClaseConOperadores a, ClaseConOperadores b)
    {
        return new ClaseConOperadores(a.NumeroOperar / b.NumeroOperar);
    }

    public override bool Equals(object obj) => base.Equals(obj);
    public override int GetHashCode() => base.GetHashCode();
    public override string ToString() => $"{NumeroOperar}";
}
````


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

# Cadenas

## String
Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

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
| \\x | Secuencia de escape Unicode similar a "\u" | \x0041 o \x41 = "A"

### Interpolacion de Cadenas
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con el método `String.Format`, pero mejora la facilidad de uso y la claridad en línea.
```csharp
var saludo = "Hola";
Console.WriteLine($"{saludo} terricola");
```

### Métodos de string

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

# Colecciones
Las colecciones proporcionan una manera más flexible de trabajar con grupos de objetos. A diferencia de las matrices, el grupo de objetos con el que trabaja puede aumentar y reducirse de manera dinámica a medida que cambian las necesidades de la aplicación

---
## Listas

Una lista es un tipo de colección ordenada(un array)

### Métodos de listas

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
## Diccionarios

Una clase de Diccionario es una estructura de datos que representa una colección de 
claves y valores de pares de datos. La clave es idéntica en un par clave-valor y puede 
tener como máximo un valor en el diccionario

### Métodos de diccionarios

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

### Métodos de tablas hash

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

### Métodos de pilas
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

### Métodos de colas
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

---
## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Se implementan como clases y se definen como entidades separadas de las clases.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido

El beneficio que da las interfaces es que permite tener una capa de abstraccion en el codigo, donde puedes hacer uso de ella para ejecutar ciertas clases usando la interfaz como instancia.

Por ejemplo una de las cosas que se consiguen mediante las interfaces es la api Linq, Linq hace uso de la interfaz `IEnumerable` para procesar los datos, por tanto, si yo ahora creo una coleccion mia propia que implemente dicha interfaz, podre hacer uso de las funciones de consulta de LINQ y todo es porque la api lo que espera recibir es una clase que tenga implementada esa interfaz.
La interfaz tiene una serie de metodos implementados y Linq hace uso de ellos para leer y procesar la coleccion.

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
## Polimorfismo
Es la capacidad que tiene una clase en convertirse en un nuevo objeto sin cambiar su esencia y luego volver al objeto origina de donde salió.

Hay tres tipos de polimorfismo:
- Polimorfismo por Herencia: Cuando se hereda de una clase normal y puedo convertirme en ella.
- Polimorfismo por Abstraccion: Cuando puedo heredar de una clase abstracta y puedo convertirme en ella.
- Polimorfismo por Interface: Es la posibilidad que tenemos de implementar una interface y puedo convertirme en ella.

### Polimorfismo por Herencia
Este tipo de polimorfismo es el mas común que existe, y tiene la facultad de heredar de una clase padre y reemplazarla.

```Csharp
class Padre
{
    public virtual void Escribiendo()
    {
        Console.WriteLine("Escribiendo el Padre");
    }
}

class Hijo : Padre
{
    public override void Escribiendo()
    {
        Console.WriteLine("Escribiendo el hijo");
    }
}

static void Main(string[] args)
{
    // Insertamos la clase hijo en la clase Padre
    Padre papa = new Hijo();
    papa.Escribiendo();
}
```

### Polimorfismo por Abstraccion
Este tipo de polimorfismo se da con el uso de las clases abstractas. Pero que es una clase abstracta es aquella que además de lo normal que contiene una clase tiene comportamientos que si están definidos pero no implementados.

```Csharp
abstract class Padre
{
    public abstract void Escribiendo();
}

class Hijo : Padre
{
    public override void Escribiendo()
    {
        Console.WriteLine("Escribiendo el hijo");
    }
}

static void Main(string[] args)
{
    // La clase hijo sobreescribe el metodo abstracto y lo insertamos a la clase padre.
    Padre papa = new Hijo();
    papa.Escribiendo();
}
```

### Polimorfismo por Interface
Es uno de los polimorfismos mas importantes por que esta basado por contratos, que son los encargados de decirme que puedo hacer o no y como debo de hacerlo.

```Csharp
interface IPadre
{
    void Escribiendo();
}

class Hijo : IPadre
{
    public void Escribiendo()
    {
        Console.WriteLine("Escribiendo el hijo");
    }
}

static void Main(string[] args)
{
    IPadre papa = new Hijo();
    papa.Escribiendo();
}
```

# Tratamiento de Excepciones

## Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

### Capurando las excepciones
```Csharp
try
{
    // Ejecucion del codigo que puede llegar a tener una excepcion
}
catch (Exception ex)
{
    // Se ha producido la excepcion y se obtiene un objeto de tipo Exception
    // Este objeto contiene unos valores para rastrear el motivo del error
}
finally
{
    // Esta es una parte del codigo que se ejecuta siempre aunque se produzca la excepcion
    // Y generalmente se usa para cerrar recursos, por ejemplo, abres una conexion con
    // la base de datos y a la hora de recibir los datos se produce la excepcion,
    // pues pasara por aqui para cerrar la conexion con la base de datos.
}
```

### Provocando una excepcion
```Csharp
public static void Main(string[] args)
{
    throw new ArgumentNullException($"El parametro {nameof(args)} es nulo");
}
```

### Creando excepciones propias
```Csharp
class MyException : Exception
{
    public MyException() : base()
    {
    }

    public MyException(string message) : base(message)
    {
    }

    public MyException(string message, Exception innerException) : base(message, innerException)
    {
    }

    protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
```

# Conceptos Avanzados

## Atributos
Los atributos proporcionan un método eficaz para asociar metadatos, o información declarativa, con código (ensamblados, tipos, métodos, propiedades, etc.). Después de asociar un atributo con una entidad de programa, se puede consultar el atributo en tiempo de ejecución mediante la utilización de una técnica denominada reflexión.

Los atributos tienen las propiedades siguientes:

- Los atributos agregan metadatos al programa. Los metadatos son información sobre los tipos definidos en un programa.
- Puedes aplicar uno o más atributos a todos los ensamblados, módulos o elementos de programa más pequeños como clases y propiedades.
- Los atributos pueden aceptar argumentos de la misma manera que los métodos y las propiedades.
- El programa puede examinar sus propios metadatos o los metadatos de otros programas mediante la reflexión.

```Csharp
internal class AtributoPersonalizado : Attribute
{
    public string Text { get; set; }

    public AtributoPersonalizado(string text)
    {
        Text = text;
    }
}

public enum Enumerador
{
    [AtributoPersonalizado("Hola")]
    one
}
```

---
## Indizadores
Permiten crear una clase, un struct o una interfaz con un "indice" al que se accederá a traves del objeto instanciado de la clase, no hace falta acceder a la matriz como tal.
```Csharp
public class ClaseIndex
{
    private readonly float[] temps = new float[10] { 56.2F, 56.7F, 56.5F, 56.9F, 58.8F,
                                            61.3F, 65.9F, 62.1F, 59.2F, 57.5F };
    public float this[int index] {
        get {
            return temps[index];
        }
        set {
            temps[index] = value;
        }
    }
    public int Contador {
        get {
            return temps.Length;
        }
    }
}

public static void Main(string[] args)
{
    var objetoIndice = new ClaseIndex();

    objetoIndice[1] = 58.3F;
    objetoIndice[5] = 98.4F;

    for (int x = 0; x < objetoIndice.Contador; x++)
        Console.WriteLine(objetoIndice[x]);
}
```

---
## Yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común
```Csharp
public class Coche
{
    public IEnumerable<string> FiltrarCochesGetNombresYield(List<Coche> coches)
    {
        foreach (Coche coche in coches)
        {
            if (coche.Marca == MarcaCcohe.Opel)
            {
                yield return coche.Modelo;
            }
        }
    }
}

List<Coche> coches = new List<Coche>()
{
    new Coche(MarcaCcohe.Audi, "A3"),
    new Coche(MarcaCcohe.Audi, "A5"),
    new Coche(MarcaCcohe.Opel, "Vectra"),
    new Coche(MarcaCcohe.Opel, "Astra"),
};


foreach (string modelo in FiltrarCochesGetNombresYield(coches))
{
    Console.WriteLine($"El modelo del cohce es {modelo}");
}
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

```Csharp
class ClaseGenerica<T> where T : class, IEnumerable, new()
{
    public void Add(T input)
    {
    }
}

class ClaseIEnumerable : IEnumerable
{
    public ClaseIEnumerable()
    {

    }

    public IEnumerator GetEnumerator() => throw new NotImplementedException();
    IEnumerator IEnumerable.GetEnumerator() => throw new NotImplementedException();
}
```

### Constraints
Los constraints son condiciones que deben de cumplir el parametro que se le pasa al generic para que funcione.

| Constraint | Descripción |
| ---------- | ----------- |
| class | El argumento de tipo debe ser cualquier clase, interfaz, delegado o tipo de matriz. |
| class? |	El argumento de tipo debe ser una clase, interfaz, delegado o tipo de matriz que acepte valores NULL o que no acepte valores NULL. |
| struct | El argumento de tipo debe ser tipos de valor que no aceptan valores NULL, como los tipos de datos primitivos int, char, bool, float, etc.
| new() |	El argumento de tipo debe ser un tipo de referencia que tenga un constructor público sin parámetros. No se puede combinar con restricciones. `struct unmanaged`
| notnull |	Disponible en C# 8.0 en adelante. El argumento de tipo puede ser tipos de referencia que no aceptan valores NULL o tipos de valor. Si no es así, el compilador genera una advertencia en lugar de un error.
| unmanaged | El argumento de tipo debe ser tipos no permitidos queno aceptan valores NULL.
| baseClassName | El argumento de tipo debe ser o derivar de la clase base especificada. Las clases Object, Array, ValueType no se pueden como restricción de clase base. Enum, Delegate, MulticastDelegate no se admiten como restricción de clase base antes de C# 7.3.
| baseClassName? | El argumento de tipo debe ser o derivar de la clase base especificada que acepta valores NULL o que no acepta valores NULL.
| interfaceName | El argumento de tipo debe ser o implementar la interfaz especificada.
| interfaceName? | El argumento de tipo debe ser o implementar la interfaz especificada. Puede ser un tipo de referencia que acepta valores NULL, un tipo de referencia que no acepta valores NULL o un tipo de valor.
| where T: U | El argumento de tipo proporcionado para `T` debe ser o derivar del argumento proporcionado para `U`.

---
## Eventos
Un evento es un mensaje que envía un objeto cuando ocurre una acción.

Los eventos se realizan a mano en el codigo y son contenedores de un metodo Delegado que es el que se va a invocar.

Por ejemplo al interactuar con una interfaz de escritorio, como WPF, se crea un objeto Button y se agrega al evento `Click` el metodo que se ha de ejecutar `Button_Click(object sender, RoutedEventArgs e)`  
Por debajo lo que hace el codigo es detectar cuando se pulsa el boton y entonces, invoca el evento el cual tiene agregar como delegado el metodo que hemos escrito.

Para crear y controlar un evento se realiza el siguiente codigo:

```Csharp
public static event EventHandler ExportEvent;

public static void ExportEventCaller(ExportObject export)
{
    // El constructor de EventHandler recibe dos objetos, un object y un EventArgs
    ExportEvent?.Invoke(export, null);
}


ExportAPI.ExportEvent += LoadEventCall;
// LoadEventCall es el metodo que se va a ejecutar
```

---
## Codigo no Administrado
El codigo no administrado es un tipo de codigo al que no puede acceder el `Garbage Collector` para realizar el proceso de limpieza de memoria, por tanto hay que hacerlo manualmente.  
Para eliminar los recursos no administrados se suele hacer uso de la interfaz `IDisposable` o el uso de destructores explicado en la seccion [Liberación de memoria](#liberacion-de-memoria)

### P/Invoke 
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

```Csharp
[DllImport("libreriaEjemploRust.dll")]
private static extern int add_numbers(int number1, int number2);

public static void Main(string[] args)
{
    int suma = add_numbers(1, 2);
    Console.WriteLine(suma);
}
```

### Codigo inseguro
La mayor parte del código de C# que se escribe es "código seguro comprobable". El código seguro comprobable significa que las herramientas de .NET pueden comprobar que el código es seguro. En general, el código seguro no accede directamente a la memoria mediante punteros. Tampoco asigna memoria sin procesar. En su lugar, crea objetos administrados.

Este modo es un tipo de [Codigo no Administrado](#codigo-no-administrado) puesto que a este codigo no acceden las herramientas de .Net para liberar el especio de memoria que ocupan por ejemplo.

El código no seguro tiene las propiedades siguientes:

- Los métodos, tipos y bloques de código se pueden definir como no seguros.
- En algunos casos, el código no seguro puede aumentar el rendimiento de la aplicación al eliminar las comprobaciones de límites de matriz.
- El código no seguro es necesario al llamar a funciones nativas que requieren punteros.
- El código no seguro presenta riesgos para la seguridad y la estabilidad.
- El código que contenga bloques no seguros deberá compilarse con la opción del compilador AllowUnsafeBlocks.

#### Punteros
- `int* p`: p es un puntero a un entero.
- `int** p`: p es un puntero a un puntero a un entero.
- `int*[] p`: p es una matriz unidimensional de punteros a enteros.
- `char* p`: p es un puntero a un valor char.
- `void* p`: p es un puntero a un tipo desconocido.

```Csharp
unsafe
{
    int[] numeroParaFixed = new int[5] { 3000, 2000, 1, 2, 3 };
    // La instrucción fixed evita que el recolector de elementos no utilizados reubique una variable móvil.
    fixed (int* variable = &numeroParaFixed[0])
    {
        int* numero = variable;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);

        *numero += 2;
        Console.WriteLine(*numero);
    }
}
```

En la tabla siguiente se muestran los operadores e instrucciones que pueden funcionar en punteros en un contexto no seguro:

| Operador/Instrucción | Usar |
| -------------------- | ---- |
| *  | Realiza el direccionamiento indirecto del puntero. |
| -> |	Obtiene acceso a un miembro de un struct a través de un puntero. |
| [] | Indiza un puntero. |
| &  | Obtiene la dirección de una variable. |
| ++ y -- |	Incrementa y disminuye los punteros. |
| + y - | Realiza aritmética con punteros. |
| ==, !=, <, >, <= y >= | Compara los punteros. |
| stackalloc | Asigna memoria en la pila. |
| Instrucción fixed | Fija provisionalmente una variable para que pueda encontrarse su dirección. |

Mas informacion sobre codigo no seguro: [enlace](https://docs.microsoft.com/es-es/dotnet/csharp/language-reference/unsafe-code)

---
## Liberacion de Memoria
La liberacion de memoria en .Net consiste en marcar ciertos objetos como "liberados", quiere decir, que son objetos que ya no se van a volver a usar y que quiere liberar el recurso que se esta usando o cerrar el proceso.

Para dicha liberacion se ha de implementar una interfaz, que se llama `IDisposable` y tambien se suele hacer uso de los llamado Destructores.

El método Dispose se implementa para liberar recursos de la clase donde se implementa, sobretodo se usa para gestión de código no administrado como usos como conexiones a BBDD, Streams, etc.

```Csharp
public void Dispose()
{
    this.Dispose(true);
    GC.SuppressFinalize(this);
}

protected virtual void Dispose(bool disposing)
{
    if (disposing)
    {
        // Liberamos los recursos
        // En un clase como stream por ejemplo, aqui se ejecutaria el metodo Close()
    }
}
```

En todas las clases que tengan implementada la interfaz `IDisposable` se puede usar la instruccion `using` para liberar los recursos automaticamente cuando se acaba la sentencia.

```Csharp
using (var objeto = File.Create(""))
{
    objeto.ToString();
}

using var @object = File.Create("");
```

Los finalizadores (también denominados destructores) se usan para realizar cualquier limpieza final necesaria cuando el recolector de basura va a liberar el objeto de memoria

- Los finalizadores no se pueden definir en struct. Solo se usan con clases.
- Una clase solo puede tener un finalizador.
- Los finalizadores no se pueden heredar ni sobrecargar.
- No se puede llamar a los finalizadores. Se invocan automáticamente.
- Un finalizador no permite modificadores ni tiene parámetros.

```Csharp
internal class Program
{
    ~Program()
    {
        // Instrucciones para la limpieza de recursos
    }
}
```

---
## Serializacion
La serialización es el proceso de convertir un objeto en una secuencia de bytes para almacenarlo o transmitirlo a la memoria, a una base de datos o a un archivo. Su propósito principal es guardar el estado de un objeto para poder volver a crearlo cuando sea necesario. El proceso inverso se denomina deserialización.

```Csharp
public class ClaseSerializacion
{
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    private string CuentaBancaria { get; set; }

    public ClaseSerializacion()
    {
    }

    public ClaseSerializacion(string nombre, string apellidos, string cuentaBancaria)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
        CuentaBancaria = cuentaBancaria ?? throw new ArgumentNullException(nameof(cuentaBancaria));
    }
}
```

### Archivo JSON
La serialización de JSON serializa las propiedades públicas de un objeto en una cadena, una matriz de bytes, etc.

#### Serializar JSON
```Csharp
static void Main(string[] args)
{
    var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
    var serializado = System.Text.Json.JsonSerializer.Serialize(serializacion);
}
```

#### Deserializar JSON
```Csharp
static void Main(string[] args)
{
    const string JSON = @"{""Nombre"":""Nombre"",""Apellidos"":""Apellido""}";
    var deserializado = System.Text.Json.JsonSerializer.Deserialize<ClaseSerializacion>(JSON);
}
```

### Archivo XML
La serialización XML serializa las propiedades y los campos públicos de un objeto o los parámetros y valores devueltos de los métodos en una secuencia XML que se ajusta a un documento específico del lenguaje de definición de esquema XML (XSD). La serialización XML produce clases fuertemente tipadas cuyas propiedades y campos públicos se convierten a XML.

#### Serializar XML
```Csharp
static void Main(string[] args)
{
    var serializacion = new ClaseSerializacion("Nombre", "Apellido", "cuentaaaa bancariaaaa");
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ClaseSerializacion));
    using var file = System.IO.File.Create("Archivo.xml");
    xmlSerializer.Serialize(file, serializacion);
}
```

#### Deserializar XML
```Csharp
static void Main(string[] args)
{
    var xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ClaseSerializacion));
    using var file = System.IO.File.OpenRead("Archivo.xml");
    var objetoDeserializado = xmlSerializer.Deserialize(file);
}
```

---
## Reflexion
`Reflection` proporciona objetos (de tipo `Type`) que describen los ensamblados, módulos y tipos. Puedes usar reflexión para crear dinámicamente una instancia de un tipo, enlazar el tipo a un objeto existente u obtener el tipo desde un objeto existente e invocar sus métodos, o acceder a sus campos y propiedades. Si usas atributos en el código, la reflexión le permite acceder a ellos.

```Csharp
interface IClaseReflexion
{
    string Nombre { get; set; }
}

interface IClaseReflexionDos : IClaseReflexion
{
    string Apellidos { get; set; }
}

public class ClaseReflexion : IClaseReflexionDos
{
    [Prueba("Hola", NamedInt = 5000)]
    public string Nombre { get; set; }
    public string Apellidos { get; set; }
    private string CuentaBancaria { get; set; }


    public ClaseReflexion()
    {
    }

    public ClaseReflexion(string nombre, string apellidos, string cuentaBancaria)
    {
        Nombre = nombre ?? throw new ArgumentNullException(nameof(nombre));
        Apellidos = apellidos ?? throw new ArgumentNullException(nameof(apellidos));
        CuentaBancaria = cuentaBancaria ?? throw new ArgumentNullException(nameof(cuentaBancaria));
    }
}

[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
internal sealed class PruebaAttribute : Attribute
{
    // See the attribute guidelines at 
    //  http://go.microsoft.com/fwlink/?LinkId=85236
    private readonly string positionalString;

    // This is a positional argument
    public PruebaAttribute(string positionalString)
    {
        this.positionalString = positionalString;
    }

    public string PositionalString {
        get { return positionalString; }
    }

    // This is a named argument
    public int NamedInt { get; set; }
}


var obtenerTodasInterfaces = from interfaz in Assembly.GetExecutingAssembly().GetTypes()
                             where interfaz.IsInterface
                             select interfaz;
var obtenerClaseImplementaInterface = from clase in Assembly.GetExecutingAssembly().GetTypes()
                                      where clase.IsClass && clase.GetInterface(nameof(IClaseReflexion)) != null
                                      select clase;
var leerAtributosDePropiedades = from propiedad in typeof(ClaseReflexion).GetProperties()
                                 let atributo = propiedad.GetCustomAttribute<PruebaAttribute>()
                                 where atributo != null
                                 select atributo;
```

# Programación Asincrona
La programacion asincrona se realiza cuando se quieren evitar bloqueos en el hilo principal de la aplicación, cuando se realiza una operacion que requiere tiempo de procesamiento, el hilo sobre el que se esta ejecutando se bloquea hasta que termine, eso causa que la aplicacion no responda a mas operaciones.

Por ejemplo, en una interfaz Desktop, si se usa el patron en las operaciones costosas, la interfaz no se bloqueará mientras se ejecutan las instrucciones.  
En una aplicacion web como `ASP.NET` usar el patron hara que se puedan recibir mas peticiones mientras las peticiones anteriores estan en espera de que termine el proceso que ocupa tiempo, como por ejemplo, una consulta a BBDD.

---
## Async & Await
El núcleo de la programación asincrónica son los objetos `Task` y `Task<T>`, que modelan las operaciones asincrónicas. Son compatibles con las palabras clave `async` y `await`. El modelo es bastante sencillo en la mayoría de los casos:

- Para el código enlazado a E/S, espera una operación que devuelva `Task` o `Task<T>` dentro de un método async.
- Para el código enlazado a la CPU, espera una operación que se inicia en un subproceso en segundo plano con el método `Task.Run`.

La palabra clave `await` es donde ocurre la magia. Genera control para el autor de la llamada del método que ha realizado `await`, y permite una interfaz de usuario con capacidad de respuesta o un servicio flexible.

```Csharp
public async Task MetodoAsync()
{
    // Para operaciones E/S
    var stringData = await _httpClient.GetStringAsync(URL);

    // Para operaciones enlazadas a la CPU
    await Task.Run(() => 
    {
        // Ejecucion de codigo costoso en tiempo
        Thread.Sleep(10000)
    });
}
```

# MultiThreading
Muchos equipos y estaciones de trabajo personales tienen varios núcleos de CPU que permiten ejecutar múltiples subprocesos simultáneamente. Para aprovecharse del hardware, se puede paralelizar el código para distribuir el trabajo entre dichos núcleos.

Por ejemplo, imaginemos que tenemos una aplicacion que requiere de realizar 3 consultas para obtener datos diferentes de una BBDD, aprovechandonos del multithreading, podemos hacer uso de la clase Parallel para realizar esas consultas de forma paralelizada y reducir los tiempos.

---
## Parallel
La clase estatica `Parallel` contiene los metodos `For`, `ForEach` e `Invoke` y se utiliza para hacer procesamiento multihilo de manera automatizada, su uso principal consta en el tratamiento de objetos como `Listas` o `Arrays` y la ejecucion de metodos en paralelo.

### Parallel Invoke
Permite la ejecucion paralelizada de un array de delegados

Cuando se ejecuta la instruccion, el metodo Invoke recibe un array de delegados que ejecutaran en un hilo nuevo y esperara a que estos terminen
```Csharp
Parallel.Invoke(
    () => objeto.Metodo1(),
    () =>
    {
        objeto = new Program();
    }
);
```

### Parallel For
Permite la ejecucion paralelizada de la lectura de una coleccion que implemente `IEnumerable`

```Csharp
Parallel.For(0, collection.Count, (x, state) =>
{
    Console.WriteLine($"Valor de la coleccion - {collection[x]} \n" +
        $"Estado del hilo {state.IsStopped}");
});
```
- El primer parámetro del método se envía el numero por el que se empieza
- El segundo parámetro se envía el numero final de la iteración
- En el tercer parámetro se envían 1 o 2 parámetros
    - `int`: que contendrá el número por el que va la iteración
    - `ParallelLoopState`: un objeto que se encargara de gestionar los      estados de los hilos, pudiendo parar la ejecución, etc.

### Parallel ForEach
El bucle paralelizado ForEach, permite leer una coleccion que implementa `IEnumerable` al igual que el bucle paralelizado For, la diferencia reside en que en ForEach obtienes ya el objeto del indice.

```Csharp
Parallel.ForEach(collection, (item, state, index) =>
{
    Console.WriteLine($"Valor de la coleccion - {item} \n" +
        $"Manipulacion de estado de los hilos {state.LowestBreakIteration} \n" +
        $"Indice en el que estamos posicionados actualmente - {index}");
});
```
- El primer parámetro se envía el objeto que queremos leer, un List<string> por ejemplo
- El segundo parámetro va la lambda que puede recibir dos parámetros
    - `obj` Contendrá un objeto del tipo de la lista y solo 1 elemento de dicha lista, es lo mismo que si a un array le hacemos un objetoArray[x] con un for normal.
    - `ParallelLoopState` Un objeto que se encargara de gestionar los estados de los hilos, pudiendo parar la ejecución, etc.
    - `index` Una propiedad que devuelve en que indice de la coleccion estamos.


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
