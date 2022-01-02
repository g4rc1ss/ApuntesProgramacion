import EscribirXml.WriteXml;
import LeerXml.ReadXml;
import org.xml.sax.SAXException;

import javax.xml.parsers.ParserConfigurationException;
import javax.xml.transform.TransformerException;
import java.io.File;
import java.io.IOException;

public class CrearEmpleadoXML {
    private static final String NOMBRE_ARCHIVO = "archivo.xml";

    public static void main(String args[]) throws ParserConfigurationException, TransformerException, IOException, SAXException {
        new WriteXml(NOMBRE_ARCHIVO);
        new ReadXml(NOMBRE_ARCHIVO);


        File archivo = new File(NOMBRE_ARCHIVO);
        archivo.delete();
    }
}