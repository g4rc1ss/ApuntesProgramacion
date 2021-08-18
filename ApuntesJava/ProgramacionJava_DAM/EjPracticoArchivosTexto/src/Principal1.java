import java.io.File;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.Scanner;

public class Principal1 {

    String nombreAsig[] = new String[7];
    ArrayList<NotasAlumnos> alumnos = new ArrayList<NotasAlumnos>();
    ArrayList<NotasAlumnos> notas = new ArrayList<NotasAlumnos>();
    ArrayList<NotasAlumnos> asignaturas = new ArrayList<NotasAlumnos>();

    void nombresFicheros() {
        ArrayList<NotasAlumnos> documentos = new ArrayList<NotasAlumnos>();
        
        File maestro = new File("Asignaturas.txt");
        
        Scanner s = null; //Se inicializa a null, luego se dará un valor valor. La s es de stream
        try { //Cuando se lee un fichero externo, es obligatorio usar Try & Catch
            s = new Scanner(maestro); //En lugar de System.in, recibe la instancia "maestro"
            while (s.hasNextLine()) {
                String linea = s.nextLine(); //Obtiene una linea del fichero.
                String[] cortarString = linea.split("\t");
                NotasAlumnos archivos = new NotasAlumnos();
                archivos.setNombreAsignatura(cortarString[0]);
                documentos.add(archivos); //Añade el objeto "archivos" al ArrayList
            }

        } catch (Exception e) {
            e.printStackTrace(); //Método del Try & Catch
        } finally { //Esto se hace siempre, salga error o no
            try {
                if (s != null) {
                    s.close(); //Para cerrar el fichero
                }
            } catch (Exception e2) {
                e2.printStackTrace();
            }
        }

        Iterator<NotasAlumnos> it = documentos.iterator();
        int cont = 0;
        while (it.hasNext()) {
            NotasAlumnos obj2 = new NotasAlumnos();
            obj2 = it.next();
            nombreAsig[cont] = (obj2.getNombreAsignatura());
            cont++;
        }

    }

    /**
     * ******************************************************************************************************
     */
    void separarAsignaturas() {

        for (int x = 0; x < 7; x++) {
            File maestro = new File(nombreAsig[x]);
            Scanner s = null;
            try {
                s = new Scanner(maestro);
                if (s.hasNextLine() == true) {
                    String linea = s.nextLine();
                    String[] cortarString = linea.split("\t");
                    NotasAlumnos archivos = new NotasAlumnos();
                    archivos.setNombreAsignatura(cortarString[0]);
                    asignaturas.add(archivos);
                }

            } catch (Exception e) {
                e.printStackTrace();
            } finally {
                try {
                    if (s != null) {
                        s.close();
                    }
                } catch (Exception e2) {
                    e2.printStackTrace();
                } //FIN CATCH
            } //FIN FINALLY
        } //FIN FOR

    }

    /**
     * ******************************************************************************************************
     */
    void separaraAlumnos() {
        File maestro = new File(nombreAsig[0]);
        Scanner s = null;
        try {
            s = new Scanner(maestro);
            if (s.hasNextLine() == true) {
                String linea = s.nextLine();
            }
            while (s.hasNextLine()) {
                String linea = s.nextLine();
                String[] cortarString = linea.split("\t");
                NotasAlumnos archivos = new NotasAlumnos();
                archivos.setNombreAlumno(cortarString[0]);
                alumnos.add(archivos);
            }

        } catch (Exception e) {
            e.printStackTrace();
        } finally {
            try {
                if (s != null) {
                    s.close();
                }
            } catch (Exception e2) {
                e2.printStackTrace();
            }
        } //FIN FINALLY

    }

    /**
     * ******************************************************************************************************
     */
    void separarNotas() {
        int cont = 1;
        int next = 0;
        int line = 0;
        int lineMax = 2;
        for (int x = 0; x < alumnos.size(); x++) {
            String linea = null;
            while (cont < 8) {
                File maestro = new File(nombreAsig[next]);
                Scanner s = null;
                try {
                    s = new Scanner(maestro);

                    while (line < lineMax) {
                        if (s.hasNextLine()) {
                            String lineas = s.nextLine();
                            line++;
                            linea = lineas;
                        } else {
                            line = lineMax;
                        }
                    } //FIN WHILE

                    String[] cortarString = linea.split("\t");
                    NotasAlumnos archivos = new NotasAlumnos();
                    archivos.setNota(Integer.parseInt(cortarString[1]));
                    notas.add(archivos);
                } catch (Exception e) {
                    e.printStackTrace();
                } finally {
                    try {
                        if (s != null) {
                            s.close();
                        }
                    } catch (Exception e2) {
                        e2.printStackTrace();
                    }
                }
                next++;
                cont++;
                line = 0;
            } //FIN WHILE
            lineMax++;
            line = 0;
            next = 0;
            cont = 1;
        }//FIN FOR

    }

    /**
     * ******************************************************************************************************
     */
    void mostrarNotas() {
        Iterator<NotasAlumnos> iAlumnos = alumnos.iterator();
        Iterator<NotasAlumnos> iNotas = notas.iterator();
        while (iAlumnos.hasNext()) {
            int x = 0;
            NotasAlumnos nombreAlumno = new NotasAlumnos();
            nombreAlumno = iAlumnos.next();
            System.out.println(nombreAlumno.getNombreAlumno());
            System.out.println("----------------------------------");
            Iterator<NotasAlumnos> iAsignaturas = asignaturas.iterator();
            while (iAsignaturas.hasNext()) {
                NotasAlumnos nombreAsignatura = new NotasAlumnos();
                nombreAsignatura = iAsignaturas.next();
                if (x == 0 || x == 1) {
                    System.out.print(nombreAsignatura.getNombreAsignatura() + "\t\t\t");
                } else if (x == 5) {
                    System.out.print(nombreAsignatura.getNombreAsignatura() + "\t\t\t\t");
                } else {
                    System.out.print(nombreAsignatura.getNombreAsignatura() + "\t\t");
                }
                NotasAlumnos notaAsignatura = new NotasAlumnos();
                notaAsignatura = iNotas.next();
                System.out.println(notaAsignatura.getNota());
                x++;
            }
            System.out.println();
            System.out.println();
        }
    }

    public static void main(String[] args) {
        Principal1 obj = new Principal1();
        obj.nombresFicheros();
        obj.separarAsignaturas();
        obj.separaraAlumnos();
        obj.separarNotas();
        obj.mostrarNotas();
    }
}
