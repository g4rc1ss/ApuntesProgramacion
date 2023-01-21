# Polimorfismo
Es la capacidad que tiene una clase en convertirse en un nuevo objeto sin cambiar su esencia y luego volver al objeto original de donde salió.

## Polimorfismo por Herencia
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

## Polimorfismo por Interface
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

