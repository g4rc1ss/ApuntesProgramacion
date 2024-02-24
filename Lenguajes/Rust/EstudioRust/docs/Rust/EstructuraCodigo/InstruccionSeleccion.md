# Instrucciones de Seleccion
## if-else
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

## switch
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
