**string** es una clase inmutable, eso quiere decir que su valor no puede ser modificado y por tanto, cuando realizamos labores como concatenar, lo que en realidad se hace es crear una cadena nueva con esas dos cadenas juntas.

**StringBuidler** en cambio permite la mutabilidad de la cadena, por tanto, es posible hacer modificaciones a esta sin ncesidad de crearla de nuevo, dando lugar a mas performance en dependiendo que situaciones.

```Csharp
var stringBuilder = new StringBuilder();
stringBuilder.Append("Terminado");
stringBuilder.Replace("Hola", "Adios");
var cadenaCompleta = stringBuilder.ToString();
```
