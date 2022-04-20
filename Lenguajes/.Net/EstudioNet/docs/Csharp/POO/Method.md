# Metodos
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

## Paso de parametros
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

## Metodos de extension
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
