# Definición de Clases y Anotaciones
Debes definir tus clases Java y anotarlas con las anotaciones proporcionadas por JAXB para indicar cómo se deben serializar en XML.

```java
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;

@XmlRootElement
public class Persona {
    private String nombre;
    private int edad;

    @XmlElement
    public String getNombre() {
        return nombre;
    }

    public void setNombre(String nombre) {
        this.nombre = nombre;
    }

    @XmlElement
    public int getEdad() {
        return edad;
    }

    public void setEdad(int edad) {
        this.edad = edad;
    }
}
```

# Serialización de Objetos a XML
Para serializar un objeto Java a XML, utiliza el `Marshaller` de JAXB.

```java
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Marshaller;
import java.io.StringWriter;

public class SerializacionXML {
    public static void main(String[] args) {
        Persona persona = new Persona();
        persona.setNombre("Juan");
        persona.setEdad(30);

        try {
            JAXBContext context = JAXBContext.newInstance(Persona.class);
            Marshaller marshaller = context.createMarshaller();
            
            StringWriter writer = new StringWriter();
            marshaller.marshal(persona, writer);

            String xml = writer.toString();
            System.out.println(xml);
        } catch (JAXBException e) {
            e.printStackTrace();
        }
    }
}
```

# Deserialización de XML a Objetos
Para deserializar un XML en un objeto Java, utiliza el `Unmarshaller` de JAXB.

```java
import javax.xml.bind.JAXBContext;
import javax.xml.bind.JAXBException;
import javax.xml.bind.Unmarshaller;
import java.io.StringReader;

public class DeserializacionXML {
    public static void main(String[] args) {
        String xml = "<persona><nombre>Maria</nombre><edad>28</edad></persona>";

        try {
            JAXBContext context = JAXBContext.newInstance(Persona.class);
            Unmarshaller unmarshaller = context.createUnmarshaller();

            StringReader reader = new StringReader(xml);
            Persona persona = (Persona) unmarshaller.unmarshal(reader);

            System.out.println("Nombre: " + persona.getNombre());
            System.out.println("Edad: " + persona.getEdad());
        } catch (JAXBException e) {
            e.printStackTrace();
        }
    }
}
```
