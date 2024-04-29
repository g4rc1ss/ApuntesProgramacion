# JNI (Java Native Interface)
JNI es una interfaz de programación que permite a Java interactuar con código nativo escrito en C, C++ u otros lenguajes. Esto es útil cuando necesitas acceder a bibliotecas nativas o utilizar características del sistema operativo.

```java
public class InteroperabilidadJNI {
    static {
        System.loadLibrary("miLibreriaNativa"); // Carga la librería nativa
    }

    // Declaración del método nativo
    private native void metodoNativo();

    public static void main(String[] args) {
        new InteroperabilidadJNI().metodoNativo();
    }
}
```

# JNA (Java Native Access)
JNA es una alternativa a JNI que simplifica la interoperabilidad. Permite acceder a bibliotecas nativas sin necesidad de escribir código C/C++. Esto es útil para acceder a funciones de sistema y bibliotecas de forma más directa.

```java
import com.sun.jna.Library;
import com.sun.jna.Native;

public class InteroperabilidadJNA {
    public interface MiLibreriaNativa extends Library {
        MiLibreriaNativa INSTANCE = (MiLibreriaNativa) Native.load("miLibreriaNativa", MiLibreriaNativa.class);

        void metodoNativo();
    }

    public static void main(String[] args) {
        MiLibreriaNativa.INSTANCE.metodoNativo();
    }
}
```

# Web Services y API RESTful
Java puede interactuar con sistemas escritos en otros lenguajes a través de llamadas a servicios web utilizando protocolos como SOAP (Simple Object Access Protocol) o REST (Representational State Transfer).

```java
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;

public class InteroperabilidadWebServices {
    public static void main(String[] args) {
        try {
            URL url = new URL("https://api.example.com/data");
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            // Configurar y realizar llamadas HTTP
            // Procesar la respuesta
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```

# JNI en Android
En el contexto de Android, JNI es comúnmente utilizado para interactuar con código C/C++ para acceder a características nativas y optimizadas.

```java
public class InteroperabilidadJNIAndroid {
    static {
        System.loadLibrary("miLibreriaNativa"); // Carga la librería nativa para Android
    }

    // Declaración del método nativo
    private native void metodoNativo();

    // Resto del código de la aplicación Android
}
```
