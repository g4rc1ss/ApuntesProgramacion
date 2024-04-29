# Lectura Básica de Archivos
Puedes utilizar la clase `File` y `FileReader` para leer datos de un archivo. La lectura se realiza carácter por carácter.

```java
import java.io.File;
import java.io.FileReader;
import java.io.IOException;

public class LecturaDeArchivos {
    public static void main(String[] args) {
        File archivo = new File("miarchivo.txt");

        try (FileReader lector = new FileReader(archivo)) {
            int caracter;
            while ((caracter = lector.read()) != -1) {
                System.out.print((char) caracter);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```

# Lectura de Líneas
Para leer líneas completas de un archivo, puedes usar la clase `BufferedReader`.

```java
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class LecturaDeLineas {
    public static void main(String[] args) {
        try (BufferedReader lector = new BufferedReader(new FileReader("miarchivo.txt"))) {
            String linea;
            while ((linea = lector.readLine()) != null) {
                System.out.println(linea);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```

# Lectura de Archivos Binarios
Si deseas leer datos binarios, como imágenes, utiliza `FileInputStream` en lugar de `FileReader`.

```java
import java.io.FileInputStream;
import java.io.IOException;

public class LecturaDeBinarios {
    public static void main(String[] args) {
        try (FileInputStream inputStream = new FileInputStream("imagen.jpg")) {
            byte[] buffer = new byte[1024];
            int bytesRead;
            while ((bytesRead = inputStream.read(buffer)) != -1) {
                // Procesar el búfer de datos
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```

# Utilizando Scanner
La clase `Scanner` puede ser útil para analizar datos formateados desde un archivo.

```java
import java.io.File;
import java.io.IOException;
import java.util.Scanner;

public class LecturaConScanner {
    public static void main(String[] args) {
        try (Scanner scanner = new Scanner(new File("datos.txt"))) {
            while (scanner.hasNext()) {
                String dato = scanner.next();
                System.out.println(dato);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```
