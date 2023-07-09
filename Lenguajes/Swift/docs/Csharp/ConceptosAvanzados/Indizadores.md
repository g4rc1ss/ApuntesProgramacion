# Indizadores
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
