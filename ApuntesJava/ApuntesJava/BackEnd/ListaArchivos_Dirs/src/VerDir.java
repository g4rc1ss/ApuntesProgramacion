import java.io.File;
import java.util.Arrays;

public class VerDir {
    public static void main(String[] args) {
        String dir = "/";
        System.out.println("Archivos en el directorio " + dir);
        File f = new File(dir);
        String[] archivos = f.list();

        assert archivos != null;
        Arrays.stream(archivos).parallel().forEach(System.out::println);
    }
}
