using ManageMemoryGarbageCollect;


// Caso 1
// Tenemos una variable de ambito global que ocupa mucho espacio en memoria y necesitamos limpiarlo después
var getMemory = () => GC.GetTotalMemory(false) / 1024.0 / 1024.0;

var objetos = new List<ObjetoPesado>();
for (var i = 0; i < 1_000_000_00; i++)
{
    objetos.Add(new(0, 1, "Hi"));
}

Console.WriteLine($"Total de memoria usara en el primer bucle {getMemory():F2} MB");

Console.WriteLine("Limpiamos la lista y forzamos una recolección de elementos");
objetos.Clear();
GC.Collect();
Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");

Console.WriteLine("Redimensionamos la lista reservada al espacio real que ocupa y volvemos a ejecutar el GC");
objetos.TrimExcess();
GC.Collect();
Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");

// Caso 2
// El proceso que ocupa toda esta memoria está dentro de un ambito
static void ProcesarObjetos()
{
    var objetos2 = new List<ObjetoPesado>();
    for (var i = 0; i < 1_000_000_00; i++)
    {
        objetos2.Add(new(0, 1, "Hi"));
    }
}

ProcesarObjetos();
Console.WriteLine($"Total de memoria al salir del metodo {getMemory():F2} MB");

Console.WriteLine($"Recolectamos los elementos");
GC.Collect();
Console.WriteLine($"Memoria después de recolectar elementos {getMemory():F2}MB");

Console.ReadKey();