import Entities.Disco;
import Enums.EstilosMusica;
import com.db4o.Db4o;
import com.db4o.ObjectContainer;
import com.db4o.ObjectSet;
import com.db4o.query.Query;

import java.io.File;
import java.util.Scanner;

public class Main {
    private static final String ARCHIVO_DATABASE_OBJECT = "Discos.db4o";

    public static void main(String[] args) {
        try {
            ObjectContainer discosDB = Db4o.openFile(ARCHIVO_DATABASE_OBJECT);
            Scanner scanner = new Scanner(System.in);

            if (!discosDB.get(new Disco()).hasNext())
                inicializarBBDD(discosDB);

            // Mostrar todos los datos
            for (ObjectSet discos = discosDB.get(new Disco()); discos.hasNext(); ) {
                System.out.println("------------------------------------------------");
                Disco disco = (Disco) discos.next();
                System.out.println(getFormatToPrintData(disco));
            }


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (el filtro de grupo)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();


            // Filtrar por grupo
            System.out.println("Teclea un grupo para buscar");
            Query query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("nombreGrupo").constrain(scanner.nextLine());
            for (ObjectSet respuesta = query.execute(); respuesta.hasNext(); ) {
                Disco discos = (Disco) respuesta.next();
                System.out.println(getFormatToPrintData(discos));
            }


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (la modificacion de un disco)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();

            // Modificamos los registros que tienen estilo de muscia clasica por Jazz
            query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("estiloMusica").constrain("Clasica");
            for (ObjectSet respuesta = query.execute(); respuesta.hasNext(); ) {
                Disco discoToModify = (Disco) respuesta.next();
                discoToModify.setEstiloMusica(EstilosMusica.Jazz);
                discosDB.set(discoToModify);
            }
            System.out.println("Comprobamos que ha funcionado el proceso de modificacion");
            System.out.println(
                    query.execute().hasNext()
                            ? "Hay datos, se ha modificado mal"
                            : "Se han modificado bien los datos");


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (el borrado de un disco)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();

            // Borrado de registro de la bbdd cuyo nombre de grupo sea Green Day
            query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("nombreGrupo").constrain("Green Day");
            for (ObjectSet respuesta = query.execute(); respuesta.hasNext(); )
                discosDB.delete(respuesta.next());
            System.out.println("Comprobar que se ha borrado");
            System.out.println(
                    query.execute().hasNext()
                            ? "Hay datos, se ha borrado mal"
                            : "Se han borrado bien los datos");


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (mostrar discos de un estilo concreto)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();

            // Mostrar todos los discos de un estilo concreto que indicara el usuario.
            System.out.println("Teclea un estilo para buscar");
            query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("estiloMusica").constrain(scanner.nextLine());
            for (ObjectSet discos = query.execute(); discos.hasNext(); ) {
                System.out.println("------------------------------------------------");
                Disco disco = (Disco) discos.next();
                System.out.println(getFormatToPrintData(disco));
            }


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (mostrar datos anteriores a x año)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();

            // Mostrar todos los discos que sean anteriores a un año, que introducirá el
            // usuario por teclado. Los resultados se deberán mostrar ordenados
            // ascendentemente por el campo año.
            System.out.println("Teclea un año para buscar");
            int yearToSearch = 0;
            try {
                yearToSearch = scanner.nextInt();
            } catch (Exception ex) {
                System.exit(-1);
            }
            query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("anioPublicacion").constrain(yearToSearch).smaller();
            query.descend("anioPublicacion").orderAscending();
            for (ObjectSet discos = query.execute(); discos.hasNext(); ) {
                System.out.println("------------------------------------------------");
                Disco disco = (Disco) discos.next();
                System.out.println(getFormatToPrintData(disco));
            }


            System.out.println("pulsa cualquier tecla para ir al siguiente paso (filtro por disco con estilo y mas de x canciones)");
            scanner.nextLine();
            for (int x = 0; x < 2; x++)
                System.out.println();


            // Mostrar todos los discos de un estilo concreto y que tengan más de X
            // canciones. El estilo y el número de canciones los introducirá el usuario por
            // teclado.
            System.out.println("Teclea el estilo a filtrar");
            String estilo = scanner.nextLine();

            System.out.println("Teclear el numero de canciones a filtrar");
            int songs = 0;
            try {
                songs = scanner.nextInt();
            } catch (Exception ex) {
                System.exit(-1);
            }
            query = discosDB.query();
            query.constrain(Disco.class);
            query.descend("estiloMusica").constrain(estilo)
                    .and(query.descend("numCanciones").constrain(songs).greater());
            for (ObjectSet discos = query.execute(); discos.hasNext(); ) {
                System.out.println("------------------------------------------------");
                Disco disco = (Disco) discos.next();
                System.out.println(getFormatToPrintData(disco));
            }
            discosDB.close();
        } finally {
            var archivo = new File(ARCHIVO_DATABASE_OBJECT);
            archivo.delete();
        }
    }


    private static void inicializarBBDD(ObjectContainer discosDB) {
        discosDB.set(new Disco("Thirty Seconds To Mars", "This is War", EstilosMusica.Rock, 12, 2009));
        discosDB.set(new Disco("Imagine Dragons", "Night Visions", EstilosMusica.Rock, 14, 2012));
        discosDB.set(new Disco("Hans Zimmer", "The World of Hans Zimmer", EstilosMusica.Clasica, 22, 2019));
        discosDB.set(new Disco("We The Kings", "Somewhere Somehow", EstilosMusica.Punk, 13, 2013));
        discosDB.set(new Disco("The High Kings", "The High Kings", EstilosMusica.Folk, 13, 2010));
        discosDB.set(new Disco("The Killers", "Hot Fus", EstilosMusica.Rock, 14, 2004));
        discosDB.set(new Disco("Green Day", "21st Century Breakdown", EstilosMusica.Punk, 18, 2009));
        discosDB.set(new Disco("Ryan Star", "11:59", EstilosMusica.Rock, 13, 2010));
    }

    private static String getFormatToPrintData(Disco disco) {
        return "" +
                "[NOMBRE DEL GRUPO = " + disco.getNombreGrupo() + "]\n" +
                "[TITULO = " + disco.getTitulo() + "]\n" +
                "[ESTILO = " + disco.getEstiloMusica() + "]\n" +
                "[NUM. CANCIONES  = " + disco.getNumCanciones() + "]\n" +
                "[AÑO PUBLICACION = " + disco.getAnioPublicacion() + "]";
    }
}
