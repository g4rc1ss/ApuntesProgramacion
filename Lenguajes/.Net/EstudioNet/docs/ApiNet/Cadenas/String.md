Una cadena es un objeto de tipo String cuyo valor es texto. Internamente, el 
texto se almacena como una colección secuencial de solo lectura de 
objetos Char.

1. `Replace`: Devuelve una cadena en la que se reemplazan los caracteres introducidos, el primero es el valor a cambiar y el segundo parametro el nuevo valor
1. `Split`: Devuelve un Array con la cadena separada dividiéndola cada vez que encuentre el char enviado, por defecto sera el símbolo '-'
1. `IndexOf`: Devuelve el indice donde se encuentra el caracter indicado
1. `CompareTo`: Compara el string con otro objeto, como por ejemplo, otra cadena
1. `SubString`: Devuelve los caracteres entre una posicion de indice y otra, si no se indica la otra se devolvera la cadena desde el indice inicial

# Literales
| Secuencia de escape | Nombre de carácter | Codificación Unicode |
| ------------------- | ------------------ | -------------------- |
| `\'` | Comilla simple | 0x0027
| `\"` | Comilla doble  | 0x0022
| `\\` | Barra diagonal inversa | 0x005C
| `\0` | Null | 0x0000
| `\a` | Alerta | 0x0007
| `\b` | Retroceso | 0x0008
| `\f` | Avance de página | 0x000C
| `\n` | Nueva línea | 0x000A
| `\r` | Retorno de carro | 0x000D
| `\t` | Tabulación horizontal | 0x0009
| `\U` | Secuencia de escape Unicode para pares suplentes. | `\Unnnnnnnn`
| `\u` | Secuencia de escape Unicode | `\u0041` = "A"
| `\v` | Tabulación vertical | 0x000B
| `\x` | Secuencia de escape Unicode similar a "\u" | \x0041 o \x41 = "A"

# Interpolacion de Cadenas
La interpolación de cadenas se usa para mejorar la legibilidad y el mantenimiento del código. Se obtienen los mismos resultados que con el método `String.Format`, pero mejora la facilidad de uso y la claridad en línea.
```csharp
var saludo = "Hola";
Console.WriteLine($"{saludo} terricola");
```
