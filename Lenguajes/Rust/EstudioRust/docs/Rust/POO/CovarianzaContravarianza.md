# Covarianza y Contravarianza
La covarianza y la contravarianza habilitan la conversión de referencias implícita de tipos de matriz, tipos de delegado y argumentos de tipo genérico. La covarianza conserva la compatibilidad de asignaciones y la contravarianza la invierte.

## Covarianza
La covarianza permite la conversion implícita de un tipo mas derivado(un tipo hijo) a uno menos derivado(un tipo padre).

```Csharp
// Covariante porque string es una clase que hereda de object
IEnumerable<object> convariante = new List<string>();
object[] arrayCovariante = new string[10];
```

## Contravarianza
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
