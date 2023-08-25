# Instalación y Configuración de MongoDB
Asegúrate de tener MongoDB instalado y en funcionamiento en tu sistema. Puedes descargar MongoDB desde el sitio oficial (https://www.mongodb.com/try/download/community) y seguir las instrucciones de instalación para tu sistema operativo.

# Dependencias y Configuración del Proyecto
Agrega la biblioteca MongoDB Java Driver a tu proyecto (por ejemplo, a través de Maven o Gradle). Importa las clases necesarias.

# Establecer Conexión y Realizar Operaciones
La biblioteca MongoDB Java Driver te permite establecer una conexión a la base de datos y realizar operaciones como inserción, consulta, actualización y eliminación de documentos.

```java
import com.mongodb.MongoClient;
import com.mongodb.MongoClientURI;
import com.mongodb.client.MongoCollection;
import com.mongodb.client.MongoDatabase;
import org.bson.Document;

public class ConexionMongoDB {
    public static void main(String[] args) {
        String uri = "mongodb://usuario:contraseña@localhost:27017/nombre_base_de_datos";
        MongoClientURI clientURI = new MongoClientURI(uri);
        try (MongoClient mongoClient = new MongoClient(clientURI)) {
            MongoDatabase database = mongoClient.getDatabase("nombre_base_de_datos");
            MongoCollection<Document> coleccion = database.getCollection("nombre_coleccion");

            // Realizar operaciones con la base de datos
        }
    }
}
```

# Ejemplo de Inserción de Documentos
Puedes utilizar la colección para insertar documentos en MongoDB.

```java
public class InsercionDocumentos {
    public static void main(String[] args) {
        String uri = "mongodb://usuario:contraseña@localhost:27017/nombre_base_de_datos";
        MongoClientURI clientURI = new MongoClientURI(uri);
        try (MongoClient mongoClient = new MongoClient(clientURI)) {
            MongoDatabase database = mongoClient.getDatabase("nombre_base_de_datos");
            MongoCollection<Document> coleccion = database.getCollection("nombre_coleccion");

            Document nuevoDocumento = new Document("campo1", "valor1")
                    .append("campo2", "valor2")
                    .append("campo3", "valor3");
            coleccion.insertOne(nuevoDocumento);
        }
    }
}
```

# Ejemplo de Consulta de Documentos
Puedes utilizar métodos de la colección para realizar consultas y obtener resultados.

```java
import com.mongodb.client.FindIterable;
import com.mongodb.client.MongoCursor;

public class ConsultaDocumentos {
    public static void main(String[] args) {
        String uri = "mongodb://usuario:contraseña@localhost:27017/nombre_base_de_datos";
        MongoClientURI clientURI = new MongoClientURI(uri);
        try (MongoClient mongoClient = new MongoClient(clientURI)) {
            MongoDatabase database = mongoClient.getDatabase("nombre_base_de_datos");
            MongoCollection<Document> coleccion = database.getCollection("nombre_coleccion");

            FindIterable<Document> resultados = coleccion.find();
            try (MongoCursor<Document> cursor = resultados.iterator()) {
                while (cursor.hasNext()) {
                    Document documento = cursor.next();
                    System.out.println(documento.toJson());
                }
            }
        }
    }
}
```

# Ejemplo de Actualización de Documentos
Puedes utilizar métodos de la colección para actualizar documentos existentes.

```java
import com.mongodb.client.result.UpdateResult;

public class ActualizacionDocumentos {
    public static void main(String[] args) {
        String uri = "mongodb://usuario:contraseña@localhost:27017/nombre_base_de_datos";
        MongoClientURI clientURI = new MongoClientURI(uri);
        try (MongoClient mongoClient = new MongoClient(clientURI)) {
            MongoDatabase database = mongoClient.getDatabase("nombre_base_de_datos");
            MongoCollection<Document> coleccion = database.getCollection("nombre_coleccion");

            Document filtro = new Document("campo1", "valor1");
            Document actualizacion = new Document("$set", new Document("campo2", "nuevo_valor"));
            UpdateResult resultado = coleccion.updateMany(filtro, actualizacion);
            System.out.println(resultado.getModifiedCount() + " documento(s) actualizado(s)");
        }
    }
}
```

# Ejemplo de Eliminación de Documentos
Puedes utilizar métodos de la colección para eliminar documentos.

```java
import com.mongodb.client.result.DeleteResult;

public class EliminacionDocumentos {
    public static void main(String[] args) {
        String uri = "mongodb://usuario:contraseña@localhost:27017/nombre_base_de_datos";
        MongoClientURI clientURI = new MongoClientURI(uri);
        try (MongoClient mongoClient = new MongoClient(clientURI)) {
            MongoDatabase database = mongoClient.getDatabase("nombre_base_de_datos");
            MongoCollection<Document> coleccion = database.getCollection("nombre_coleccion");

            Document filtro = new Document("campo1", "valor1");
            DeleteResult resultado = coleccion.deleteMany(filtro);
            System.out.println(resultado.getDeletedCount() + " documento(s) eliminado(s)");
        }
    }
}
```

Recuerda manejar las excepciones de manera adecuada y cerrar las conexiones en bloques `try-with-resources` para evitar posibles fugas de recursos.
