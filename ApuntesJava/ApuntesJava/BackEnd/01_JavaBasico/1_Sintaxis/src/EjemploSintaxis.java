import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;

public class EjemploSintaxis {
    public static void main(String[] args){
        String a = "hoa"; int b = 2; double c = 2.0; boolean d = false;
        var j = "h";
        System.out.printf("%s %.2f %d %n %b", a, c, b, d);

        String d2 = ""+d+"";
        int c2 = (int) c;
        float b2 = (float)b;
        System.out.printf("%s %.2f %d %n %b", a, c, b, d);

        String[] array = new String[5];
        String[] array2 = {"H", "o", "l", "a"};

        ArrayList<String> arrayList = new ArrayList<>();
        arrayList.add(0, "hgfngj");

        Map<Integer, String> dictionary = new HashMap<Integer, String>();
        dictionary.put(0, "hola");
        System.out.println(dictionary.get(0));

        if (a == Integer.toString(b) || b == c &&  !d){
            System.out.println("pasa por verdadero");
        } else if ( a != Integer.toString(b)){
            System.out.println("diferente");
        } else{
            System.out.println("pues nah!");
        }

        switch(b) {
            case 0:
                System.out.println("es 0");
                break;
            case 1:
                System.out.println("es 1");
                break;
            case 2:
                System.out.println("es 2");
                break;
            case 3:
                System.out.println("es 3");
                break;
        }

        String a3 = "0";
        int b3 = 2;
        String ternario = a3.equals("0") ? a3 : Integer.toString(b3);


        int edad = 0;
        while (edad < 3) {
            edad ++;
            System.out.println(edad);
        }

        for(int x = 0; x < 3; x++){
            edad ++;
            System.out.printf("%d %n rango: %d %n", edad, x);
        }

        for (var i : arrayList)
            System.out.print(i);

        new EjemploSintaxis().imprimir("hola, este es el texto");

        try {
            int numero = 0;
            int resultado = 2 / numero;
        } catch(ArithmeticException zero) {
            System.out.printf("Estas dividiendo entre 0 %s", zero.getMessage());
        } catch(Exception ex) {
            System.out.printf("Estas haciendo algo mal %s", ex.getMessage());
        } finally {
            //Aqui se suele añadir instrucciones de finalizacion del programa o cerrado de archivos
        }

    }
    private void imprimir(String texto){
        imprimir(texto, 1);
    }
    private void imprimir(String texto, int veces){
        for(int x = 0; x < veces; x ++)
            System.out.println(texto);
    }

}
