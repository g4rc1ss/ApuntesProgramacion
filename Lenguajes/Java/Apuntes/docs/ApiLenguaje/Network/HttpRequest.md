# Llamada HTTP GET
Para realizar una llamada HTTP GET básica, utiliza la clase `HttpURLConnection`.

```java
import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.net.HttpURLConnection;
import java.net.URL;

public class LlamadaHTTP {
    public static void main(String[] args) {
        try {
            URL url = new URL("https://jsonplaceholder.typicode.com/posts/1");
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            connection.setRequestMethod("GET");
            int responseCode = connection.getResponseCode();

            if (responseCode == HttpURLConnection.HTTP_OK) {
                BufferedReader reader = new BufferedReader(new InputStreamReader(connection.getInputStream()));
                String inputLine;
                StringBuilder response = new StringBuilder();

                while ((inputLine = reader.readLine()) != null) {
                    response.append(inputLine);
                }
                reader.close();

                System.out.println(response.toString());
            } else {
                System.out.println("Llamada fallida, Código de respuesta: " + responseCode);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```

# Llamada HTTP POST
Para realizar una llamada HTTP POST, puedes configurar la conexión y enviar datos.

```java
import java.io.DataOutputStream;
import java.io.IOException;
import java.net.HttpURLConnection;
import java.net.URL;

public class LlamadaHTTPPost {
    public static void main(String[] args) {
        try {
            URL url = new URL("https://jsonplaceholder.typicode.com/posts");
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();

            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-Type", "application/json");
            connection.setDoOutput(true);

            String postData = "{\"title\":\"Nuevo Post\",\"body\":\"Contenido del post\"}";
            try (DataOutputStream outputStream = new DataOutputStream(connection.getOutputStream())) {
                outputStream.writeBytes(postData);
                outputStream.flush();
            }

            int responseCode = connection.getResponseCode();
            System.out.println("Código de respuesta: " + responseCode);
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
```
