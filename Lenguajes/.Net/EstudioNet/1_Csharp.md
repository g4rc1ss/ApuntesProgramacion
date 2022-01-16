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

## Declaración de variables
```Csharp
string a = "hoa";
int b = 2;
double c = 2.0;
bool d = false;
var x = "h";
const int CONSTANTE = 2;
```
- `var` Se usa para no tener que indicar el tipo de la variable, lo detecta automaticamente en tiempo de compilación
- `const` Se usa para establecer un valor que no puede ser modificado

## Alias en using
Al importar un namespace, podemos asignar un alias para identificarlo. Para acceder a una clase que contiene un alias, se usara el operador `::`. Para acceder al namespace de .Net de forma exclusiva, se usara el alias `global`

```Csharp
using aliasUsing = System;

aliasUsing::Console.WriteLine();
global::System.Console.WriteLine();
```

## Tipos Nullables
Los tipos primitivos no pueden ser `null` por defecto, no obstante, si se requiere de hacer uso de null en dichos tipos, se pueden definir de la siguiente forma.
```Csharp
int? numero = null;
Nullable<int> = null;
```

## Boxing y Unboxing
Todos los tipos de C# directa o indirectamente se derivan del tipo de clase object, y object es la clase base definitiva de todos los tipos. Los valores de tipos de referencia se tratan como objetos mediante la visualización de los valores como tipo object.

Los valores de tipos de valor se tratan como objetos mediante la realización de operaciones de conversión boxing y operaciones de conversión unboxing

```Csharp
int i = 123;
object o = i; // Boxing
int j = (int)o; // Unboxing
```

## Dynamic
Este tipo de variables determinan su tipo en tiempo de ejecucion y no de compilacion, por tanto, cada vez que asignemos un nuevo valor, su tipo sera modificado.

```Csharp
// Se inicializa tipo int
dynamic variableDinamica = 1;
// Se le asigna tipo string
variableDinamica = "test";

// Para obtener el tipo de la variable
variableDinamica.GetType().ToString();
```

## Instrucciones de Seleccion
### if-else
Es una instruccion condicional, si esta se evalua como `true`, entrará en el cuerpo que se resuelve. Si hay una instruccion `else`, se entrará cuando ninguna condicion anterior se cumpla. 
```Csharp
if (condicion)
{
}
else if (condicion)
{
}
else
{
}
```
Equivalente ternario
```Csharp
condicion ? esTrue : esFalse
```

### switch
Selecciona una lista de instrucciones para ejecutarla en función de la coincidencia de un patrón con una expresión.
```Csharp
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
Equivalente ternario
```Csharp
opt switch
{
    "Hola" => Console.WriteLine("Hola"),
    _ => Console.WriteLine("Default"),
};
```

## Instrucciones de Iteracion
### while
Ejecuta condicionalmente su cuerpo cero o varias veces.
```Csharp
while (true)
{
}
```

### do while
Ejecuta condicionalmente su cuerpo una o varias veces.
```Csharp
do
{
} while (true);
```

### for
Ejecuta su cuerpo mientras una expresión booleana especificada se evalúe como `true`. Permite inicializar una variable al principio de la iteracion y ejecutar una instruccion cada vez que termina de ejecutarse el cuerpo
```Csharp
for (int i = 0; i < 90; i++)
{
}
```

### foreach
Enumera los elementos de una colección y ejecuta su cuerpo para cada elemento de la colección
```Csharp
foreach (var item in new List<string>())
{
}
```

## Operadores
El lenguaje C# proporciona una serie de operadores en la sintaxis del codigo para realizar operaciones como comprobacion de nulos, condiciones, etc.

### Relacionales
| Operador | Descripcion |
| -------- | ----------- |
| `==` | El operador de igualdad `==` devuelve `true` si sus operandos son iguales; en caso contrario, devuelve `false`. |
| `!=` |  |
| `<` | El operador `<` devuelve `true` si el operando izquierdo es menor que el derecho; en caso contrario, devuelve `false`. |
| `>` | El operador `>` devuelve `true` si el operando izquierdo es mayor que el derecho; en caso contrario, devuelve `false`. |
| `<=` | El operador `<=` devuelve `true` si el operando izquierdo es menor o igual que el derecho; en caso contrario, devuelve `false`. |
| `>=` | El operador `>=` devuelve `true` si el operando izquierdo es mayor o igual que el derecho; en caso contrario, devuelve `false`. |

### Condicional NULL de acceso a miembros o `?.` `?[]`
El uso de `?.` o `?[0]` Se usa para comprobar si el contenido es null y si es asi, se va "arrastrando" el null, osea que en este caso, si `lista` es null, no se comprobaria `.count` y se devolveria null.
````Csharp
var lista = default(List<string>);
lista?.Count; 
lista?[0];
````

### Uso combinado NULL o `??` `??=`
Es un operador utilizar para la comprobacion de null, si lo es, se devolvera el operando derecho y sino, el operando izquierdo.
```Csharp
var array = lista ?? new List<string>();
lista ??= new List<string>();
```
- En el primer ejemplo, se comprobara si `lista` es `null` y si lo es, se agregara un `new List<string>()` en la variable `array` y si no, se asignara la variable `lista`.
- En el segundo ejemplo, se comprobara si `lista` es `null`, si es asi, seguira normal y sino, se asignara a la variable lista un `new List<string>()`.

### Sobreescribir Operadores
Un tipo puede proporcionar la implementación personalizada de una operación cuando uno o los dos operandos son de ese tipo
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
}
````

### Implicit Operator
Para hacer una conversion implicita, basta con que en la clase desde la que queremos convertir, definimos un operador estatico para ello.

En una operacion de conversion implicita se realiza una asignacion teniendo en el operando izquierdo la clase que contiene el operador y en el operando derecho la clase de la que se va a convertir.
```Csharp
public static implicit operator ClaseConvertidaImplicita(ClaseParaConvertir clase)
{
    return new ClaseConvertidaImplicita(clase.Id);
}
```

### Explicit Operator
Para hacer una conversion explicita, simplemente agregamos un operador estatico para ello.

Para convertir una clase en otra con un operador explicito, debemos de castearla
```Csharp
public static explicit operator ClaseConvertidaExplicita(ClaseParaConvertir clase)
{
    return new ClaseConvertidaExplicita(clase.Id);
}
```

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

# Programación Orientada a Objetos
La programación orientada a objetos (Object Oriented Programming, OOP) es un modelo de programación que organiza el diseño de software en torno a datos u objetos, en lugar de funciones y lógica. Un objeto se puede definir como un campo de datos que tiene atributos y comportamiento únicos.

## Clases
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

## Clases Estaticas
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

## Metodos
Un método es un bloque de código que contiene una serie de instrucciones.
```Csharp
//[access modifier] - [type] - [identifier]
private void Metodo()
{
    Console.WriteLine("");
}

private string MetodoConReturn()
{
    return string.Empty;
}

private void MetodoConParametros(string texto)
{
    Console.WriteLine(texto);
}
```

### Paso de parametros
Los parametros a los metodos se pueden pasar de varias formas y con diferentes modificadores:
- **params**: Especifica que el parámetro puede tomar un número variable de argumentos. El tipo de parámetro debe ser una matriz unidimensional.
    ```Csharp
    void UseParams(params int[] list)
    ```
- **ref**: El parámetro se pasa por referencia y puede ser leído o escrito por el método llamado
    ```Csharp
    void RefArgExample(ref int number)
    ```
- **in**: El argumento se pasa por referencia, pero garantiza que el argumento no puede ser modificado. 
    ```Csharp
    void InArgExample(in int number)
    ```
- **out**: El parámetro se pasa por referencia y se escribe mediante el método llamado. Es una manera de retornar por referencia un valor del metodo
    ```Csharp
    void OutArgExample(out int number)
    ```

### Metodos de extension
Los métodos de extensión permiten "agregar" métodos a los tipos existentes sin crear un nuevo tipo derivado, recompilar o modificar de otra manera el tipo original. Los métodos de extensión son métodos estáticos, pero se les llama como si fueran métodos de instancia en el tipo extendido.

El método tiene que ser estático y en el primer parámetro, debemos indicar la palabra clave `this`.

```Csharp
public static class StringExtensions
{
    public static string stringExtension(this string cadena)
    {
        // code
    }
}
```

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

## Herencia
La herencia significa que se pueden crear nuevas clases partiendo de clases existentes, que tendrá todas los atributos, propiedades y los métodos de su 'superclass' o 'clase padre' y además se le podrán añadir otros atributos, propiedades y métodos propios.

```Csharp
public class Clase : SuperClase 
{
}
```

## Clases Abstractas
No se pueden crear instancias de una clase abstracta. 

La finalidad de una clase abstracta es ser una clase de la cual se hereda y te da la posibilidad de tener metodos base funcionales y metodos abstractos, estos ultimos son metodos que han de ser "declarados" en la clase abstracta y sobreescritos en la clase derivada.

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

## Sealed Class
El modificador `sealed` se usa para sellar una clase y que esta no pueda ser heredada.

Tambien se puede usar este modificador en metodos o propiedades para que estos no puedan ser sobreescritos
```Csharp
sealed class SealedClass
{
}
``` 

## Interface
Las interfaces, como las clases, definen un conjunto de propiedades, métodos y eventos. Pero de forma contraria a las clases, las interfaces no proporcionan implementación.

Una interfaz representa un contrato, en el cual una clase que implementa una interfaz debe implementar cualquier aspecto de dicha interfaz exactamente como esté definido,

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

## Polimorfismo
Es la capacidad que tiene una clase en convertirse en un nuevo objeto sin cambiar su esencia y luego volver al objeto original de donde salió.

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

### Polimorfismo por Interface
Podemos devolver una instancia de un objeto como una interfaz, cuando ese objeto implemente dicha interfaz. Por tanto, una interfaz puede actuar como diferentes objetos.

```Csharp
interface IEscribir
{
    void Escribiendo();
}

class Escribir : IEscribir
{
    public void Escribiendo()
    {
        Console.WriteLine("Escribiendo el hijo");
    }
}

static void Main(string[] args)
{
    IEscribir escritura = new Escribir();
    escritura.Escribiendo();
}
```

## Covarianza y Contravarianza
La covarianza y la contravarianza habilitan la conversión de referencias implícita de tipos de matriz, tipos de delegado y argumentos de tipo genérico. La covarianza conserva la compatibilidad de asignaciones y la contravarianza la invierte.

### Covarianza
La covarianza permite la conversion implícita de un tipo mas derivado(un tipo hijo) a uno menos derivado(un tipo padre).

```Csharp
// Covariante porque string es una clase que hereda de object
IEnumerable<object> convariante = new List<string>();
object[] arrayCovariante = new string[10];
```

### Contravarianza
La contravarianza permite la conversion de una clase hija a una clase padre.

```Csharp
class ClaseBase
{
}

class ClaseHijo : ClaseBase
{

}

class Comparar : IEqualityComparer<ClaseBase>
{
    public bool Equals(ClaseBase x, ClaseBase y)
    {
        return x == y;
    }

    public int GetHashCode([DisallowNull] ClaseBase obj)
    {
        return obj.GetHashCode();
    }
}

// Contravariante porque la interfaz IEqualityComparer es contravariante
// Primero inicializamos a una ClaseBase la clase Comparar y luego la agregamos
// A una clase con una interfaz que implementa otra clase que deriva de ClaseBase
IEqualityComparer<ClaseBase> claseComparar = new Comparar();
IEqualityComparer<ClaseHijo> contravariante = claseComparar;
```


# Tratamiento de Excepciones
Una excepción es cualquier condición de error o comportamiento inesperado que encuentra un programa en ejecución. 

Las excepciones pueden iniciarse debido a un error en el código propio o en el código al que se llama (por ejemplo, una biblioteca compartida), a recursos del sistema operativo no disponibles, a condiciones inesperadas que encuentra el runtime (por ejemplo, imposibilidad de comprobar el código), etc.

## Capurando las excepciones
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

## Provocando una excepcion
```Csharp
public static void Main(string[] args)
{
    throw new ArgumentNullException($"El parametro {nameof(args)} es nulo");
}
```

## Creando excepciones propias
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

## Indizadores
Permiten crear una clase, un struct o una interfaz con un "indice" al que se accederá a traves del objeto instanciado de la clase, no hace falta acceder a la matriz como tal.
```Csharp
public class ClaseIndex
{
    private readonly float[] temps = new float[10];
    public float this[int index] {
        get {
            return temps[index];
        }
        set {
            temps[index] = value;
        }
    }
}
objetoIndice[1] = 58.3F;
```

## Yield
Lo que el operador yield realiza es pausar la ejecución de la iteración y devuelve el valor al método que realiza la llamada para que este continúe con su ejecución y cuando termine volverá al siguiente punto del iterador.

- `yield` nos puede dar mejoras en el rendimiento y el uso de la ram lo cual siempre es importante.
- Una vez nos acostumbramos a utilizarlo, podemos ver que es muy útil y muy potente, pero desafortunadamente no es muy común

```Csharp
public class EnumerablePersonalizado<T> : IEnumerable<T>
{
    public T[] collection;

    public EnumerablePersonalizado(int maxIndex)
    {
        collection = new T[maxIndex];
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach(var collect in collection)
        {
            yield return collect;
        }
    }
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
```

## Generics
Los genéricos introducen en .NET el concepto de parámetros de tipo, lo que le permite diseñar clases y métodos que aplazan la especificación de uno o varios tipos hasta que el código de cliente declare y cree una instancia de la clase o el método.

Para que usar los genéricos?
- Use tipos genéricos para maximizar la reutilización del código, la seguridad de tipos y el rendimiento.
- El uso más común de los genéricos es crear clases de colección.
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
