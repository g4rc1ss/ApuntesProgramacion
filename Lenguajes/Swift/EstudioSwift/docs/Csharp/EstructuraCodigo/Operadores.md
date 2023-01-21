# Operadores
El lenguaje C# proporciona una serie de operadores en la sintaxis del codigo para realizar operaciones como comprobacion de nulos, condiciones, etc.

## Relacionales
| Operador | Descripcion |
| -------- | ----------- |
| `==` | El operador de igualdad `==` devuelve `true` si sus operandos son iguales; en caso contrario, devuelve `false`. |
| `!=` |  |
| `<` | El operador `<` devuelve `true` si el operando izquierdo es menor que el derecho; en caso contrario, devuelve `false`. |
| `>` | El operador `>` devuelve `true` si el operando izquierdo es mayor que el derecho; en caso contrario, devuelve `false`. |
| `<=` | El operador `<=` devuelve `true` si el operando izquierdo es menor o igual que el derecho; en caso contrario, devuelve `false`. |
| `>=` | El operador `>=` devuelve `true` si el operando izquierdo es mayor o igual que el derecho; en caso contrario, devuelve `false`. |


## Condicional NULL de acceso a miembros o `?.` `?[]`
El uso de `?.` o `?[0]` Se usa para comprobar si el contenido es null y si es asi, se va "arrastrando" el null, osea que en este caso, si `lista` es null, no se comprobaria `.count` y se devolveria null.
````Csharp
var lista = default(List<string>);
lista?.Count; 
lista?[0];
````

## Uso combinado NULL o `??` `??=`
Es un operador utilizar para la comprobacion de null, si lo es, se devolvera el operando derecho y sino, el operando izquierdo.
```Csharp
var array = lista ?? new List<string>();
lista ??= new List<string>();
```
- En el primer ejemplo, se comprobara si `lista` es `null` y si lo es, se agregara un `new List<string>()` en la variable `array` y si no, se asignara la variable `lista`.
- En el segundo ejemplo, se comprobara si `lista` es `null`, si es asi, seguira normal y sino, se asignara a la variable lista un `new List<string>()`.

## Sobreescribir Operadores
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

## Implicit Operator
Para hacer una conversion implicita, basta con que en la clase desde la que queremos convertir, definimos un operador estatico para ello.

En una operacion de conversion implicita se realiza una asignacion teniendo en el operando izquierdo la clase que contiene el operador y en el operando derecho la clase de la que se va a convertir.
```Csharp
public static implicit operator ClaseConvertidaImplicita(ClaseParaConvertir clase)
{
    return new ClaseConvertidaImplicita(clase.Id);
}
```

## Explicit Operator
Para hacer una conversion explicita, simplemente agregamos un operador estatico para ello.

Para convertir una clase en otra con un operador explicito, debemos de castearla
```Csharp
public static explicit operator ClaseConvertidaExplicita(ClaseParaConvertir clase)
{
    return new ClaseConvertidaExplicita(clase.Id);
}
```
