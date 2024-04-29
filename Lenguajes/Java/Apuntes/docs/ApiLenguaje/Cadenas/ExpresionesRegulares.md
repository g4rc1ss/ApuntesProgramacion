# Sintaxis Básica
Las expresiones regulares se componen de caracteres literales y caracteres especiales que representan reglas de búsqueda. Por ejemplo, el patrón `\d+` representa uno o más dígitos.

# Crear un Patrón
Puedes crear un patrón utilizando la clase `Pattern`.

```java
import java.util.regex.Pattern;
import java.util.regex.Matcher;

public class ExpresionesRegulares {
    public static void main(String[] args) {
        String texto = "Mi número de teléfono es 123-456-7890";

        Pattern patron = Pattern.compile("\\d+"); // Busca uno o más dígitos
        Matcher matcher = patron.matcher(texto);

        while (matcher.find()) {
            System.out.println("Coincidencia encontrada: " + matcher.group());
        }
    }
}
```

# Caracteres Especiales
Las expresiones regulares utilizan caracteres especiales para representar ciertos patrones. Algunos ejemplos son:

- `.`: Cualquier carácter excepto salto de línea.
- `\d`: Dígito (0-9).
- `\w`: Carácter alfanumérico.
- `\s`: Espacio en blanco.
- `[]`: Rango de caracteres.

# Cuantificadores
Los cuantificadores indican cuántas veces un carácter o grupo debe aparecer.

- `+`: Uno o más.
- `*`: Cero o más.
- `?`: Cero o uno.
- `{n}`: Exactamente `n` veces.
- `{n,}`: Al menos `n` veces.
- `{n,m}`: Entre `n` y `m` veces.

# Anclaje
Los anclajes definen dónde debe comenzar o terminar una coincidencia.

- `^`: Coincidir al inicio de la línea.
- `$`: Coincidir al final de la línea.

# Grupos y Captura
Los paréntesis `()` se utilizan para agrupar patrones y capturar coincidencias.

```java
String fecha = "Fecha: 2023-08-07";
Pattern patron = Pattern.compile("Fecha: (\\d{4}-\\d{2}-\\d{2})");
Matcher matcher = patron.matcher(fecha);

if (matcher.find()) {
    String fechaEncontrada = matcher.group(1);
    System.out.println("Fecha encontrada: " + fechaEncontrada);
}
```

# Reemplazo y Manipulación
Las expresiones regulares también se pueden usar para reemplazar parte de una cadena.

```java
String texto = "Hola, mi número es 123-456-7890";
String nuevoTexto = texto.replaceAll("\\d+", "X");
System.out.println(nuevoTexto); // "Hola, mi número es X-X-X"
```
