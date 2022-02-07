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
