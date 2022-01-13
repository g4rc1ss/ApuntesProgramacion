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
- `var` Se usa para no tener que indicar el tipo de la variable, lo detecta automaticamente
- `const` Se usa para establecer un valor que no puede ser modificado


## Tipos Nullables
Los tipos primitivos no pueden ser `null` por defecto, no obstante, si se requiere de hacer uso de null en dichos tipos, se pueden definir de la siguiente forma.
```Csharp
int? numero = null;
Nullable<int> = null;
```


## Convertir tipos
Para convertir a otros tipos se puede hacer uso de la clase estatica `Convert` como el ejemplo de arriba
```Csharp
Convert.ToInt32(2.0); // 2
Convert.ToBoolean(1); // true
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


## Instrucciones de toma de decisiones
### Condicionales
#### if-else
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
```

#### switch
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

### Iteracion
#### while

```Csharp
while (true)
{
}
```

#### do while

```Csharp
do
{
} while (true);
```

#### for

```Csharp
for (int i = 0; i < 90; i++)
{
}
```

#### foreach

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

### Alias en using
Cuando importamos un namespace, podemos asignar un alias para identificarlo como si de una variable se tratara.  
Para acceder a una clase que contiene un alias, se usara el operador `::`  
Para acceder al namespace de .Net de forma exclusiva, se usara el alias `global`

```Csharp
using aliasUsing = System;

aliasUsing::Console.WriteLine();
global::System.Console.WriteLine();
```

### Ternario o `?:`
Se realiza la comprobacion de un `bool` y se agregan dos simbolos, el `?` cuando se cumple la condicion y los `:` si no se cumple dicha condicion
```Csharp
"x".StartsWith('d') ? "Empieza por d" : "Pues no, no empieza por d";

```

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

### Implicit Operator
Para hacer una conversion implicita, basta con que en la clase desde la que queremos convertir, definimos un operador estatico para ello.

En una operacion de conversion implicita se realiza una asignacion teniendo en el operando izquierdo la clase que contiene el operador y en el operando derecho la clase de la que se va a convertir.
```Csharp
internal class ClaseParaConvertir
{
    public string Id { get; set; }
    public string Propiedad { get; set; }

    public ClaseParaConvertir()
    {
    }

    public ClaseParaConvertir(string id, string propiedad)
    {
        Id = id;
        Propiedad = propiedad;
    }
}

internal class ClaseConvertidaImplicita
{
    public string Id { get; set; }

    public ClaseConvertidaImplicita(string id)
    {
        Id = id;
    }

    public static implicit operator ClaseConvertidaImplicita(ClaseParaConvertir clase)
    {
        return new ClaseConvertidaImplicita(clase.Id);
    }
}

// Codigo que ejecutamos
var convirtiendo = new ClaseParaConvertir()
{
    Id = "2345678987654",
    Propiedad = "hbfohsgbvyoduuvhduyovbxovgdvugfbvyfud"
};

ClaseConvertidaImplicita conversionImplicita = convirtiendo;
```

### Explicit Operator
Para hacer una conversion explicita, simplemente agregamos un operador estatico para ello.

En las operaciones de conversion explicitas se debe indicar mediante el casteo el tipo del a clase a la que queremos convertir.
```Csharp
internal class ClaseParaConvertir
{
    public string Id { get; set; }
    public string Propiedad { get; set; }

    public ClaseParaConvertir()
    {
    }

    public ClaseParaConvertir(string id, string propiedad)
    {
        Id = id;
        Propiedad = propiedad;
    }
}

internal class ClaseConvertidaExplicita
{
    public string Id { get; set; }

    public ClaseConvertidaExplicita(string id)
    {
        Id = id;
    }

    public static explicit operator ClaseConvertidaExplicita(ClaseParaConvertir clase)
    {
        return new ClaseConvertidaExplicita(clase.Id);
    }
}


// Codigo a ejecutar
var convirtiendo = new ClaseParaConvertir()
{
    Id = "2345678987654",
    Propiedad = "hbfohsgbvyoduuvhduyovbxovgdvugfbvyfud"
};

var conversionExplicita = (ClaseConvertidaExplicita)convirtiendo;
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

#### Modificador params
El modificador params se utiliza cuando queremos mandar por parametro a un metodo una cantidad muy grande de ellos, los recibe como una lista y los puede leer a traves de un bucle `foreach`

Por ejemplo, supongamos que queremos hacer una verificacion de parametros null, para hacer el metodo reulizable lo hacemos mediante `params`
```Csharp
private void MetodoParams(params string[] parametros)
{
    foreach (var param in parametros)
    {
        Console.WriteLine(param);
    }
}
```

#### Modificadores `in`, `ref`. `out`
Cuando pasamos parametros a un metodo, internamente se crea un nuevo espacio de memoria para el procesado de dichos parametros.  
Para aumentar el rendimiento se pueden pasar los valores por referencia, es decir, pasar la direccion de memoria donde de aloja dichos valores, de esta forma el proceso es mas rapido y no consume mas memoria.

Hay tres tipos de modificadores:
- `ref`: Se indica para pasar el parametro por referencia, hay que tener en cuenta que cuando hacemos esto, se le manda la direccion donde esta alojado el objeto que estamos enviando, por tanto, si el metodo modifica el objeto que recibe, estara modificando el objeto original.
- `in`: Para evitar el problema del modificador `ref` se ha creado el modificador `in`, este permite enviar el objeto por referencia tambien, pero evitara que se puedan alterar los valores del original.
- `out`: Con el modificador `out` se evitaria el return del metodo, dentro del metodo se podra almacenar la variable marcada como `out` con el contenido correspondiente y recorger dicha variable desde la llamada al metodo.

```Csharp
private static void MetodoMoficadores(in string mod1, ref string mod2, out string mod3)
{
    Console.WriteLine($"{mod1} - Soy una referencia, pero soy de solo lectura");
    mod2 = "Sobreescribo lo que habia porque acceso a la referencia";
    mod3 = "Creo una variable y devuelvo su ref para almacenarla en la llamada externa";
}

var mod1 = "Soy un valor que se va a pasar por in";
var mod2 = "Soy un valor que se va a pasar por ref";
var mod3 = default(string);
MetodoMoficadores(in mod1, ref mod2, out mod3);
```

### Metodos de extension
Los métodos de extensión permiten "agregar" métodos a los tipos existentes sin crear un nuevo tipo derivado, recompilar o modificar de otra manera el tipo original. Los métodos de extensión son métodos estáticos, pero se les llama como si fueran métodos de instancia en el tipo extendido.

El método tiene que ser estático y en el primer parámetro, debemos indicar la palabra clave `this`.

```Csharp
public static class StringExtensions
{
    public static string PrimeraMaysucula(this string fraseInicial)
    {
        char primeraLetra = char.ToUpper(fraseInicial[0]);
        string RestoDeFrase = fraseInicial.Substring(1);

        return primeraLetra + RestoDeFrase;
    }
}

//Llamada
Console.WriteLine("hello world!".PrimeraMaysucula());
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
        for (int i = 0; i < collection.Length; i++)
        {
            yield return collection[i];
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