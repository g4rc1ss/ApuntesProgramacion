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

